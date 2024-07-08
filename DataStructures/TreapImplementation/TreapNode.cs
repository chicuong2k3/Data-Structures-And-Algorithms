

using DataStructures.Abstracts;

namespace DataStructures.TreapImplementation
{
    public class TreapNode : TreeNode
    { 
        private readonly Random randomizer = new Random();
        public double Priority { get; set; }

        public TreapNode(int key, TreapNode? parent = null, TreapNode? left = null, TreapNode? right = null)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
            Priority = randomizer.NextDouble();
        }

        public override string ToString()
        {
            return $"{Key}({Priority.ToString("#.##")})";
        }
    }
}
