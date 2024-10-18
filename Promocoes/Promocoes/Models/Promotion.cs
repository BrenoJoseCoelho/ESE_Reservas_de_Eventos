namespace Promocoes.Models
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public List<Coupon> Coupons { get; set; } = new List<Coupon>();
    }
}
