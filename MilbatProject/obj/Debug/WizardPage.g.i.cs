﻿#pragma checksum "C:\Users\Ido\documents\visual studio 2013\Projects\MilbatProject\MilbatProject\WizardPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A6FEDF3620F3A1D58FADA615FFEF650B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MilbatProject {
    
    
    public partial class DetailsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock question;
        
        internal System.Windows.Controls.Button Yesbutton;
        
        internal System.Windows.Controls.Button Nobutton;
        
        internal System.Windows.Controls.Button Unsurebutton;
        
        internal System.Windows.Controls.Button Nextbutton;
        
        internal System.Windows.Controls.Button Previousbutton;
        
        internal System.Windows.Controls.TextBlock suggestion;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MilbatProject;component/WizardPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.question = ((System.Windows.Controls.TextBlock)(this.FindName("question")));
            this.Yesbutton = ((System.Windows.Controls.Button)(this.FindName("Yesbutton")));
            this.Nobutton = ((System.Windows.Controls.Button)(this.FindName("Nobutton")));
            this.Unsurebutton = ((System.Windows.Controls.Button)(this.FindName("Unsurebutton")));
            this.Nextbutton = ((System.Windows.Controls.Button)(this.FindName("Nextbutton")));
            this.Previousbutton = ((System.Windows.Controls.Button)(this.FindName("Previousbutton")));
            this.suggestion = ((System.Windows.Controls.TextBlock)(this.FindName("suggestion")));
        }
    }
}
