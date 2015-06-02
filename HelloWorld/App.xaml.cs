using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq; 
using System.Windows;

namespace HelloWorld
{
    public partial class App : Application
    { 
        protected override void OnStartup(StartupEventArgs e)
        {
            HoverMainWindow hoverWnd = new HoverMainWindow();
            hoverWnd.Show();
            MainCycle.Instance().Run(); 
        }
    }
}
