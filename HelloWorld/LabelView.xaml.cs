using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Data;
using System.Linq;

namespace HelloWorld
{
    public partial class LabelView : Window
    { 
        public LabelProperty Property;

        public bool IsExpand = true;

        public bool IsFadingAway = true;

        System.Windows.Forms.Timer tmr = null;

        public event Action<object, LabelProperty> TitleClicked;

        public LabelView(int width)//,Thickness top_spacing,Thickness content_spacing)
        {
            InitializeComponent();

            this.Width = width;
            this.stk_content.Width = width; 
             
            this.Closed += LabelView_Closed;
 
            //this.stk_content.Margin = content_spacing;
            //this.stk_top.Margin = top_spacing;

            ShowInTaskbar = false; 

            InitUI();
        } 

        private void LabelView_Closed(object sender, EventArgs e)
        {
            if(tmr!=null)
            {
                tmr.Stop();
                tmr.Dispose();
                tmr = null;
            } 
        } 
 
        public void ActivateIt(bool isFadingAway)
        {
            if(Background == MainCycle.LatestColor)
            {
                this.Foreground = Brushes.Red;
            }
            else
            {
                this.Foreground = Brushes.White;
            }

            IsFadingAway = isFadingAway;
            if (tmr != null)
            {
                tmr.Tick -= Tmr_Tick;
                tmr.Stop();
                tmr.Dispose();
            }

            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 10;
            tmr.Tick += Tmr_Tick;
            tmr.Start();
        }

        protected static bool KeepShown = false;
        protected static bool KeepHide = false;

        public static void EnableVisible()
        {
            KeepShown = true;
            KeepHide = false;
        }

        public static void DisableVisible()
        {
            KeepShown = false;
        }

        public static void EnableHide()
        {
            KeepHide = true;
            KeepShown = false;
        }

        public static void DisableHide()
        {
            KeepHide = false;
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            if(KeepShown)
            {
                this.Opacity = 1.0;
                return;
            }

            if (KeepHide)
            {
                this.Opacity = 0;
                return;
            }

            if (IsFadingAway)
            {
                if (this.Opacity > 0.8)
                {
                    if (Background == MainCycle.LatestColor)
                        this.Opacity -= 0.0002;
                    else
                        this.Opacity -= 0.001;
                }
                else
                    this.Opacity -= 0.01;

                if (this.Opacity <= 0.5)
                {
                    if (Background == MainCycle.LatestColor)
                    {
                        if (this.Opacity <= 0)
                        {
                            Application.Current.Windows.OfType<HoverMainWindow>().First().MoveRight();
                            this.Opacity = 0;
                            tmr.Stop();
                            tmr.Dispose();
                            tmr = null;
                            return;
                        }

                        this.Opacity += 0.008; 
                    }
                    else
                    {
                        if (this.Opacity <= 0)
                        {
                            this.Opacity = 0;
                           
                            //this.Topmost = false;
                            tmr.Stop();
                            tmr.Dispose();
                            tmr = null;
                        }
                    }
                } 
                else
                {
                    this.Topmost = true;
                }
            }
            else
            { 
                this.Opacity += 0.1;

                if(this.Background == MainCycle.LatestColor)
                {
                    if (this.Opacity >= MainCycle.LabelOpacity)
                    {
                        this.Opacity = MainCycle.LabelOpacity;
                        this.Topmost = true;
                        tmr.Stop();
                        tmr.Dispose();
                        tmr = null;
                    }
                }
                else
                {
                    if (this.Opacity >= 1)
                    {
                        this.Opacity = 1;
                        this.Topmost = true;
                        tmr.Stop();
                        tmr.Dispose();
                        tmr = null;
                    }
                } 
            }
        }

        void InitUI()
        {
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.FontFamily = new FontFamily(@"Microsoft Yahei");
            this.Background = Brushes.BlueViolet;
            this.Foreground = Brushes.White;
            this.text_desc.Visibility = IsExpand ? Visibility.Visible : Visibility.Collapsed;
            text_desc.TextWrapping = TextWrapping.Wrap;
            text_title.TextWrapping = TextWrapping.Wrap;
        }

        protected void MeasureUI()
        {
            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            //bi3.UriSource = new Uri(Property.Icon, UriKind.RelativeOrAbsolute);
            //bi3.CacheOption = BitmapCacheOption.OnLoad;
            //bi3.EndInit();

            //img_icon.Source = bi3;

            TextBlock tb = new TextBlock();
            
            tb.TextWrapping = TextWrapping.Wrap;

            tb.FontFamily = text_title.FontFamily;
            tb.FontSize = text_title.FontSize;
            tb.FontWeight = text_title.FontWeight;
            tb.Text = Property.Title;
            tb.Measure(new Size(this.stk_content.Width, Double.PositiveInfinity));
            text_title.Width = this.stk_content.Width;
            text_title.Height = tb.DesiredSize.Height+10;

            tb.FontFamily = text_desc.FontFamily;
            tb.FontSize = text_desc.FontSize;
            tb.FontWeight = text_desc.FontWeight;
            tb.Text = Property.Desc;
            tb.Measure(new Size(this.stk_content.Width, Double.PositiveInfinity));
            text_desc.Width = this.stk_content.Width;
            text_desc.Height = tb.DesiredSize.Height + 10;

            Redraw();
        }

        public void Redraw()
        {
            this.Height = text_title.Height + (IsExpand ? text_desc.Height : 0) + (IsExpand ? 20 : 10);
            
            this.Width = this.stk_content.Width + 30;
            
            this.text_desc.Visibility = IsExpand ? Visibility.Visible : Visibility.Collapsed;

            //UpdateLayout(); 
        } 

        public void SetSource(LabelProperty prop)
        {
            if (prop == null)
                return;

            Property = prop;
 
            this.DataContext = Property;

            MeasureUI();
        }

        private void text_title_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //text_title.Foreground = Brushes.Black;
            text_title.TextDecorations = TextDecorations.Underline;
            this.Cursor = Cursors.Hand; 
        }

        private void text_title_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //text_title.Foreground = this.Foreground;
            text_title.TextDecorations = null;// TextDecorations.OverLine;
            this.Cursor = Cursors.Arrow;
        }

        private void text_title_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TitleClicked != null)
                TitleClicked(this, Property);
        }
    }
}
