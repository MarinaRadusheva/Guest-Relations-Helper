using System.Runtime.Serialization;

namespace GuestRelationsHelper.Data.Models
{
    public enum PaymentType
    {

        [EnumMember(Value = "Hotel Bill")]
        HotelBill = 1,
        [EnumMember(Value = "Credit Card")]
        CreditCard = 2,
        Cash = 3,

    }
}
