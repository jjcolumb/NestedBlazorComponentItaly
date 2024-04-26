
using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace CustomBlazorComponent.Blazor.Server.Editors.AcquistoArtcoliPropertyEditor
{
    public class AcquistoArticoliModel: ComponentModelBase
    {
        public string Value
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public AcquistoArticoli AcquistoArticoli
        {
            get => GetPropertyValue<AcquistoArticoli>();
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
