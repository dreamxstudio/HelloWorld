﻿#pragma checksum "..\..\LabelView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "827433C392C05D51A66E978DFDC2064A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HelloWorld;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace HelloWorld {
    
    
    /// <summary>
    /// LabelView
    /// </summary>
    public partial class LabelView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\LabelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid maingrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\LabelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stk_top;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\LabelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_title;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\LabelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stk_content;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\LabelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_desc;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HelloWorld;component/labelview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LabelView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.maingrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.stk_top = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.text_title = ((System.Windows.Controls.TextBlock)(target));
            
            #line 18 "..\..\LabelView.xaml"
            this.text_title.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.text_title_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 19 "..\..\LabelView.xaml"
            this.text_title.MouseEnter += new System.Windows.Input.MouseEventHandler(this.text_title_MouseEnter);
            
            #line default
            #line hidden
            
            #line 19 "..\..\LabelView.xaml"
            this.text_title.MouseLeave += new System.Windows.Input.MouseEventHandler(this.text_title_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stk_content = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.text_desc = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
