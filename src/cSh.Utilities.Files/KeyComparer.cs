using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSh.Utilities.Files
{
    internal class KeyComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y) => x == y;

        public override int GetHashCode(string obj) => obj.Length; 
    }
}
