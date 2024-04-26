using CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Movimenti;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Persona
{
    public interface IPersonaHeaderViewItem : IModelViewItem { }

    [ViewItem(typeof(IPersonaHeaderViewItem))]
    public class PersonaHeaderViewItem : ViewItem, IComplexViewItem
    {
        public class PersonaHeaderHolder : IComponentContentHolder
        {
            public PersonaHeaderHolder(PersonaHeaderModel componentModel)
            {
                ComponentModel = componentModel;
            }
            public PersonaHeaderModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ComponentModelObserver.Create(ComponentModel, PersonaHeaderRenderer.Create(ComponentModel));
        }
        private XafApplication application;
        public PersonaHeaderViewItem(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        protected override object CreateControlCore() => new PersonaHeaderHolder(new PersonaHeaderModel());
    }
}
