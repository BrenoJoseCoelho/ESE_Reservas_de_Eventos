namespace ReservasApi.Request
{
    public class UpdateReservationRequest
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid? CouponId { get; set; }
        public Guid ParticipantId { get; set; }
    }
}
