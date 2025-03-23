using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Export.Model
{
    [XmlRoot("RetailInvoiceBulk", Namespace = "")]
    public class RetailInvoiceExport
    {                                        
        public string TIN { get; set; }
        public int TaxPeriodMonth { get; set; }
        public int TaxPeriodYear { get; set; }

        [XmlElement("ListOfRetailInvoice")]
        public RetailInvoiceList ListOfRetailInvoice { get; set; }        
    }
}
