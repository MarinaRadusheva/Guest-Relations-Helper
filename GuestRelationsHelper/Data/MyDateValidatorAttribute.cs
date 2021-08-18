using System;
using System.ComponentModel.DataAnnotations;


namespace GuestRelationsHelper.Data
{
    public class MyDateValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            if (dt<DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }
    }
}
