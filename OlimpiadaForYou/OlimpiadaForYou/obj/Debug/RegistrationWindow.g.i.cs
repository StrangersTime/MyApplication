﻿#pragma checksum "..\..\RegistrationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8ADB25CAED1F7B51646CE218F234A6F9903C5DFD6950829E0F5597E6B073517C"
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
    /// RegistrationWindow
    /// </summary>
    public partial class RegistrationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Surname;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Name;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Patronymic;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Login;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Password;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_DateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Registration;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\RegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_Return;
        
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
            System.Uri resourceLocater = new System.Uri("/OlimpiadaForYou;component/registrationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistrationWindow.xaml"
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
            this.tb_Surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 92 "..\..\RegistrationWindow.xaml"
            this.tb_Surname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tb_Surname_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 94 "..\..\RegistrationWindow.xaml"
            this.tb_Name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tb_Name_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_Patronymic = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\RegistrationWindow.xaml"
            this.tb_Patronymic.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tb_Patronymic_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tb_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dp_DateOfBirth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.But_Registration = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\RegistrationWindow.xaml"
            this.But_Registration.Click += new System.Windows.RoutedEventHandler(this.But_Registration_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tb_Return = ((System.Windows.Controls.TextBlock)(target));
            
            #line 106 "..\..\RegistrationWindow.xaml"
            this.tb_Return.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.tb_Return_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

