﻿#pragma checksum "..\..\..\PawnPromotion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A1867CBA0CE2BC3D641F8276D8B6ECE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ChessPresenter {
    
    
    /// <summary>
    /// PawnPromotion
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class PawnPromotion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\PawnPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SlcRook;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\PawnPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SlcKnight;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\PawnPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SlcBishop;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\PawnPromotion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SlcQueen;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/ChessPresenter;component/pawnpromotion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PawnPromotion.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SlcRook = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\..\PawnPromotion.xaml"
            this.SlcRook.Click += new System.Windows.RoutedEventHandler(this.SlcRook_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SlcKnight = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\PawnPromotion.xaml"
            this.SlcKnight.Click += new System.Windows.RoutedEventHandler(this.SlcKnight_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SlcBishop = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\PawnPromotion.xaml"
            this.SlcBishop.Click += new System.Windows.RoutedEventHandler(this.SlcBishop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SlcQueen = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\PawnPromotion.xaml"
            this.SlcQueen.Click += new System.Windows.RoutedEventHandler(this.SlcQueen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

