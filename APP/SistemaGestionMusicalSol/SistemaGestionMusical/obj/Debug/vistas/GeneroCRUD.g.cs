#pragma checksum "..\..\..\vistas\GeneroCRUD.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF4771F42825D2B0CCDD1745EE5FAB68FB9A28EDC02DC14A36EE943CE7B8D167"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using SistemaGestionMusical.vistas;
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


namespace SistemaGestionMusical.vistas {
    
    
    /// <summary>
    /// GeneroCRUD
    /// </summary>
    public partial class GeneroCRUD : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\vistas\GeneroCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgGeneros;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\vistas\GeneroCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\vistas\GeneroCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnActualizar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\vistas\GeneroCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\vistas\GeneroCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegresar;
        
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
            System.Uri resourceLocater = new System.Uri("/SistemaGestionMusical;component/vistas/generocrud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\vistas\GeneroCRUD.xaml"
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
            this.dgGeneros = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\vistas\GeneroCRUD.xaml"
            this.dgGeneros.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgGeneros_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAgregar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\vistas\GeneroCRUD.xaml"
            this.btnAgregar.Click += new System.Windows.RoutedEventHandler(this.BtnAgregar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnActualizar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\vistas\GeneroCRUD.xaml"
            this.btnActualizar.Click += new System.Windows.RoutedEventHandler(this.BtnActualizar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\vistas\GeneroCRUD.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.BtnEliminar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRegresar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\vistas\GeneroCRUD.xaml"
            this.btnRegresar.Click += new System.Windows.RoutedEventHandler(this.BtnRegresar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

