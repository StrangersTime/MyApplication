﻿#pragma checksum "..\..\UserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B15FD858B6FEBA8EDB08EB92DD74F98A2D8F0435344B8ED01B924A6E12DC02E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using OlimpiadaForYou;
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


namespace OlimpiadaForYou {
    
    
    /// <summary>
    /// UserWindow
    /// </summary>
    public partial class UserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 94 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Return;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_Olimp;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Back;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Next;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_NumberOfPage;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock messageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_Reg;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_FIO;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_RotatedText;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\UserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Edit;
        
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
            System.Uri resourceLocater = new System.Uri("/OlimpiadaForYou;component/userwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserWindow.xaml"
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
            this.But_Return = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\UserWindow.xaml"
            this.But_Return.Click += new System.Windows.RoutedEventHandler(this.But_Return_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lv_Olimp = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.But_Back = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\UserWindow.xaml"
            this.But_Back.Click += new System.Windows.RoutedEventHandler(this.But_Back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.But_Next = ((System.Windows.Controls.Button)(target));
            
            #line 182 "..\..\UserWindow.xaml"
            this.But_Next.Click += new System.Windows.RoutedEventHandler(this.But_Next_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tb_NumberOfPage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.messageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tb_Reg = ((System.Windows.Controls.TextBlock)(target));
            
            #line 194 "..\..\UserWindow.xaml"
            this.tb_Reg.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.tb_Reg_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tb_FIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.tb_RotatedText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Edit = ((System.Windows.Controls.Image)(target));
            
            #line 212 "..\..\UserWindow.xaml"
            this.Edit.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Edit_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 152 "..\..\UserWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.But_Refuse_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
