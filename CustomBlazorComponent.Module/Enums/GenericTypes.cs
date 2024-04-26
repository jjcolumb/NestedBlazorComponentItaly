using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlazorComponent.Module.Enums
{
    public enum DataType : int
    {
        [Display(Name = "Scadenza")]
        Scadenza = 0,
    }

    public enum SaldoType : int
    {
        [Display(Name = "Da incassare")]
        DaIncassare = 0,
    }
}
