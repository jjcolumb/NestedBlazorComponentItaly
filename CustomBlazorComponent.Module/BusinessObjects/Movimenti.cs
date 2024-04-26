using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
using CustomBlazorComponent.Module.Enums;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustomBlazorComponent.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Movimenti : BaseObject
    {
        public Movimenti(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        private DataType data;
        public DataType Data
        {
            get => data;
            set => SetPropertyValue(nameof(Data), ref data, value);
        }

        DateTime inizio;
        public DateTime Inizio
        {
            get => inizio;
            set => SetPropertyValue(nameof(Inizio), ref inizio, value);
        }

        DateTime fine;
        public DateTime Fine
        {
            get => fine;
            set => SetPropertyValue(nameof(Fine), ref fine, value);
        }

        Documenti documenti;
        public Documenti Documenti
        {
            get => documenti;
            set => SetPropertyValue(nameof(Documenti), ref documenti, value);
        }

        SaldoType saldo;
        public SaldoType Saldo
        {
            get => saldo;
            set => SetPropertyValue(nameof(Saldo), ref saldo, value);
        }

        Categorie categorie;
        public Categorie Categorie
        {
            get => categorie;
            set => SetPropertyValue(nameof(Categorie), ref categorie, value);
        }

        Causali causali;
        public Causali Causali
        {
            get => causali;
            set => SetPropertyValue(nameof(Causali), ref causali, value);
        }

        Pagamento pianiPagamento;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Pagamento PianiPagamento
        {
            get => pianiPagamento;
            set => SetPropertyValue(nameof(PianiPagamento), ref pianiPagamento, value);
        }

        Eventi eventi;
        public Eventi Eventi
        {
            get => eventi;
            set => SetPropertyValue(nameof(Eventi), ref eventi, value);
        }

        Articolo articoli;
        public Articolo Articoli
        {
            get => articoli;
            set => SetPropertyValue(nameof(Articoli), ref articoli, value);
        }

        Strumenti strumenti;
        public Strumenti Strumenti
        {
            get => strumenti;
            set => SetPropertyValue(nameof(Strumenti), ref strumenti, value);
        }

        string assegnatariHolder;
        [EditorAlias("AssegnatariHolderPropertyEditor")]
        public string AssegnataryHoder
        {
            get => assegnatariHolder;
            set => SetPropertyValue(nameof(AssegnataryHoder), ref assegnatariHolder, value);
        }

        [Association("Movimenti-Assegnatari")]
        public XPCollection<Persona> Assegnatari
        {
            get
            {
                return GetCollection<Persona>(nameof(Assegnatari));
            }
        }

        public List<GridItems> GridItems { get; set; }

    }
}