using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{ 
    public partial class HoverMainWindow : Window
    {
        System.Windows.Forms.Timer tmr = null;
        
        public bool IsFadingAway = true;

        public HoverMainWindow()
        {
            InitializeComponent();
            
            this.Topmost = true;
            this.AllowsTransparency = true;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ShowInTaskbar = false;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Background = Brushes.Transparent;
            this.LostFocus += HoverMainWindow_LostFocus;
            double W = SystemParameters.PrimaryScreenWidth;
            double H = SystemParameters.PrimaryScreenHeight;
            double WorkAreaW = SystemParameters.WorkArea.Width;
            double WorkAreaH = SystemParameters.WorkArea.Height;
            double TrayHeight = H - WorkAreaH;
            double X = SystemParameters.WorkArea.X;
            double Y = SystemParameters.WorkArea.Y;

            this.Left = X + WorkAreaW - this.Width-5;
            this.Top = Y + WorkAreaH - this.Height-5;

            this.MouseEnter += HoverMainWindow_MouseEnter;
            this.MouseLeave += HoverMainWindow_MouseLeave;

            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 10;
            tmr.Tick += tmr_Tick; 
           
            ActivateIt(true);

            this.Closed += HoverMainWindow_Closed;
        }
 
        private void HoverMainWindow_Closed(object sender, EventArgs e)
        {
            if(tmr!=null)
            {
                tmr.Stop();
                tmr.Dispose();
                tmr = null;
            }
        }

        private void HoverMainWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            ActivateIt(true);
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (IsFadingAway)
            {
                if (viewboxAnimUI.Opacity > 0.9)
                    viewboxAnimUI.Opacity -= 0.001;
                else
                    viewboxAnimUI.Opacity -= 0.01;

                if (viewboxAnimUI.Opacity <= 0.5)
                {  
                    tmr.Stop(); 
                }
            }
            else
            {
                viewboxAnimUI.Opacity += 0.1;

                if (viewboxAnimUI.Opacity >= 1)
                {
                    tmr.Stop();
                }
            }
        } 

        void HoverMainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
             
        }

        void HoverMainWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        public void ActivateIt(bool isFadingAway)
        {
            IsFadingAway = isFadingAway;
            tmr.Start();
        }

        public bool IsMoving = false;

        private void viewboxAnimUI_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IsMoving)
                return;

            MoveLeft();

            ActivateIt(false);

            MainCycle.Instance().Activate(); 
        }

        public void MoveLeft()
        {
            IsMoving = true;

            Point pt = new Point();
            pt.X = SystemParameters.WorkArea.X + SystemParameters.WorkArea.Width - this.Width - MainCycle.LabelWidth - 2 * MainCycle.LabelMargin - 5 - 30;
            pt.Y = this.Top;

            moveTo(pt); 
        }

        public void MoveRight()
        {
            IsMoving = true;

            Point pt = new Point();
            pt.X = SystemParameters.WorkArea.X + SystemParameters.WorkArea.Width - this.Width - MainCycle.LabelMargin;
            pt.Y = this.Top;

            moveTo(pt);
        }

        private void viewboxAnimUI_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IsMoving)
                return; 

            ActivateIt(true);  
        }

        private void viewboxAnimUI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //MainCycle.Instance().Refresh();
            if (IsMoving)
                return;

            MainCycle.Instance().Hide();
            MoveRight();
        }

        private void moveTo(Point deskPoint)
        {
            //Point p = e.GetPosition(body); 

            Point curPoint = new Point();
            curPoint.X = Canvas.GetLeft(this);
            curPoint.Y = Canvas.GetTop(this);

            double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));

            double _secNumber = (_s / 1000) * 500;

            Storyboard storyboard = new Storyboard();
            storyboard.Completed += Storyboard_Completed;
            //创建X轴方向动画 

            DoubleAnimation doubleAnimation = new DoubleAnimation(

              Canvas.GetLeft(this),

              deskPoint.X,

              new Duration(TimeSpan.FromMilliseconds(_secNumber))

            );
            Storyboard.SetTarget(doubleAnimation, this);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            //创建Y轴方向动画 

            doubleAnimation = new DoubleAnimation(
              Canvas.GetTop(this),
              deskPoint.Y,
              new Duration(TimeSpan.FromMilliseconds(_secNumber))
            );
            Storyboard.SetTarget(doubleAnimation, this);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);
            
            //动画播放 

            storyboard.Begin();
           
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            IsMoving = false;
        }
    }
}
