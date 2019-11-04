using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_LU
{
    class ReadAllFilesAndSort
    {
        PersonalStopWatch stopWatch;

        private List<string> myBaseStrings;

        private List<string> myFinallSortedStrings;

        private List<string> listZ;
        private string path = @"C:\Workspace\Algorithms\Algo_LU_TextSortLinq\Algo_LU\words.txt";

        public ReadAllFilesAndSort()
        {
            stopWatch = new PersonalStopWatch();
            myBaseStrings = new List<string>();
            myFinallSortedStrings = new List<string>();
            listZ = new List<string>();
        }

        public List<string> GetMyString()
        {
            return myBaseStrings;
        }

        public void ReadInFile()
        {
            foreach (string line in File.ReadLines(path))
            {
                //string[] values;
                myBaseStrings.Add(line);

            }

            ////This is just to make sure the list is working
            //for (int i = 0; i < myBaseStrings.Count; i++)
            //{
            //    Console.WriteLine(myBaseStrings[i]);
            //}
        }

        public void SortZFirst()
        {
            listZ = GetMyString().OrderByDescending(words => words).ToList();

            //for(int i = 0; i < listZ.Count; i++)
            //{
            //    Console.WriteLine(listZ[i]);
            //}
        }

        public void SortOnlyZWords()
        {
            var zWordList = from z in GetMyString() where z.StartsWith("Z") select z;
           for(int i = 0; i < zWordList.Count(); i++)
            {
                Console.WriteLine(zWordList.ElementAt(i));
            }
        }

        public void SortHeFirst()
        {

        }

        public void SortESecond()
        {

        }

        public void WriteSortList(string Path, List<string> sortWriteList)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path, true))
                {
                    for (int i = 0; i < sortWriteList.Count; i++)
                    {
                        file.WriteLine(sortWriteList[i].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did not work:", ex);
            }

        }
    }
}
