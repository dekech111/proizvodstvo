﻿#pragma checksum "..\..\..\View\PageViewIsp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CA07B0C0A88FCEAADE63E917C34EC6082A3A284AA7310323D373F40BEFC17D67"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Обработка_Заявок.View;


namespace Обработка_Заявок.View {
    
    
    /// <summary>
    /// PageViewIsp
    /// </summary>
    public partial class PageViewIsp : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCity;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewAll;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GridList;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRem;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\View\PageViewIsp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExcel;
        
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
            System.Uri resourceLocater = new System.Uri("/Обработка_Заявок;component/view/pageviewisp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PageViewIsp.xaml"
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
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\View\PageViewIsp.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbCity = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\View\PageViewIsp.xaml"
            this.cmbCity.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbVid_Yslg_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnViewAll = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\View\PageViewIsp.xaml"
            this.btnViewAll.Click += new System.Windows.RoutedEventHandler(this.btnViewAll_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GridList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnRem = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\View\PageViewIsp.xaml"
            this.btnRem.Click += new System.Windows.RoutedEventHandler(this.btnRem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\View\PageViewIsp.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnExcel = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\View\PageViewIsp.xaml"
            this.btnExcel.Click += new System.Windows.RoutedEventHandler(this.btnExcex_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

