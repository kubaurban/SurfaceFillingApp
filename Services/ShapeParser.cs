using Models.Abstract;
using Models.Domain;
using Models.Helpers;
using ObjLoader.Loader.Loaders;
using Services.Abstract;

namespace Services
{
    public class ShapeParser : IShapeParser
    {
        private readonly IShapeManager _shapeManager;

        public ShapeParser(IShapeManager shapeManager)
        {
            _shapeManager = shapeManager;
        }

        /// <summary>
        /// Using loader from https://github.com/chrisjansson/ObjLoader
        /// </summary>
        /// <param name="path"></param>
        public void LoadObj(string path)
        {
            var objLoader = new ObjLoaderFactory().Create();
            var result = objLoader.Load(new FileStream(@path, FileMode.Open));

            var faces = result.Groups.First().Faces;
            var edgeDictionary = new HashSet<Edge>(new EdgeComparator());


            foreach (var f in faces)
            {
                var edges = new List<Edge>();

                var lastVertex = result.Vertices[f[^1].VertexIndex - 1];
                var lastNormal = result.Normals[f[^1].NormalIndex - 1];
                var prev = new Vertex(lastVertex.X, lastVertex.Y, lastVertex.Z, new(lastNormal.X, lastNormal.Y, lastNormal.Z));

                var size = f.Count;
                for (int i = 0; i < size; i++)
                {
                    var v = result.Vertices[f[i].VertexIndex - 1];
                    var n = result.Normals[f[i].NormalIndex - 1];
                    var next = new Vertex(v.X, v.Y, v.Z, new(n.X, n.Y, n.Z));

                    var e = new Edge(prev, next);
                    if (edgeDictionary.TryGetValue(e, out var edge))
                    {
                        e = edge;
                    }
                    else
                    {
                        edgeDictionary.Add(e);
                    }
                    edges.Add(e);
                    prev = next;
                }

                _shapeManager.AddFace(new Face(edges));
            }
        }
    }
}
