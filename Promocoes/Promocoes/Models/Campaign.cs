namespace Promocoes.Models
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly InitialDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
