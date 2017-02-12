using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigApp.ViewModels
{
    public class ValidateDates : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime cDT;
            bool isValid = DateTime.TryParse(Convert.ToString(value), out cDT);            
            return isValid;
        }
    }

}