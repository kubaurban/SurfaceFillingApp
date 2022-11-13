using System.Numerics;

namespace Models.Domain
{
    public class Edge
    {
        public Vertex U { get; set; }
        public Vertex V { get; set; }

        public Vertex LowerVertex => U.Y < V.Y ? U : V;
        public Vertex HigherVertex => U.Y < V.Y ? V : U;
        public float M => Math.Abs(U.X - V.X) > 1e-10 ? (U.Y - V.Y) / (U.X - V.X) : 0;
        public Vector3 AsVector2D => new(U.X - V.X, U.Y - V.Y, 0);
        public float Length2D => new Vector2(AsVector2D.X, AsVector2D.Y).Length();

        public Edge(Vertex u, Vertex v)
        {
            U = u;
            V = v;
        }
    }
}
