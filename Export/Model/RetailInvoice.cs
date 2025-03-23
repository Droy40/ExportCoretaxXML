using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Export.Model
{
    public class RetailInvoice
    {
        public string TrxCode { get; set; }
        public string BuyerName { get; set; }
        public string BuyerIdOpt { get; set; }
        public string BuyerIdNumber { get; set; }
        public string GoodServiceOpt { get; set; }
        public string SerialNo { get; set; }

        [Browsable(false)]
        [XmlElement("TransactionDate")]
        public string TransactionDateString
        {
            get => TransactionDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            set => TransactionDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        [XmlIgnore]
        public DateTime TransactionDate { get; set; }
        public decimal TaxBaseSellingPrice { get; set; }
        public decimal OtherTaxBaseSellingPrice { get; set; }
        public decimal VAT { get; set; }
        public decimal STLG { get; set; }

        [XmlElement("Info")]
        [Browsable(false)]
        public string Info { get; set; } = "";
    }
}
