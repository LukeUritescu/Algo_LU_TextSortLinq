using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_LU
{
    class Program
    {
        static ReadAllFilesAndSort readFiles;
        static void Main(string[] args)
        {
            readFiles = new ReadAllFilesAndSort();
            readFiles.ReadInFile();
        }
    }
}
