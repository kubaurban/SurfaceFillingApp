namespace Models
{
    public class Edge
    {
        public Vertex U { get; set; }
        public Vertex V { get; set; }

        public Vertex LowerVertex => U.Y > V.Y ? U : V;
        public Vertex HigherVertex => U.Y > V.Y ? V : U;
        public float M => Math.Abs(U.X - V.X) > 1e-10 ? (U.Y - V.Y) / (U.X - V.X) : 0;

        public Edge(Vertex u, Vertex v)
        {
            U = u;
            V = v;
        }
    }
}
