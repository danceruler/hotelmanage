﻿#pragma checksum "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F94C36DAEBF931BB8CB187894E53D81BC3BDEE6"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManager.Views.FunctionWindow;
using Panuon.UI;
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
using System.Windows.Shell;


namespace HotelManager.Views.FunctionWindow {
    
    
    /// <summary>
    /// DataPickerWindow
    /// </summary>
    public partial class DataPickerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border titlebar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleText;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid closeicongrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image closeicon;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Panuon.UI.PUDatePicker datapicker;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Panuon.UI.PUTextBox timeString;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Panuon.UI.PUButton Confirm;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelManager;component/views/functionwindow/datapickerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
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
            this.titlebar = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.TitleText = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.closeicongrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.closeicon = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.datapicker = ((Panuon.UI.PUDatePicker)(target));
            return;
            case 6:
            this.timeString = ((Panuon.UI.PUTextBox)(target));
            return;
            case 7:
            this.Confirm = ((Panuon.UI.PUButton)(target));
            
            #line 42 "..\..\..\..\Views\FunctionWindow\DataPickerWindow.xaml"
            this.Confirm.Click += new System.Windows.RoutedEventHandler(this.Confirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

