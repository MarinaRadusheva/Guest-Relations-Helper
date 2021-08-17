using GuestRelationsHelper.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuestRelationsHelper.Data
{
    public class HelperMethods
    {
        public static string GenerateReservationPassword(int length)
        {
            {
                const string valid = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789";
                StringBuilder res = new();
                Random rnd = new();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                return res.ToString();
            }
        }
        public static List<string> GetPaymentTypes()
        {
            var paymentTypes = new List<string>();
            foreach (var paymentType in Enum.GetValues(typeof(PaymentType)))
            {
                paymentTypes.Add(paymentType.ToString());
            }
            return paymentTypes;
        }
    }
}
