using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlazorComponent.Module.BusinessObjects.NonPersistent
{
    [DomainComponent]
    public class GridItems: NonPersistentLiteObject
    {
        public string Portafoglio { get; set; }
        public string Debitore { get; set; }
        public string Descrizione { get; set; }
        public string Causale { get; set; }
        public string DataEmissione { get; set; }
        public string Data {  get; set; }
        public string Quantita { get; set; }
        public string ImportoTotale { get; set; }
        public string DataScadenza { get; set; }
        public string Assegnatario { get; set; }
        public string Saldo { get; set; }
    }
}
