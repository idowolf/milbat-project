﻿#pragma checksum "C:\Users\Ido\documents\visual studio 2013\Projects\MilbatProject\MilbatProject\RoomPropertiesPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AE920A558FD059DFFA386847D993D482"
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
    
    
    public partial class RoomPropertiesPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox name;
        
        internal System.Windows.Controls.TextBox room;
        
        internal System.Windows.Controls.TextBlock rooom_block;
        
        internal System.Windows.Controls.TextBlock name_block;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MilbatProject;component/RoomPropertiesPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.name = ((System.Windows.Controls.TextBox)(this.FindName("name")));
            this.room = ((System.Windows.Controls.TextBox)(this.FindName("room")));
            this.rooom_block = ((System.Windows.Controls.TextBlock)(this.FindName("rooom_block")));
            this.name_block = ((System.Windows.Controls.TextBlock)(this.FindName("name_block")));
        }
    }
}

