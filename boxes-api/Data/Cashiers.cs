using boxes_api.Data.Enum;

namespace boxes_api.Data
{
    public class Cashiers
    {
        public int Id { get; }
        public int RefferedBy { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
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
    }
}
