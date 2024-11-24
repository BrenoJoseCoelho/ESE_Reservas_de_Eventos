namespace ReservasApi.Request
{
    public class CreateReservationRequest
    {
        public Guid EventId { get; set; }
        public Guid? CouponId { get; set; }
        public Guid ParticipantId { get; set; }
    }
}
