using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ResearchTeam
    {
        private string _topicOfResearch;
        private string _nameOfOrganisation;
        private int _registrationNumber;
        private TimeFrame _durationOfResearch;
        private Paper[] _listOfPublication;

        public string TopicOfResearch
        {
            get { return _topicOfResearch; }
            set { _topicOfResearch = value; }
        }
        public string NameOfOrganisation
        {
            get { return _nameOfOrganisation; }
            set { _nameOfOrganisation = value; }
        }
        public int RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }
        public TimeFrame DurationOfResearch { get => _durationOfResearch; set => _durationOfResearch = value; }
        public Paper[] ListOfPublication { get => _listOfPublication; set => _listOfPublication = value; }

        public ResearchTeam()
        {
            _topicOfResearch = "";
            _nameOfOrganisation = "";
            RegistrationNumber = -1;
            _durationOfResearch = TimeFrame.Year;
            _listOfPublication = null;
        }
        public ResearchTeam(string topic, string name, int number, TimeFrame tf)
        {
            _topicOfResearch = topic;
            _nameOfOrganisation = name;
            RegistrationNumber = number;
            _durationOfResearch = tf;
        }

        public Paper LastPublication
        {
            get{
                if (_listOfPublication != null && _listOfPublication.Length == 0) return null;
                else return _listOfPublication[_listOfPublication.Length-1];
            }
        }

        
        public bool this[TimeFrame index]
        {
            get { return index == _durationOfResearch; }
        }
        public void AddPapers( params Paper[] newPublication)
        {
            if (_listOfPublication == null) _listOfPublication = newPublication;
            else 
            {
                Paper[] rez = new Paper[newPublication.Length + _listOfPublication.Length];
                for (int i = 0; i < _listOfPublication.Length; i++)
                    rez[i] = _listOfPublication[i];
                for (int i = 0; i < newPublication.Length; i++)
                    rez[i + _listOfPublication.Length] = newPublication[i];
                _listOfPublication = rez;
            }
        }
        public override string ToString()
        {
            string rez = "";
            rez = " Topic of research: " + _topicOfResearch + "\n" +
                  " Name of organisation: " + _nameOfOrganisation + "\n" +
                  " Registration number: " + _registrationNumber + "\n" +
                  " Duration time: " + _durationOfResearch + "\n" +
                  " Publications: ";
            if(_listOfPublication!=null)
            foreach (var publication in _listOfPublication)
                rez += "\n\t" + publication.ToString();
            return rez;
        }
        public virtual string ToShortString()
        {
            string rez = "";
            rez = " Topic of research: " + _topicOfResearch + "\n" +
                 " Name of organisation: " + _nameOfOrganisation + "\n" +
                 " Registration number: " + _registrationNumber + "\n" +
                 " Duration time: " + _durationOfResearch + "\n" +
                 " Publications: " + "\n";
            return rez;
        }

    }
}
