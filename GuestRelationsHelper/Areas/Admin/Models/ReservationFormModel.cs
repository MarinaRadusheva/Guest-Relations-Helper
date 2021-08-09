using GuestRelationsHelper.Services.Reservations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuestRelationsHelper.Areas.Admin.Models
{
    public class ReservationFormModel
    {
        public string Villa { get; init; }

        public int GuestsCount { get; init; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; init; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; init; }
        public int VillaId { get; init; }

        public IEnumerable<VillaServiceModel> Villas { get; set; }
    }
}
