using CustomBlazorComponent.Module.BusinessObjects;
using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.RegistraPagamentiPropertyEditor
{
    public class RegistraPagamentiModel : ComponentModelBase
    {
        public string Value
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public Persona Persona
        {
            get => GetPropertyValue<Persona>();
            set => SetPropertyValue(value);
        }

        public IObjectSpace ObjectSpace
        {
            get => GetPropertyValue<IObjectSpace>();
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
}
