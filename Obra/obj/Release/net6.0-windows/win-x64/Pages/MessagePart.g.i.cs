﻿#pragma checksum "..\..\..\..\..\Pages\MessagePart.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CA9F9C5E4E54D95525F08AD9FD803C5C238F69A5"
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
    /// MessagePart
    /// </summary>
    public partial class MessagePart : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\..\..\Pages\MessagePart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer messages;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Pages\MessagePart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock content_messages;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Pages\MessagePart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox entermessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Obra;component/pages/messagepart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\MessagePart.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 22 "..\..\..\..\..\Pages\MessagePart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\..\..\Pages\MessagePart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Message_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 36 "..\..\..\..\..\Pages\MessagePart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 43 "..\..\..\..\..\Pages\MessagePart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsPart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.messages = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.content_messages = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.entermessage = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\..\..\..\Pages\MessagePart.xaml"
            this.entermessage.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
