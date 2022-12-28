using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WarsztatSamochodowy.Services
{
    internal class ValidationService
    {
        public static void ValidateName(string? name)
        {
            if(name == null)
            {
                throw new ArgumentException("Nie podano nazwy");
            }
            string validNameRegex = @"^[a-zżźćńółęąś\  ]{1,40}$";
            Regex nameRegex = new Regex(validNameRegex);
            if (!nameRegex.IsMatch(name))
            {
                throw new ArgumentException("podano niepoprawny format");
            }
        }
        public static void ValidateFloat(string? number)
        {
            try
            {
                if(float.Parse(number?? "") < 0)
                {
                    throw new ArgumentException("Podano ujmeną wartość");
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException("Podano niepoprawną wartość");
            }
        }
    }
}
