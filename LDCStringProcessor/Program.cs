using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringLib;

namespace LDCStringProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string LDCString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
            IReformatStrategy LDCStrategy = new ReformatStrategyLDC();
            Console.WriteLine("LDC supplied string was " + LDCString);
            string newString = LDCStrategy.ReformatString(LDCString);
            Console.WriteLine("Reformatted this gives us .... " + newString);
            Console.ReadKey();
        }
    }
}
