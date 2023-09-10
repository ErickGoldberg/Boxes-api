using System.ComponentModel.DataAnnotations.Schema;

namespace boxes_api.Data
{
    public class CashierEvent
    {
        public int CashierId { get; set; }
        public Cashiers Cashier { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
