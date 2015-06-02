using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    internal static class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            var app = new App();
            app.Run();
            return 0;
        }
    }
}


