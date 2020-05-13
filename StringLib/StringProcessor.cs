using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLib
{
    public class StringProcessor
    {
        readonly IReformatStrategy _reformatStrategy;

        public StringProcessor(IReformatStrategy reformatStrategy)
        {
            _reformatStrategy = reformatStrategy;
        }

        public List<string> ReformatCollection(List<string> input)
        {
            List<string> output = new List<string>();

            // if input isn't valid we'll drop through and return an empty collection rather than null
            if (input != null && input.Any())
            {
                if (_reformatStrategy != null)
                {
                    foreach (string s in input)
                    {
                        output.Add(_reformatStrategy.ReformatString(s));
                    }
                }
            }

            return output;
        }
    }
}
