namespace ReservasApi.Dtos
{
    public class ReservationsDto
    {
        public Guid Id { get; set; }
        public EventDto Event { get; set; }
        public CouponDto Coupon { get; set; }
        public ParticipantDto Participant { get; set; }
    }
}
