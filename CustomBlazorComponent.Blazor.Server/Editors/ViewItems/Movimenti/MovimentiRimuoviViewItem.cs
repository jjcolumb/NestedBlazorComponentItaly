using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Movimenti
{
    public class MovimentiRimuoviButtonModel : ComponentModelBase
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


    public interface IMovimentiRimuoviButtonViewItem : IModelViewItem { }

    [ViewItem(typeof(IMovimentiRimuoviButtonViewItem))]
    public class MovimentiRimuoviButtonViewItem : ViewItem, IComplexViewItem
    {
        public class MovimentiRimuoviButtonHolder : IComponentContentHolder
        {
            public MovimentiRimuoviButtonHolder(MovimentiRimuoviButtonModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public MovimentiRimuoviButtonModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, MovimentiRimuoviButton.Create(ComponentModel));
        }
        private XafApplication application;
        public MovimentiRimuoviButtonViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new MovimentiRimuoviButtonHolder(new MovimentiRimuoviButtonModel());
        protected override void OnControlCreated()
        {
            if (Control is MovimentiRimuoviButtonHolder holder)
            {
                holder.ComponentModel.Text = "Rimuovi";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is MovimentiRimuoviButtonHolder holder)
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
