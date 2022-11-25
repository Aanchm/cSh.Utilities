using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSh.Utilities.Files
{
    internal class DataComparer : EqualityComparer<DataFormat>
    {
        public override bool Equals(DataFormat x, DataFormat y)
        {
            var keyComparer = new KeyComparer();
            return x.Data.Keys.SequenceEqual(y.Data.Keys, keyComparer);
            
        }

        public override int GetHashCode(DataFormat obj)
        {
            return obj.Data.Count;
        }
    }
}
