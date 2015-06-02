using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class LabelProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; OnPropertyChanged("Icon"); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        private string desc;
        public string Desc
        {
            get { return desc; }
            set { desc = value; OnPropertyChanged("Desc"); }
        }

        private List<string> content;
        public List<string> Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged("Content"); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value;OnPropertyChanged("Url"); }
        }

        private DateTime dt;
        public DateTime DT
        {
            get { return dt; }
            set { dt = value;OnPropertyChanged("DT"); }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
