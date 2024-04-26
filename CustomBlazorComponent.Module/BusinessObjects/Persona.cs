using CustomBlazorComponent.Module.BusinessObjects.NonPersistent;
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
    public class Persona : BaseObject
    {
        public Persona(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string persone;
        string cognomeNome;
        string eta;
        string classi;
        string settori;
        string percosi;
        string stati;
        Categorie categoria;
        string area;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Area
        {
            get => area;
            set => SetPropertyValue(nameof(Area), ref area, value);
        }


        public Categorie Categoria
        {
            get => categoria;
            set => SetPropertyValue(nameof(Categoria), ref categoria, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Stati
        {
            get => stati;
            set => SetPropertyValue(nameof(Stati), ref stati, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Percosi
        {
            get => percosi;
            set => SetPropertyValue(nameof(Percosi), ref percosi, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Settori
        {
            get => settori;
            set => SetPropertyValue(nameof(Settori), ref settori, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Classi
        {
            get => classi;
            set => SetPropertyValue(nameof(Classi), ref classi, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Eta
        {
            get => eta;
            set => SetPropertyValue(nameof(Eta), ref eta, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CognomeNome
        {
            get => cognomeNome;
            set => SetPropertyValue(nameof(CognomeNome), ref cognomeNome, value);
        }

        [EditorAlias("PersonnePropertyEditor")]
        public string Persone
        {
            get => persone;
            set => SetPropertyValue(nameof(Persone), ref persone, value);
        }

        public IEnumerable<PersonDTO> Selected { get; set; } = new List<PersonDTO>();

        [Association("Movimenti-Assegnatari")]
        public XPCollection<Movimenti> Movimentii
        {
            get
            {
                return GetCollection<Movimenti>(nameof(Movimentii));
            }
        }
    }
}