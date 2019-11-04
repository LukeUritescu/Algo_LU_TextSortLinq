using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Used this https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq
/// </summary>
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

        }

        public void SortZFirst()
        {
            string pathZ = @"C:\Workspace\Algorithms\Algo_LU_TextSortLinq\Algo_LU\ReverseAlphabetical.txt";
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            listZ = GetMyString().OrderByDescending(words => words).ToList();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("SortZFirst");

            WriteSortList(pathZ, listZ);
        }

        public void SortOnlyZWords()
        {
            string pathOnlyZ = @"C:\Workspace\Algorithms\Algo_LU_TextSortLinq\Algo_LU\OnlyZ.txt";
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            var zWordList = from z in GetMyString() where z.StartsWith("Z") select z;
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("SortOnlyZ");

            WriteSortList(pathOnlyZ, zWordList.ToList());

        }

        public void SortHeFirst()
        {
            string pathOnlyHE = @"C:\Workspace\Algorithms\Algo_LU_TextSortLinq\Algo_LU\OnlyHE.txt";
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            var heWordList = from z in GetMyString() where z.StartsWith("He") select z;
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("SortOnlyHe");

            WriteSortList(pathOnlyHE, heWordList.ToList());

        }

        public void SortESecond()
        {
            string pathOnlyE = @"C:\Workspace\Algorithms\Algo_LU_TextSortLinq\Algo_LU\OnlyE.txt";
            stopWatch.ResetStopWatch();
            stopWatch.StartStopWatch();
            List<string> eAtSecondPosition = new List<string>();
            foreach(string line in GetMyString())
            {
                if(line.Length >= 2)
                {

                if(line.ToCharArray()[1]  == 'e')
                {
                    eAtSecondPosition.Add(line);
                }

                }
            }
            eAtSecondPosition.OrderBy(words => words).ToList();
            stopWatch.StopStopWatch();
            stopWatch.GetTimeElapsed("SortOnlyEAtSecond");
            WriteSortList(pathOnlyE, eAtSecondPosition);
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
