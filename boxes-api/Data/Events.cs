using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boxes_api.Data
{
    public class Event
    {
        [Required(ErrorMessage = "O Id é obrigatório!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int HeadNumber { get; set; }
        // head number (FK - id da tabela de cashiers para saber o rep do evento)
        // event number (FK - provavel relacionamento)
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Payment { get; set; } 
        public int Comission { get; set; }
        public int Security { get; set; }
        public int Bar { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Neighboorhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CashierId { get; set; }
        public Cashiers Cashier { get; set; }
        public ICollection<CashierEvent> CashierEvents { get; set; }
    }
}
