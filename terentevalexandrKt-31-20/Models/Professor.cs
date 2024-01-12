using System.Text.RegularExpressions;

namespace terentevalexandrKt_31_20.Models
{
    public class Professor
    {
        public int Id { get; set; }

        public string LastName {  get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }     
        
        public bool isValidFirstName()
        {
            return Regex.Match(FirstName, @"^([А-Я]|Ё)([а-я]|ё)+").Success;
        }
    }
}
