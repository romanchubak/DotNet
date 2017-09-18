using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Person
    {
        private string _firstName;
        private string _secondName;
        private DateTime _birthday;

        public Person(string fName, string sName, DateTime bDay)
        {
            _firstName = fName;
            _secondName = fName;
            _birthday = bDay;
        }
        public Person()
        {
            _firstName = "";
            _secondName = "";
            _birthday = DateTime.Today;
        }

        public Person( Person person)
        {
            _firstName = person._firstName;
            _secondName = person._secondName;
            _birthday = person._birthday;
        }

        public override string ToString()
        {
            return " First Name: " + _firstName + ", Second Name: " + _secondName + ", birthday: " + _birthday;
        }

        public virtual string ToShortString() => " First Name: " + _firstName + ", Second Name: " + _secondName;
    }
}
