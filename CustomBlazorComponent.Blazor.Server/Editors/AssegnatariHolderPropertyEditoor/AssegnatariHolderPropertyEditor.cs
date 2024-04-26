using CustomBlazorComponent.Blazor.Server.Editors.RegistraPagamentiPropertyEditor;
using CustomBlazorComponent.Module.BusinessObjects;
using DevExpress.Blazor.Primitives.Internal;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Utils;

namespace CustomBlazorComponent.Blazor.Server.Editors.AssegnatariHolderPropertyEditoor
{
    [PropertyEditor(typeof(string), "AssegnatariHolderPropertyEditor", false)]
    public class AssegnatariHolderPropertyEditor : BlazorPropertyEditorBase, IComplexViewItem
    {
        BlazorApplication Application;
        IObjectSpace ObjectSpace;
        public AssegnatariHolderPropertyEditor(Type objectType, IModelMemberViewItem info)
                : base(objectType, info)
        {

        }

        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            Application = application as BlazorApplication;
            ObjectSpace = objectSpace;
        }
        protected override IComponentAdapter CreateComponentAdapter() => new AssegnataryHolderAdapter(new AssegnataryHolderModel());
        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            if (Control is AssegnataryHolderAdapter control)
            {
                control.ComponentModel.Movimenti = CurrentObject as Movimenti;
                control.ComponentModel.ObjectSpace = ObjectSpace;
                control.ComponentModel.Application = Application;
            }

        }
    }

    public class AssegnataryHolderModel : ComponentModelBase
    {
        public string Value
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public Movimenti Movimenti
        {
            get => GetPropertyValue<Movimenti>();
            set => SetPropertyValue(value);
        }

        public IObjectSpace ObjectSpace
        {
            get => GetPropertyValue<IObjectSpace>();
            set => SetPropertyValue(value);
        }

        public BlazorApplication Application
        {
            get => GetPropertyValue<BlazorApplication>();
            set => SetPropertyValue(value);
        }

        public EventCallback<string> ValueChanged
        {
            get => GetPropertyValue<EventCallback<string>>();
            set => SetPropertyValue(value);
        }
        public bool ReadOnly
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
    }


    public class AssegnataryHolderAdapter : ComponentAdapterBase
    {
        public AssegnataryHolderAdapter(AssegnataryHolderModel componentModel)
        {
            ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            ComponentModel.ValueChanged = EventCallback.Factory.Create<string>(this, value =>
            {
                componentModel.Value = value;
                RaiseValueChanged();
            });
        }
        public override AssegnataryHolderModel ComponentModel { get; }
        public override void SetAllowEdit(bool allowEdit)
        {
            ComponentModel.ReadOnly = !allowEdit;
        }
        public override object GetValue()
        {
            return ComponentModel.Value;
        }
        public override void SetValue(object value)
        {
            ComponentModel.Value = (string)value;
        }
        protected override RenderFragment CreateComponent()
        {
            return ComponentModelObserver.Create(ComponentModel, AssegnatariHolderRenderer.Create(ComponentModel));
        }
        private void ComponentModel_ValueChanged(object sender, EventArgs e) => RaiseValueChanged();
        public override void SetAllowNull(bool allowNull) { /* ...*/ }
        public override void SetDisplayFormat(string displayFormat) { /* ...*/ }
        public override void SetEditMask(string editMask) { /* ...*/ }
        public override void SetEditMaskType(EditMaskType editMaskType) { /* ...*/ }
        public override void SetErrorIcon(ImageInfo errorIcon) { /* ...*/ }
        public override void SetErrorMessage(string errorMessage) { /* ...*/ }
        public override void SetIsPassword(bool isPassword) { /* ...*/ }
        public override void SetMaxLength(int maxLength) { /* ...*/ }
        public override void SetNullText(string nullText) { /* ...*/ }
    }
}
