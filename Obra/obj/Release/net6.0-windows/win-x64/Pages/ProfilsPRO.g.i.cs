﻿#pragma checksum "..\..\..\..\..\Pages\ProfilsPRO.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "891299F694A301DC3910EE9331AB32DD9435B165"
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
    /// ProfilsPRO
    /// </summary>
    public partial class ProfilsPRO : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 64 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSize;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxFont;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxColor;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtb_editor;
        
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
            System.Uri resourceLocater = new System.Uri("/Obra;component/pages/profilspro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
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
            
            #line 24 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 31 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Message_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 38 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsPart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 59 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.New_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 60 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 61 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Load_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 62 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ComboBoxSize = ((System.Windows.Controls.ComboBox)(target));
            
            #line 64 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            this.ComboBoxSize.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.ComboBoxSize_SelectionChanged));
            
            #line default
            #line hidden
            return;
            case 10:
            this.ComboBoxFont = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            this.ComboBoxFont.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxFont_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ComboBoxColor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            this.ComboBoxColor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxColor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.rtb_editor = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 70 "..\..\..\..\..\Pages\ProfilsPRO.xaml"
            this.rtb_editor.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rtb_editor_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

