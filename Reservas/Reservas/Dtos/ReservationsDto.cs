using ReservasApi.Models;

namespace ReservasApi.Dtos
{
    public class ReservationsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Participant Participant { get; set; }
    }
}
