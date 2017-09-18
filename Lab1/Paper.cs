using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Paper
    {
        public string Name { get; set; }
        public Person Author { get; set; }
        public DateTime DateOfPublication { get; set; }

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

        public override string ToString() => " Name of publication: " + Name + ", Author: " + Author + ", Date of publication: " + DateOfPublication;
    }
}
