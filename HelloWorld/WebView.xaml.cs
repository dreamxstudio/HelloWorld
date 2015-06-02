using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HelloWorld
{
    public partial class WebView : Window
    {
        public WebView()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None; 
            this.AllowsTransparency = true;
            this.text_title.TextWrapping = TextWrapping.Wrap;
            this.text_title.TextAlignment = TextAlignment.Center;
            this.text_title.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            this.MouseLeftButtonUp += WebView_MouseLeftButtonUp;
        }

        private void WebView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public void SetSource(LabelProperty prop)
        { 
            DataContext = prop;
            Property = prop;
            GenContent();
        } 

        void GenContent()
        {
            if (Property == null)
                return; 
                                
            var lst = Property.Content;
            foreach(var item in lst)
            {
                if((item.StartsWith("http://") && item.EndsWith(".jpg")) ||
                    item.StartsWith("http://") && item.EndsWith(".png"))
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(item, UriKind.RelativeOrAbsolute);
                    bi3.CacheOption = BitmapCacheOption.OnLoad;
                    bi3.EndInit();

                    Image img = new Image();
                    img.Stretch = Stretch.UniformToFill;
                    img.Width = this.Width - 4;
                    img.Source = bi3;
                    img.Margin = new Thickness(2, 20,2, 20);

                    stk_content.Children.Add(img);
                } 
                else if(item.StartsWith("http://"))
                {
                    TextBlock tb = new TextBlock();
                    tb.TextWrapping = TextWrapping.Wrap;
                    //tb.Text = item;
                    tb.Measure(new Size(this.Width, Double.PositiveInfinity));
                    tb.Width = this.Width - 40;
                    tb.Height = tb.DesiredSize.Height + 20;
                    tb.FontSize = 13; 

                    tb.Inlines.Clear();
                    //tb.Inlines.Add(item);
                    Hyperlink hyperLink = new Hyperlink()
                    {
                        NavigateUri = new Uri(item)
                    };

                    hyperLink.Inlines.Add(item);
                    hyperLink.RequestNavigate += HyperLink_RequestNavigate;
                    tb.Inlines.Add(hyperLink);
                    //tb.Inlines.Add(item);
                    tb.Margin = new Thickness(20, 0, 20, 0);
                    stk_content.Children.Add(tb);
                }
                else
                {
                    TextBlock tb = new TextBlock();
                    tb.TextWrapping = TextWrapping.Wrap;
                    tb.Text = "    "+item;
                    tb.Measure(new Size(this.Width, Double.PositiveInfinity));
                    tb.Width = this.Width - 40;
                    tb.Height = tb.DesiredSize.Height + 20;
                    tb.FontSize = 13;
                    tb.Margin = new Thickness(20, 0, 20, 0);
                    stk_content.Children.Add(tb);
                }
            }
        }

        private void HyperLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        public LabelProperty Property;
    }
}
