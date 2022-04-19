using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModule_9
{

    class LastNames
    {
        public delegate string[] SortLastNamesDelegate(string[] lastNamesArray);
        public event SortLastNamesDelegate SortLastNamesEvent;
        
        private string[] lastNamesArray;

        public LastNames(string[] lastNamesArray)
        {
            this.lastNamesArray = lastNamesArray;
        }

        public void ShowLastNames()
        {
            int i = 0;
            foreach (var lastName in lastNamesArray)
            {
                Console.WriteLine($"{++i}. {lastName}");
            }
        }

        public void Sort()
        {
            lastNamesArray = SortLastNamesEvent?.Invoke(lastNamesArray);
        }
    }
}
