using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Movimenti
{
    public interface IMovimentiHeaderViewItem : IModelViewItem { }

    [ViewItem(typeof(IMovimentiHeaderViewItem))]
    public class MovimentiHeaderViewItem : ViewItem, IComplexViewItem
    {
        public class MovimentiHeaderHolder : IComponentContentHolder
        {
            public MovimentiHeaderHolder(MovimentiHeaderModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public MovimentiHeaderModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, MovimentiHeader.Create(ComponentModel));
        }
        private XafApplication application;
        public MovimentiHeaderViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new MovimentiHeaderHolder(new MovimentiHeaderModel());
    }
}
