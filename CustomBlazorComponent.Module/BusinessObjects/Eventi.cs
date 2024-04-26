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

    public class Eventi : BaseObject
    { 
        public Eventi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string eventiName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EventiName
        {
            get => eventiName;
            set => SetPropertyValue(nameof(EventiName), ref eventiName, value);
        }
    }
}