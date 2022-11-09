namespace Models
{
    public class Edge
    {
        public Vertex U { get; set; }
        public Vertex V { get; set; }

        public Edge(Vertex u, Vertex v)
        {
            U = u;
            V = v;
        }
    }
}
