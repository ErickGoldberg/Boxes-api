using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boxes_api.Data
{
    public class CashierEvent
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int CashierId { get; set; }
        public Cashiers Cashier { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
}
}
