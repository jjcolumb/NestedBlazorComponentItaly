using DevExpress.Blazor.Primitives.Internal;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Movimenti
{
    public class MovimentiAggiungiButtonModel : ComponentModelBase
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


    public interface IMovimentiAggiungiButtonViewItem : IModelViewItem { }

    [ViewItem(typeof(IMovimentiAggiungiButtonViewItem))]
    public class MovimentiAggiungiButtonViewItem : ViewItem, IComplexViewItem
    {
        public class MovimentiAggiungiButtonHolder : IComponentContentHolder
        {
            public MovimentiAggiungiButtonHolder(MovimentiAggiungiButtonModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public MovimentiAggiungiButtonModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, MovimentiAggiungiButton.Create(ComponentModel));
        }
        private XafApplication application;
        public MovimentiAggiungiButtonViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new MovimentiAggiungiButtonHolder(new MovimentiAggiungiButtonModel());
        protected override void OnControlCreated()
        {
            if (Control is MovimentiAggiungiButtonHolder holder)
            {
                holder.ComponentModel.Text = "Aggiungi";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            if (Control is MovimentiAggiungiButtonHolder holder)
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
