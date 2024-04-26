using CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Movimenti;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Persona
{
    public class PersoneAggiugniButtonModel : ComponentModelBase
    {
        public string Text
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        public void ClickFromUI()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler Click;
    }


    public interface IPersoneAggiugniViewItem : IModelViewItem { }

    [ViewItem(typeof(IPersoneAggiugniViewItem))]
    public class PersoneAggiugniViewItem : ViewItem, IComplexViewItem
    {
        public class PersoneAggiugniButtonHolder : IComponentContentHolder
        {
            public PersoneAggiugniButtonHolder(PersoneAggiugniButtonModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public PersoneAggiugniButtonModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, PersoneAggiugniRenderer.Create(ComponentModel));
        }
        private XafApplication application;
        public PersoneAggiugniViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new PersoneAggiugniButtonHolder(new PersoneAggiugniButtonModel());
        protected override void OnControlCreated()
        {
            if (Control is PersoneAggiugniButtonHolder holder)
            {
                holder.ComponentModel.Text = "Aggiungi";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is PersoneAggiugniButtonHolder holder)
            {
                holder.ComponentModel.Click -= ComponentModel_Click;
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
        private void ComponentModel_Click(object sender, EventArgs e)
        {
            application.ShowViewStrategy.ShowMessage("Action is executed!");
        }
    }
}
