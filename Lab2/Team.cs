using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Team : Lab2.Interfaces.INameAndCopy
    {
        #region private
        private string _nameOfOrganization;
        private int _registrationNumber;
        #endregion

        #region constructors
        public Team()
        {
            _nameOfOrganization = "";
            _registrationNumber = 0;
        }
        public Team(string name, int id)
        {
            _nameOfOrganization = name;
            _registrationNumber = id;
        }
        #endregion

        #region properties
        public string NameOfOrganization { get => _nameOfOrganization; set => _nameOfOrganization = value; }
        public int RegistrationNumber 
        { 
            get => _registrationNumber; 
            set 
            { 
                if(value > 0)
                    _registrationNumber = value; 
                else{
                    throw new Exception("the new registration number less then zero or equel zero");
                }
            }
        }

        public string Name { get; set; }

        #endregion

        #region methods
        public virtual object DeepCopy()
        {
            Team copy = new Team(NameOfOrganization, RegistrationNumber);
            copy.Name = Name;
            return copy;
        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Team t = (Team)obj;
            return (_nameOfOrganization.Equals(t._nameOfOrganization)) && (_registrationNumber.Equals(t._registrationNumber)) ;
        }
        public override int GetHashCode()
        {
            return _nameOfOrganization.GetHashCode() ^ _registrationNumber.GetHashCode();
        }
        public static bool operator ==(Team x, Team y)
        {
            return x._registrationNumber == y._registrationNumber && x._nameOfOrganization == y._nameOfOrganization;
        }
        public static bool operator !=(Team x, Team y)
        {
            return !(x == y);
        }
        #endregion


    }
}
