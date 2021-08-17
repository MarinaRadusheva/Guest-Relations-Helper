using System;
using System.ComponentModel.DataAnnotations;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Data.Models
{
    public class GuestRequest
    {
        public int Id { get; init; }

        public int ReservationId { get; init; }

        public Reservation Reservation { get; init; }

        public int HotelServiceId { get; init; }

        public HotelService HotelService { get; init; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public bool IsDaily { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Range(GuestMinCount, GuestMaxCount, ErrorMessage = "Please enter a valid number of guests")]
        public int GuestCount { get; set; }

        public decimal? Price { get; set; }

        public PaymentType? PaymentType { get; set; }

        public RequestStatus RequestStatus { get; set; }
    }
}
