using System.Numerics;

namespace Models
{
    public struct Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector3 NormalVector { get; set; }

        public Vertex(float x, float y, float z, Vector3 normalVector)
        {
            X = x;
            Y = y;
            Z = z;
            NormalVector = normalVector;
        }

        public override bool Equals(object? other)
        {
            if (other == null) return false;

            var o = (Vertex)other;
            return X == o.X &&
                Y == o.Y &&
                Z == o.Z;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
    }
}
