using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public  class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string AbreviaturaTipoDocumento { get; set; } = string.Empty;
    }
}
