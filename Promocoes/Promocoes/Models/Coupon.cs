namespace Promocoes.Models
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
