using System;
using System.ComponentModel.DataAnnotations;
using GuestRelationsHelper.Data;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public class RequestServiceModel : IRequestModel
    {
        public int Id { get; init; }

        [Required]
        public string VillaNumber { get; init; }

        [Required]
        public string ServiceName { get; init; }
        [DataType(DataType.Date)]
        [MyDateValidatorAttribute(ErrorMessage = "Date cannot be earlier than today.")]
        public DateTime Date { get; set; }
        public bool IsDaily { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public string Status { get; set; }

    }
}
