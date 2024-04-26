using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Xpo;
using CustomBlazorComponent.Blazor.Server.Services;
using DevExpress.ExpressApp.Blazor.Templates;

namespace CustomBlazorComponent.Blazor.Server;

public class CustomBlazorComponentBlazorApplication : BlazorApplication {
    public CustomBlazorComponentBlazorApplication() {
        ApplicationName = "CustomBlazorComponent";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += CustomBlazorComponentBlazorApplication_DatabaseVersionMismatch;
        CustomizeTemplate += CustomBlazorComponentBlazorApplication_CustomizeTemplate;
    }

    private void CustomBlazorComponentBlazorApplication_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e)
    {
        if (e.Template is IPopupWindowTemplateSize size)
        {
            size.MaxWidth = "100vw";
            size.Width = "100vw";
            size.MaxHeight = "100vh";
            size.Height = "100vh";
        }
    }

    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void CustomBlazorComponentBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}
