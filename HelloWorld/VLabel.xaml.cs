using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
{
    public partial class VLabel : Window
    {
        public int DesignWidth;

        public VLabel(int width)
        {
            InitializeComponent();
            DesignWidth = width;
            this.Width = width;
            this.contentpanel.Width = DesignWidth;
            this.ShowInTaskbar = false;

            InitUI();
        }

        void InitUI()
        {
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.FontFamily = new FontFamily("Microsoft Yahei");
            text_desc.TextWrapping = TextWrapping.Wrap;
            text_title.TextWrapping = TextWrapping.Wrap;
        }

        int CalcRows(double totWidth,double designWidth)
        {
            if(totWidth/designWidth - (int)(totWidth/designWidth)>0.1)
            {
                return (int)(totWidth / designWidth) + 1;
            }

            return (int)(totWidth / designWidth);
        }

        void MeasureUI(LabelProperty prop)
        { 
            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            //bi3.UriSource = new Uri(prop.Icon, UriKind.RelativeOrAbsolute);
            //bi3.CacheOption = BitmapCacheOption.OnLoad;
            //bi3.EndInit();

            //img_icon.Source = bi3;

            text_title.Text = prop.Title;
            text_title.Measure(new Size(this.contentpanel.Width, Double.PositiveInfinity));
            text_title.Height = text_title.DesiredSize.Height;

            text_desc.Text = prop.Desc;
            text_desc.Measure(new Size(this.contentpanel.Width, Double.PositiveInfinity));
            text_desc.Height = text_desc.DesiredSize.Height;

            this.Height = text_title.Height + text_desc.Height;
        }
    
        public void SetSource(LabelProperty prop)
        {
            this.DataContext = prop;
            MeasureUI(prop);
        }
    }
}
