using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Model
{
    public class BusinessPartner
    {

        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public List<BPFiscalTaxIDCollections> BPFiscalTaxIDCollection { get; set; }


        public class BPFiscalTaxIDCollections
        {
            public string TaxId0 { get; set; }
            public string TaxId1 { get; set; }

        }

    }
}
