﻿#pragma checksum "C:\Users\Ido\Documents\Visual Studio 2013\Projects\MilbatProject\MilbatProject\QuestionsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4045580D548A2A27770AA8FF03FDEE7A"
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
using Microsoft.Phone.Shell;
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
    
    
    public partial class QuestionsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton NextButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton BackButton;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Primitives.ToggleButton yes;
        
        internal System.Windows.Controls.Primitives.ToggleButton no;
        
        internal System.Windows.Controls.Primitives.ToggleButton takin_helkit;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MilbatProject;component/QuestionsPage.xaml", System.UriKind.Relative));
            this.NextButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("NextButton")));
            this.BackButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("BackButton")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.yes = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("yes")));
            this.no = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("no")));
            this.takin_helkit = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("takin_helkit")));
        }
    }
}

