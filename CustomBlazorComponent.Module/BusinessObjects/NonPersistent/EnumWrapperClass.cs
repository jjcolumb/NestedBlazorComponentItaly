using CustomBlazorComponent.Module.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlazorComponent.Module.BusinessObjects.NonPersistent
{
    public class DataTypeClass
    {
        // Specifies an enumeration value
        public DataType Value { get; set; }
        // Specifies text to display in the ComboBox
        public string DisplayName { get; set; }
    }

    public class SaldoTypeClass
    {
        public SaldoType Value { get; set; }
        public string DisplayName { get; set; }
    }
}
