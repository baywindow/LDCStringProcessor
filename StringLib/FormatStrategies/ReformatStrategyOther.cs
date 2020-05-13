using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLib
{
    public class ReformatStrategyOther : IReformatStrategy
    {
        // this is an example of another format strategy, this one simply reverses the string
        public string ReformatString(string s)
        {
            string output = string.Join("", s.ToCharArray().Reverse());

            return output;
        }
    }
}
