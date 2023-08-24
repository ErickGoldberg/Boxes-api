namespace boxes_api.Data
{
    public class Event
    {
        public int Id { get; }
        public string HeadNumber { get; set; }
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
    }
}
