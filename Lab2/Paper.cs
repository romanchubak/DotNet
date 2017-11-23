using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Paper
    {
        #region properties
        public string Name { get; set; }
        public Person Author { get; set; }
        public DateTime DateOfPublication { get; set; }
        #endregion

        #region constructors
        public Paper()
        {
            Name = "";
            Author = null;
            DateOfPublication = DateTime.Today;
        }
        public Paper(string name, Person author, DateTime date)
        {
            Name = name;
            Author = author;
            DateOfPublication = date;
        }
        public Paper(Paper paper)
        {
            Name = paper.Name;
            Author = new Person(paper.Author);
            DateOfPublication = paper.DateOfPublication;
        }
        #endregion

        #region methods

        public object DeepCopy()
        {
            Paper copy = new Paper(Name, Author, DateOfPublication);
            return copy;
        }

        public override string ToString() => " Name of publication: " + Name + ", Author: " + Author + ", Date of publication: " + DateOfPublication;
        
        #endregion
    }
}
