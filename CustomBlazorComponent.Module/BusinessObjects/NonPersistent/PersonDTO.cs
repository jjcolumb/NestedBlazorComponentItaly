using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlazorComponent.Module.BusinessObjects.NonPersistent
{
    [DomainComponent]
    public class PersonDTO : NonPersistentLiteObject
    {
        public PersonDTO(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}
