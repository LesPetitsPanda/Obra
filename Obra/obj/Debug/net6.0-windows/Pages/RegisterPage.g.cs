﻿#pragma checksum "..\..\..\..\Pages\RegisterPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E3ADF82F8B711B088D1BA1E9EEBECF17B15133AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Obra.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Obra.Pages {
    
    
    /// <summary>
    /// RegisterPage
    /// </summary>
    public partial class RegisterPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernameBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupUsername;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pass;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupPassword;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBoxAgain;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupPasswordAgain;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pro;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Part;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupEmail;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button register;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Obra;component/pages/registerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RegisterPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Pages\RegisterPage.xaml"
            ((Obra.Pages.RegisterPage)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Popup_disabled);
            
            #line default
            #line hidden
            return;
            case 2:
            this.usernameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PopupUsername = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            this.pass = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.PopupPassword = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            this.PasswordBoxAgain = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.PopupPasswordAgain = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 9:
            this.emailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Pro = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Pages\RegisterPage.xaml"
            this.Pro.Click += new System.Windows.RoutedEventHandler(this.Pro_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Part = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Pages\RegisterPage.xaml"
            this.Part.Click += new System.Windows.RoutedEventHandler(this.Part_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.PopupEmail = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 13:
            this.register = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Pages\RegisterPage.xaml"
            this.register.Click += new System.Windows.RoutedEventHandler(this.Register_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

