using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ResearchTeam : Lab2.Team, Lab2.Interfaces.INameAndCopy, IEnumerable
    {
        #region private
        private string _topicOfResearch;
        private TimeFrame _durationOfResearch;
        private ArrayList _listOfPublication;
        private ArrayList _listOfMembers;
        #endregion

        #region properties
        public Team Team { get => this; set => Team = value; }
        public ArrayList  ListOfMembers { get => _listOfMembers; set => _listOfMembers = value; }
        public string TopicOfResearch
        {
            get { return _topicOfResearch; }
            set { _topicOfResearch = value; }
        }
        public TimeFrame DurationOfResearch { get => _durationOfResearch; set => _durationOfResearch = value; }
        public ArrayList ListOfPublication { get => _listOfPublication; set => _listOfPublication = value; }
        public Paper LastPublication
        {
            get
            {
                if (_listOfPublication != null && _listOfPublication.Count == 0) return null;
                else return (Paper)_listOfPublication[_listOfPublication.Count - 1];
            }
        }

        public string Name { get ; set ; }
        #endregion

        #region constructors


        public ResearchTeam(): base()
        {
            _topicOfResearch = "";
            _durationOfResearch = TimeFrame.Year;
            _listOfPublication = new ArrayList();
            _listOfMembers = new ArrayList();
        }
        public ResearchTeam(string topic, string name, int number, TimeFrame tf) : base(name,number)
        {
            _topicOfResearch = topic;
            _durationOfResearch = tf;
            _listOfPublication = new ArrayList();
            _listOfMembers = new ArrayList();
        }

        
        #endregion

        #region methods
        public void AddPapars(params Paper[] papers)
        {
            ListOfPublication.AddRange(papers);
        }
        public override object DeepCopy()
        {
            ResearchTeam copy = new ResearchTeam(TopicOfResearch, NameOfOrganization, RegistrationNumber, DurationOfResearch);
            foreach (Paper item in ListOfPublication)
            {
                copy.ListOfPublication.Add(item.DeepCopy());
            }
            foreach (Person item in ListOfMembers)
            {
                copy.ListOfMembers.Add(item.DeepCopy());
            }
            return copy;
        }

        public bool this[TimeFrame index]
        {
            get { return index == _durationOfResearch; }
        }
        
        public override string ToString()
        {
            string rez = "";
            rez = " Topic of research: " + _topicOfResearch + "\n" +
                  " Name of organisation: " + NameOfOrganization + "\n" +
                  " Registration number: " +  RegistrationNumber + "\n" +
                  " Duration time: " + _durationOfResearch + "\n" +
                  " Publications: ";
            if(_listOfPublication!=null)
            foreach (Paper publication in _listOfPublication)
                rez += "\n\t" + publication.ToString();
            if (_listOfMembers != null)
                foreach (Person member in _listOfMembers)
                    rez += "\n\t" + member.ToString();
            return rez;
        }
        public virtual string ToShortString()
        {
            string rez = "";
            rez = " Topic of research: " + _topicOfResearch + "\n" +
                 " Name of organisation: " + NameOfOrganization + "\n" +
                 " Registration number: " + RegistrationNumber + "\n" +
                 " Duration time: " + _durationOfResearch + "\n" +
                 " Publications: " + "\n";
            return rez;
        }

        public IEnumerator GetMembersHasnotPublication()
        {
            for (int i = 0; i < ListOfMembers.Count; i++)
            {
                if ( !ListOfPublication.Contains(ListOfMembers[i]) )
                    yield return ListOfMembers[i];
            }
        }
        public IEnumerator GetPublication(int n)
        {
            for (int i = 0; i < ListOfPublication.Count; i++)
            {
                if (DateTime.Today.Year - ((Paper)ListOfPublication[i]).DateOfPublication.Year < n)
                    yield return ListOfPublication[i];
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < ListOfMembers.Count; i++)
            {
                yield return ListOfMembers[0];
            }
        }
        #endregion

    }
}
