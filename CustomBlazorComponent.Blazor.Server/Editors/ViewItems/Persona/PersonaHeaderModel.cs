using DevExpress.ExpressApp.Blazor.Components.Models;

namespace CustomBlazorComponent.Blazor.Server.Editors.ViewItems.Persona
{
    public class PersonaHeaderModel: ComponentModelBase
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
}
