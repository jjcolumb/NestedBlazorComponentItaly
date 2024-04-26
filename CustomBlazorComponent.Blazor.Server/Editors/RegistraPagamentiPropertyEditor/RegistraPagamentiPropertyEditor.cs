using CustomBlazorComponent.Blazor.Server.Editors.AcquistoArtcoliPropertyEditor;
using CustomBlazorComponent.Module.BusinessObjects;
using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace CustomBlazorComponent.Blazor.Server.Editors.RegistraPagamentiPropertyEditor
{
    [PropertyEditor(typeof(string), "PersonnePropertyEditor", false)]
    public class RegistraPagamentiPropertyEditor : BlazorPropertyEditorBase, IComplexViewItem
    {
        BlazorApplication Application;
        IObjectSpace ObjectSpace;
        public RegistraPagamentiPropertyEditor(Type objectType, IModelMemberViewItem info)
                : base(objectType, info)
        {

        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            Application = application as BlazorApplication;
            ObjectSpace = objectSpace;
        }
        protected override IComponentAdapter CreateComponentAdapter() => new RegistraPagamentiAdapter(new RegistraPagamentiModel());
        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            if (Control is RegistraPagamentiAdapter control)
            {
                control.ComponentModel.Persona = CurrentObject as Persona;
                control.ComponentModel.ObjectSpace = ObjectSpace;
            }

        }
    }
}
