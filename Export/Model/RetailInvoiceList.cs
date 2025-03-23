using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Export.Model
{
    public class RetailInvoiceList
    {
        [XmlElement("RetailInvoice")]
        public List<RetailInvoice> RetailInvoices { get; set; } = new List<RetailInvoice>();

    }
}
