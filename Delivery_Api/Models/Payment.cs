namespace Delivery_Api.Models
{
    public class Payment : Entity
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public bool Enabled { get; set; }
    }
}
