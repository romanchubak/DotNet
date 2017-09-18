using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam RT = new ResearchTeam();
            Console.WriteLine(RT.ToShortString());
            Console.WriteLine(RT[TimeFrame.Year]);
            Console.WriteLine(RT[TimeFrame.TwoYears]);
            Console.WriteLine(RT[TimeFrame.Long]);
            RT.TopicOfResearch = "Topic";
            RT.NameOfOrganisation = "Some Name";
            RT.RegistrationNumber = 12345;
            RT.DurationOfResearch = TimeFrame.TwoYears;
            RT.ListOfPublication = new Paper[1] {
                                                    new Paper {
                                                        Name = "some paper",
                                                        Author = new Person(fName: "Roman", sName: "Chubak", bDay: DateTime.Today),
                                                        DateOfPublication = DateTime.Today
                                                    }
                                                };
            Console.WriteLine(RT);
            RT.AddPapers(
                new Paper
                {
                    Name = "paper",
                    Author = new Person(fName: "Oleh", sName: "Bodnar", bDay: DateTime.Today),
                    DateOfPublication = DateTime.Today
                });
            Console.WriteLine(RT);
            Console.WriteLine(RT.LastPublication);

            Console.WriteLine("\n\n\n");
            Console.WriteLine("enter the number of rows and columns separated by spaces: ");
            string[] nm = Console.ReadLine().Split(' ');
            int nRows = Convert.ToInt32(nm[0]);
            int nColums = Convert.ToInt32(nm[1]);

            ResearchTeam[] arr = new ResearchTeam[nRows * nColums];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = new ResearchTeam();
            ResearchTeam[,] arr2 = new ResearchTeam[nRows, nColums];
            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nColums; j++)
                    arr2[i, j] = new ResearchTeam();
            ResearchTeam[][] arr3 = new ResearchTeam[WhatNumberOfRows(nRows * nColums)][];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = new ResearchTeam[i + 1];
                for (int j = 0; j < arr3[i].Length; j++)
                    arr3[i][j] = new ResearchTeam();
            }

            int start = Environment.TickCount;
            foreach (var element in arr)
                element.NameOfOrganisation = "afsa";
            int end = Environment.TickCount;
            Console.WriteLine("one-dimensional array : " + (end - start) + "msec");


            start = Environment.TickCount;
            foreach (var element in arr2)
                element.NameOfOrganisation = "afsa";
            end = Environment.TickCount;
            Console.WriteLine("two-dimensional array : " + (end - start) + "msec");


            start = Environment.TickCount;
            foreach (var firstDemention in arr3)
                foreach (var secondDemention in firstDemention)
                    secondDemention.NameOfOrganisation = "afsa";
            end = Environment.TickCount;
            Console.WriteLine("stepped array array : " + (end - start) + "msec");

            Console.ReadKey();
        }

        private static int WhatNumberOfRows(int n)
        {
            int sum = 1;
            int i = 1;
            while (n > sum)
            {
                i++;
                sum += i;
            }
            return i;
        }

    }
}
