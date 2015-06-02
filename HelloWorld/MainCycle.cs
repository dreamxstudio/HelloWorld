using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HelloWorld
{
    public class MainCycle
    {
        static MainCycle instance = null;

        public static string CNBETA_URL = "http://www.cnbeta.com";
        public static string RE_TITLE = "<div class=\"title\">[^<]*<a target=\"_blank\" href=\"(.*)\">(.*)</a>[^<]*<div class=\"tj\">[^<]*<span>[^<]*<em>(.*)</em>[\\s\\S]*?src=\"(.*)\"[^<]*</a></div></div><span class=\"newsinfo\"><p>(.*)</p></span>";
        public static string RE_CONTENT = "<div class=\"articleCont\">(.*)</div>";

        public static Brush LatestColor = Brushes.WhiteSmoke;
        public static double LabelOpacity = 1;

        public List<LabelProperty> LabelList = new List<LabelProperty>();
        public List<LabelProperty> ClosedList = new List<LabelProperty>();
        public Dictionary<string, LabelView> ViewDic = new Dictionary<string, LabelView>();

        public static int TopY = -100;
        public static int LabelWidth = 400;
        public static int LabelMargin = 2;

        public static Brush[] ColorArray = new Brush[] { Brushes.Purple, Brushes.Gray, Brushes.DeepSkyBlue, Brushes.ForestGreen, Brushes.Navy, Brushes.DarkOrange };

        public bool IsDrawing = false;

        //public static bool IsFirstTimeRun = true;

        public static MainCycle Instance()
        {
            if (instance == null)
                instance = new MainCycle();
            return instance;
        }

        private MainCycle()
        { 
        }

        int colorIndex = 0;

        public Brush GetRandomBrush( int idx = -1)
        {
            //return Brushes.Violet;
            //long tick = DateTime.Now.Ticks;
            //Random r1 = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            //return ColorArray[r1.Next() % ColorArray.Length];

            if (idx != -1 && idx >= 0 && idx < ColorArray.Length)
                return ColorArray[idx];
            else if(idx>=ColorArray.Length)
            {
                return ColorArray[idx % ColorArray.Length];
            }

            if (colorIndex == ColorArray.Length)
                colorIndex = 0; 

            return ColorArray[colorIndex++]; 
        }

        public void Activate()
        {
             if (LabelList == null || LabelList.Count() == 0)
                return;

            var latest = LabelList.FirstOrDefault(); 

            if(ViewDic.ContainsKey(latest.Url))
            {
                var view = ViewDic[latest.Url];
                if (view.Top + view.Height + LabelMargin > Y + WorkAreaH)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        Display(LabelList);
                    }));
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ViewDic[latest.Url].Topmost = true;
                        ViewDic[latest.Url].ActivateIt(false);
                        //ViewDic[latest].Activate();
                    }));
                } 
            }
        }

        public string RemoveHtmlLabel(string html)
        {
            for(; html.Contains("<");)
            {
                int leftIdx = html.IndexOf('<');
                string text = "";
                for(int i=leftIdx;i<html.Length;++i)
                {
                    text += html[i];
                    if (html[i] == '>')
                        break;
                }

                html = html.Replace(text, "");
            }

            html = html.Replace(@"&nbsp;", @"");

            return html;
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object obj)
            {
                for (; true ;)
                {
                    if (IsDrawing)
                        continue;

                    try {

                        WebClient wc = new WebClient();
                        byte[] data = wc.DownloadData(CNBETA_URL);
                        wc.Dispose();
                        wc = null;

                        if (data != null)
                        {
                            string content = System.Text.Encoding.UTF8.GetString(data);

                            Regex re = new Regex(RE_TITLE);
                            MatchCollection matches = re.Matches(content);

                            System.Collections.IEnumerator enu = matches.GetEnumerator();

                            List<LabelProperty> parsedPropertyList = new List<LabelProperty>();

                            while (enu.MoveNext() && enu.Current != null)
                            {
                                Match match = (Match)(enu.Current);

                                string url = CNBETA_URL + match.Groups[1].Value;
                                url = url.Replace("http://www.cnbeta.com/articles/", "http://m.cnbeta.com/view_");

                                if (LabelList.Any(m => m.Url == url))
                                    continue;

                                if (ClosedList.Any(m => m.Url == url))
                                    continue;

                                string title = RemoveHtmlLabel(match.Groups[2].Value);
                                string dateStr = match.Groups[3].Value;
                                DateTime dt = DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                                string icon = match.Groups[4].Value;
                                string desc = RemoveHtmlLabel(match.Groups[5].Value);

                                var labelProperty = ComposeLabel(icon, title, desc, url, dt);

                                parsedPropertyList.Add(labelProperty);
                            }

                            foreach(var label in parsedPropertyList)
                            {
                                if(wc!=null)
                                {
                                    wc.CancelAsync();
                                    wc.Dispose();
                                    wc = null;
                                }

                                wc = new WebClient();
                                byte[] content_data = wc.DownloadData(label.Url);

                                string content_data_str = System.Text.Encoding.UTF8.GetString(content_data);

                                Regex re_content = new Regex(RE_CONTENT);

                                MatchCollection content_matches = re_content.Matches(content_data_str);

                                IEnumerator it = content_matches.GetEnumerator();

                                List<string> parsedParaList = new List<string>();

                                while (it.MoveNext() && it.Current != null)
                                {
                                    Match match = (Match)(it.Current);
                                     
                                    parsedParaList.Add(match.Groups[1].Value); 
                                }

                                List<string> processedList = new List<string>() { label.Desc +"\n"};

                                foreach (var para in parsedParaList)
                                {
                                    string temp = para.Replace("<p>","|");
                                    temp = temp.Replace("</p>", "|"); 
                                    temp = temp.Replace("src=\"", "|");
                                    temp = temp.Replace(".jpg\"", ".jpg|");
                                    temp = temp.Replace(".png\"", ".png|");

                                    for (; temp.Contains("<") && temp.Contains(">");)
                                    {
                                        int s = temp.IndexOf("<");
                                        string substr = "";
                                        for(int i=s;i<temp.Length;++i)
                                        {
                                            if (temp[i] == '|')
                                                break;

                                            substr += temp[i];
                                            if (temp[i] == '>')
                                            {
                                                break;
                                            }
                                        }
                                        temp = temp.Replace(substr, "");
                                    } 

                                    var arr = temp.Split('|').Where(m=>m.Trim()!="" &&(!m.Contains("<") && !m.Contains(">"))).ToList();

                                    foreach (var str in arr)
                                    {
                                        if (!str.StartsWith("http://") && str.EndsWith(".jpg"))
                                            continue;

                                        if (!str.StartsWith("http://") && str.EndsWith(".png"))
                                            continue;

                                        var newstr = RemoveHtmlLabel(str); 

                                        processedList.Add(newstr);
                                    }
                                }

                                label.Content = processedList.Distinct().ToList();
                            }

                            if (parsedPropertyList.Count() == 0)
                                continue;

                            bool NeedDisplay = false;

                            foreach(var lbl in parsedPropertyList)
                            {
                                if(!LabelList.Any(m=>m.Url == lbl.Url))
                                { 
                                    LabelList.Add(lbl);
                                    NeedDisplay = true;
                                }
                            }

                            LabelList = LabelList.OrderByDescending(m => m.DT).ToList();

                            if(NeedDisplay)
                            {
                                SystemSounds.Exclamation.Play();//.Beep.Play();
                                Application.Current.Dispatcher.Invoke(new Action(() =>
                                {
                                    Display(LabelList);
                                }));
                            }

                            //if (LabelList.Count() == 0 || LabelList.FirstOrDefault().Url != parsedPropertyList.FirstOrDefault().Url)
                            //{
                            //    LabelList = parsedPropertyList;
                            //    Application.Current.Dispatcher.Invoke(new Action(() =>
                            //    {
                            //        Display(LabelList); 
                            //    }));
                            //}

                            Thread.Sleep(5000);
                        }
                    }
                    catch(Exception ex)
                    { 
                        Thread.Sleep(2000);
                        continue;
                    }
                }
            }));
        }

        LabelProperty ComposeLabel(string icon,string title,string desc,string url,DateTime dt)
        {
            LabelProperty labelProperty = new LabelProperty();
            labelProperty.Icon   = icon;
            labelProperty.Title = title;
            labelProperty.Desc = desc;
            labelProperty.Url = url;
            labelProperty.DT = dt;
            return labelProperty;
        }

        bool CheckLabelInList(LabelProperty lblProperty)
        {
            return LabelList.Any(m => m.Url == lblProperty.Url);
        }

        public static double W = SystemParameters.PrimaryScreenWidth;
        public static double H = SystemParameters.PrimaryScreenHeight;
        public static double WorkAreaW = SystemParameters.WorkArea.Width;
        public static double WorkAreaH = SystemParameters.WorkArea.Height;
        public static double TrayHeight = H - WorkAreaH;
        public static double X = SystemParameters.WorkArea.X;
        public static double Y = SystemParameters.WorkArea.Y;
        public static double TopLeftX = X + WorkAreaW - LabelWidth - 30 - LabelMargin;
        
        void Display(List<LabelProperty> lbls,double offset = 0.0f)
        {
            IsDrawing = true;

            LabelView.EnableHide();

            double CurrentY = WorkAreaH + offset;
             
            foreach(var i in ClosedList)
            {
                if(ViewDic.ContainsKey(i.Url))
                {
                    var item = ViewDic[i.Url];
                    ViewDic.Remove(i.Url);
                    item.Hide();
                    item.Close(); 
                }
            }

            for(int i= 0;i<lbls.Count();++i)
            {
                var prop = lbls[i];

                bool IsAlreadyShown = false;

                if (CurrentY <= TopY)
                {
                    if (ViewDic.ContainsKey(prop.Url))
                    {
                        var item = ViewDic[prop.Url];
                        ViewDic.Remove(prop.Url);
                        item.Hide();
                        item.Close(); 
                    } 
                }
                else
                {
                    LabelView view = null;

                    if (ViewDic.ContainsKey(prop.Url))
                    {
                        view = ViewDic[prop.Url];
                        IsAlreadyShown = true;
                    }
                    else
                    {
                        IsAlreadyShown = false;
                        view = new LabelView(LabelWidth);
                        view.Owner = Application.Current.Windows.OfType<HoverMainWindow>().FirstOrDefault();
                        view.TitleClicked += View_TitleClicked;
                        view.MouseWheel += View_MouseWheel;
                        view.MouseEnter += View_MouseEnter;
                        view.MouseMove += view_MouseMove;
                        view.MouseLeave += View_MouseLeave;
                        view.MouseRightButtonUp += View_MouseRightButtonUp;
                        //new Thickness(LabelMargin,LabelMargin,LabelMargin,0),
                        //new Thickness(LabelMargin,0,LabelMargin,LabelMargin));

                        if (i == 0)
                        {
                            //view.Background = LatestColor;
                            view.Topmost = true;
                            view.Activate();
                        }
                        else
                        {
                            //BitmapImage bitmap=new BitmapImage(new Uri("C:/lbbk2.png"));
                            //ImageBrush brush = new ImageBrush();
                            //brush.ImageSource = bitmap;
                            //view.Background = Brushes.SteelBlue;// GetRandomBrush(lbls.Count() - i - 1);
                        }

                        view.SetSource(prop);

                        ViewDic[prop.Url] = view;
                    }

                    if (i == 0)
                    {
                        view.Background = LatestColor; 
                    }
                    else
                    {
                        //BitmapImage bitmap=new BitmapImage(new Uri("C:/lbbk2.png"));
                        //ImageBrush brush = new ImageBrush();
                        //brush.ImageSource = bitmap;
                        view.Background = Brushes.SteelBlue;// GetRandomBrush(lbls.Count() - i - 1);
                    }

                    CurrentY = CurrentY - (view.Height + LabelMargin);

                    if (CurrentY <= TopY)
                    {
                        var item = ViewDic[prop.Url];
                        ViewDic.Remove(prop.Url);
                        item.Hide();
                        item.Close();
                        //ViewDic[prop.Url].Close();
                        //ViewDic.Remove(prop.Url);
                    }
                    else
                    {
                        view.Left = TopLeftX;
                        view.Top = CurrentY;  
                    }
                }
            }

            LabelView.DisableHide();

            Application.Current.Windows.OfType<HoverMainWindow>().FirstOrDefault().MoveLeft();

            foreach (var dic in ViewDic)
            {
                dic.Value.ActivateIt(true); 
                dic.Value.Show();
            }

            IsDrawing = false;
        }

        void view_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LabelView.EnableVisible();
        }

        private void View_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var view = (sender as LabelView);
            if(ViewDic.ContainsKey(view.Property.Url))
            {
                ViewDic[view.Property.Url].Close();
                ViewDic.Remove(view.Property.Url);
                LabelList.Remove(view.Property);
                ClosedList.Add(view.Property);

                Display(LabelList);
            }
        }

        bool IsScrolling = false;

        private void View_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            IsScrolling = true;

            var latestLabel = LabelList.FirstOrDefault();
            if (latestLabel == null)
                return;

            var latestView = ViewDic[latestLabel.Url];

            double offset = (latestView.Top + latestView.Height + LabelMargin + e.Delta / 10.0) - (Y + WorkAreaH);

            if (offset < 0) 
            {
                Display(LabelList); 
                return;
            }

            foreach(var dic in ViewDic)
            {
                dic.Value.Top += e.Delta/10.0;
            }

            Display(LabelList,offset); 
        }

        public void Hide()
        {
            foreach(var dic in ViewDic)
            {
                dic.Value.Opacity = 0; 
            }
        }

        WebView webView = null;

        private void View_TitleClicked(object arg1, LabelProperty arg2)
        {
            var lblView = arg1 as LabelView;

            if(webView != null)
            {
                webView.Close();  
                webView = null;
            }

            webView = new WebView();

            if (lblView.Background == LatestColor)
            {
                webView.Foreground = Brushes.Black;
                webView.Background = LatestColor;
            }
            else
            {
                webView.Foreground = Brushes.Black;
                webView.Background = Brushes.Azure;
            }
 
            webView.Opacity = 0.98;
            webView.text_title.Height = lblView.text_title.Height+10;
             
            webView.Left = TopLeftX;
            webView.Top = SystemParameters.WorkArea.Top + LabelMargin;
            webView.Width = lblView.Width;
            webView.Height = WorkAreaH - 2* LabelMargin;

            webView.SetSource(arg2);

            webView.Closing += WebView_Closing;
            webView.Closed += WebView_Closed;
            webView.Owner = Application.Current.Windows.OfType<HoverMainWindow>().FirstOrDefault();
            
            
            LabelView.EnableHide();
            HideLabels();
            webView.Show();
        }

        private void WebView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LabelView.DisableHide();
            ShowLabels();
        }

        private void WebView_Closed(object sender, EventArgs e)
        { 
            webView = null;
        }

        public void HideLabels()
        {
            IsDrawing = true;
            foreach (var dic in ViewDic)
            {
                dic.Value.Topmost = true;
                dic.Value.ActivateIt(true);
            }
            IsDrawing = false;
        }

        public void ShowLabels()
        {
            IsDrawing = true;
             
            foreach (var dic in ViewDic)
            {
                dic.Value.Topmost = true;
                dic.Value.ActivateIt(false);
            }
            
            IsDrawing = false;
        }

        private void View_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LabelView.DisableVisible();
            HideLabels();
        }

        private void View_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        { 
            ShowLabels();
        }

        public void Refresh()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Display(LabelList);
            }));
        }
    }
}
