namespace Promocoes.Request
{
    public class UpdateCouponRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid PromotionId { get; set; }
    }
}
