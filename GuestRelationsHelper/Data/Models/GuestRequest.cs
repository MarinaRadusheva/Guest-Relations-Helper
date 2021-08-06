using System;

namespace GuestRelationsHelper.Data.Models
{
    public class GuestRequest
    {
        public int Id { get; init; }
        public Reservation Reservation { get; init; }
        public HotelService HotelService { get; init; }
        public DateTime? Date { get; set; }
        public bool IsDaily { get; set; }
        public DateTime Time { get; set; }
        public int GuestCount { get; set; }
        public decimal? Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public RequestStatus RequestStatus { get; set; }
        //public User? GRId { get; set;}
    }
}
