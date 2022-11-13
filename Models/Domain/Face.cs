namespace Models.Domain
{
    public class Face
    {
        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices
        {
            get
            {
                return Edges.SelectMany(x => new List<Vertex> { x.U, x.V }).Distinct().ToList();
            }
        }
        public float Perimeter2D => Edges.Aggregate<Edge, float>(0, (perim, edge) => perim + edge.Length2D);

        public Face(List<Edge> edges)
        {
            Edges = edges;
        }
    }
}
