namespace ApiProjectKamp.WebApi.Dtos.GroupReservationDtos
{
    public class ResultGroupReservationDto
    {
        public int GroupReservationId { get; set; }
        public string ResponsibleCustomerName { get; set; }
        public string GroupName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime LastProcessDate { get; set; }
        public string Priority { get; set; }
        public string Details { get; set; }
        public string ReservationStatus { get; set; }
    }
}
