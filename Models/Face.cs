namespace Models
{
    public class Face
    {
        public List<Edge> Edges { get; set; }

        public Face(List<Edge> edges)
        {
            Edges = edges;
        }
    }
}
