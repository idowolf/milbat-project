﻿#pragma checksum "C:\Users\Ido\Documents\Visual Studio 2013\Projects\MilbatProject\MilbatProject\WizardOutsideHousePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B87967B63660077236805D6223BE58C4"
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
    
    
    public partial class WizardOutsideHousePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PanoramaItem madregot;
        
        internal Microsoft.Phone.Controls.PanoramaItem yard;
        
        internal Microsoft.Phone.Controls.PanoramaItem elevator;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MilbatProject;component/WizardOutsideHousePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.madregot = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("madregot")));
            this.yard = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("yard")));
            this.elevator = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("elevator")));
        }
    }
}
