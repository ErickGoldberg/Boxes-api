using boxes_api.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boxes_api.Data
{
    public class Cashiers
    {
        [Required(ErrorMessage = "O Id é obrigatório!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int RefferedBy { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime Birthday { get; set; }
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Place { get; set; }
        public string Neighboorhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Cep { get; set; }
        public EnumRole Role { get; set; }
        public string ComeFrom { get; set; }
        public EnumShirtSize ShirtSize { get; set; }
        public string RegistrationType { get; set; }
        //public Photo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<CashierEvent> CashierEvents { get; set; }
    }
}
