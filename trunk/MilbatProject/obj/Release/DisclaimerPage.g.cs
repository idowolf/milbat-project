﻿#pragma checksum "c:\users\ido\documents\visual studio 2012\Projects\MilbatProject\MilbatProject\DisclaimerPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8E48AA4D708FD1E4FFDB65D5519FF27E"
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
    
    
    public partial class DisclaimerPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton SaveButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Return;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.CheckBox UserDisclaimerSign;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MilbatProject;component/DisclaimerPage.xaml", System.UriKind.Relative));
            this.SaveButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("SaveButton")));
            this.Return = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Return")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.UserDisclaimerSign = ((System.Windows.Controls.CheckBox)(this.FindName("UserDisclaimerSign")));
        }
    }
}
