using System;

namespace GuestRelationsHelper.Services.Requests.Models
{
    public interface IRequestModel
    {
        public int Id { get; }
        public string VillaNumber { get;}
        public string ServiceName { get;}
        public DateTime? Date { get; }
        public DateTime Time { get; }
        public string Status { get; }
    }
}
