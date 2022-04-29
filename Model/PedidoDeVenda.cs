using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Model
{
    public class PedidoDeVenda
    {

        public string CardCode { get; set; }

        public DateTime DocDueDate = DateTime.Now;
        public int BPL_IDAssignedToInvoice { get; set; }
        public List<DocumentLinesPV> DocumentLines { get; set; }

        public class DocumentLinesPV
        {
            public string ItemCode { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }

        }
    }


}
