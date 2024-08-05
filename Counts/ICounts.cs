using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICounts
    {
        int CountBytes(string filename);
        int CountLines(string filename);
    }
}
