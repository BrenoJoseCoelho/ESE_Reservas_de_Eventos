namespace Promocoes.Request
{
    public class CreatePromotionRequest
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid CampaignId { get; set; }
    }
}
