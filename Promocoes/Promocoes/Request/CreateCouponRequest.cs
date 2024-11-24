namespace Promocoes.Request
{
    public class CreateCouponRequest
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public Guid PromotionId { get; set; }
    }
}
