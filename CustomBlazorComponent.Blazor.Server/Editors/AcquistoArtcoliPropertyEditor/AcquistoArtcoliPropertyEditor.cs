using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

namespace CustomBlazorComponent.Blazor.Server.Editors.AcquistoArtcoliPropertyEditor
{
    [PropertyEditor(typeof(string), "AcquistoArtcoliPropertyEditor", false)]
    public class AcquistoArtcoliPropertyEditor: BlazorPropertyEditorBase
    {
        public AcquistoArtcoliPropertyEditor(Type objectType, IModelMemberViewItem info)
            : base(objectType, info)
        {

        }
        protected override IComponentAdapter CreateComponentAdapter() => new AcquistoArticoliAdapter(new AcquistoArticoliModel());
        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            if (Control is AcquistoArticoliAdapter control)
            {
                control.ComponentModel.AcquistoArticoli = CurrentObject as AcquistoArticoli;
            }

        }
    }
}
