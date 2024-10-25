namespace Promocoes.Dtos
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly InitialDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

}
