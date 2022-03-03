using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assign3_KimberlyRoseDelaCruz
{
    public  class ValidationHelper
    {
        private Regex _namePattern = new Regex(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", RegexOptions.IgnoreCase);

        public bool IsNameValid(string name)
        {

            if (_namePattern.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Regex _problemPattern = new Regex(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", RegexOptions.IgnoreCase);

        public bool IsNewProblemValid(string problem)
        {
            if (string.IsNullOrEmpty(problem))
            {
                return false;
            }
            else if (_problemPattern.IsMatch(problem))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsDateOfBirthValid(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Today.Date;

            if(dateOfBirth.Date  < currentDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsListOfNotesValid(List<string> listOfNotes)
        {
            if(listOfNotes != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
