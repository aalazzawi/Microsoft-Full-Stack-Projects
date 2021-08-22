using System;
using System.Collections.Generic;

namespace sakila.Models
{
    public partial class InvoiceAudit
    {
        public int InvoiceAuditId { get; set; }
        public int? InvoiceId { get; set; }
        public string Username { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
