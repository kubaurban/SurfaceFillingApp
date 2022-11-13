using System.Diagnostics.CodeAnalysis;
using Models.Domain;

namespace Models.Helpers
{
    public class EdgeComparator : IEqualityComparer<Edge>
    {
        public bool Equals(Edge x, Edge y)
        {
            if (x == null || y == null) return false;

            return x.V.Equals(y?.V) && x.U.Equals(y?.U) || x.V.Equals(y?.U) && x.U.Equals(y?.V);
        }

        public int GetHashCode([DisallowNull] Edge obj)
        {
            return obj.U.GetHashCode() ^ obj.V.GetHashCode();
        }
    }
}
