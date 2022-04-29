using System.Collections.Generic;

namespace ServiceLayer.Model
{
    public class Invoice
    {

        public string CardCode { get; set; }
        public int BPL_IDAssignedToInvoice { get; set; }
        public List<oDocumentLines> DocumentLines { get; set; }


        public class oDocumentLines
        {
            public string ItemCode { get; set; }
            public string TaxCode { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }

        }

    }
}
