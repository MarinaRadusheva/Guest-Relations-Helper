using GuestRelationsHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public class AddRequestServiceModel
    {
        [Range(1,6)]
        public int GuestsCount { get; set; }

        public int ServiceId { get; init; }
        [Required]
        public string ServiceName { get; init; }

        [DataType(DataType.Date)]
        [MyDateValidatorAttribute(ErrorMessage = "Date cannot be earlier than today.")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public ICollection<string> AllPaymentTypes { get; init; }

        public string PaymentType { get; set; }

        public bool IsDaily { get; set; }
    }
}
