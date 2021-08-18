using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GuestRelationsHelper.Data;
using GuestRelationsHelper.Services.Reservations.Models;

using static GuestRelationsHelper.Data.DataConstants;

namespace GuestRelationsHelper.Areas.Admin.Models
{
    public class ReservationFormModel
    {
        public string Villa { get; init; }

        [Range(GuestMinCount, GuestMaxCount)]
        public int GuestsCount { get; init; }

        [DataType(DataType.Date)]
        [MyDateValidatorAttribute(ErrorMessage = "Date cannot be earlier than today.")]
        public DateTime CheckIn { get; init; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; init; }
        public int VillaId { get; init; }

        public IEnumerable<VillaServiceModel> Villas { get; set; }
    }
}
