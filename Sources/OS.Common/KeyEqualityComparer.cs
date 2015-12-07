#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace OS.Common
{
    public class KeyEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, object> keyExtractor;

        public KeyEqualityComparer(Func<T, object> keyExtractor)
        {
            this.keyExtractor = keyExtractor;
        }

        public bool Equals(T x, T y)
        {
            return keyExtractor(x).Equals(keyExtractor(y));
        }

        public int GetHashCode(T obj)
        {
            return keyExtractor(obj).GetHashCode();
        }
    }
}