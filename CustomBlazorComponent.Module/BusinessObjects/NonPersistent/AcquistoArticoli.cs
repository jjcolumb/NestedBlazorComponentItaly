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
    public class AcquistoArticoli
    {
        [EditorAlias("AcquistoArtcoliPropertyEditor")]
        public string ShowView { get; set; }
        public Articolo Articolo { get; set; }
        public string Descrizione { get; set; }
        public int Quantita { get; set; }
        public ApplicationUser Persone { get; set; }
        public ApplicationUser Debitore { get; set; }
        public DateTime DataEmissione { get; set; }
        public DateTime DataScadenza { get; set; }
        public List<GridItems> Items { get; set; } = new List<GridItems>();

    }
}
