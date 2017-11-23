using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new Team("Team1", 1);
            Team t2 = new Team("Team1", 1);
            Console.WriteLine("t1 equel t2 -> {0}", t1.Equals(t2));
            Console.WriteLine("t1 == t2 -> {0}", t1 == t2);
            t2.NameOfOrganization = "Team2";
            Console.WriteLine("t1 equel t2 -> {0}", t1.Equals(t2));
            Console.WriteLine("t1 == t2 -> {0}", t1 == t2);

            Console.WriteLine("hash code t1: {0}", t1.GetHashCode());
            Console.WriteLine("hash code t2: {0}", t2.GetHashCode());

            try
            {
                t1.RegistrationNumber = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ResearchTeam rt = new ResearchTeam("reseach", "reseach team1", 123, TimeFrame.Long);
            rt.ListOfPublication = new System.Collections.ArrayList(){
                                                    new Paper {
                                                        Name = "some paper",
                                                        Author = new Person(fName: "Roman", sName: "Chubak", bDay: DateTime.Today),
                                                        DateOfPublication = DateTime.Today
                                                    }
                                                };
            rt.ListOfMembers = new System.Collections.ArrayList() {
                                                                        new Person("roman","chubak",DateTime.Today),
                                                                        new Person("f","dfa", new DateTime(1999,5,4)),
                                                                        new Person(fName: "Roman", sName: "Chubak", bDay: DateTime.Today)
                                                                  };
            Console.WriteLine(rt);
            Console.WriteLine(rt.Team);

            ResearchTeam newrt = (ResearchTeam)rt.DeepCopy();
            rt.NameOfOrganization = "team";
            Console.WriteLine(rt);
            Console.WriteLine(newrt);

            

            Console.ReadKey();
        }

    }
}
