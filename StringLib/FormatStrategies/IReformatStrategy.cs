using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLib
{
    // using the strategy pattern so that we're not tightly coupled to the reformatting algorithm should it require changing
    public interface IReformatStrategy
    {
        string ReformatString(string s);
    }
}
