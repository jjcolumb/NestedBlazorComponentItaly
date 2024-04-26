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
    public class PersoneRimuoviButtonModel : ComponentModelBase
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


    public interface IPersoneRimuoviViewItem : IModelViewItem { }

    [ViewItem(typeof(IPersoneRimuoviViewItem))]
    public class PersoneRimuoviViewItem : ViewItem, IComplexViewItem
    {
        public class PersoneRimuoviButtonHolder : IComponentContentHolder
        {
            public PersoneRimuoviButtonHolder(PersoneRimuoviButtonModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public PersoneRimuoviButtonModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, PersoneRimuoviRenderer.Create(ComponentModel));
        }
        private XafApplication application;
        public PersoneRimuoviViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new PersoneRimuoviButtonHolder(new PersoneRimuoviButtonModel());
        protected override void OnControlCreated()
        {
            if (Control is PersoneRimuoviButtonHolder holder)
            {
                holder.ComponentModel.Text = "Rimuovi";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is PersoneRimuoviButtonHolder holder)
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
