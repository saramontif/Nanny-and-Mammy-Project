﻿#pragma checksum "..\..\Address.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D4DBA41F71D8B0EC7B117294FF4E70C6D715D826"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// Address
    /// </summary>
    public partial class Address : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\Address.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountryTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Address.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CityTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Address.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StreetTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Address.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Address.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ZipCodeTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/address.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Address.xaml"
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
            this.CountryTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\Address.xaml"
            this.CountryTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CityTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\Address.xaml"
            this.CityTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StreetTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\Address.xaml"
            this.StreetTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumberTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\Address.xaml"
            this.NumberTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ZipCodeTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\Address.xaml"
            this.ZipCodeTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\Address.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OKButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

