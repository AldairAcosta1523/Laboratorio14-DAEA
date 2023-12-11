namespace Lab13C.Models
{
    public class Invoice
    {

        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string? InvoiceNumber { get; set; }
        public float Total { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerID { get; set; }
<<<<<<< HEAD
        public bool Active { get; set; }

        public List<Detail>? Details { get; set; }

=======

        public bool Active { get; set; }
>>>>>>> a483e62a019f1e966cde018c6c1bd090ade3bfcc
    }
}
