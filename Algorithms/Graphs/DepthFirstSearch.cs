using FluentAssertions;
using Xunit; 

namespace Graphs
{
    public class Node
    {
        public int Value { get; set; }
        public List<Node> Neighbors { get; set; }

        public Node(int value)
        {
            Value = value;
            Neighbors = new List<Node>();
        }
    }

    public partial class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public bool DepthFirstSearch(Node start, Node target)
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current))
                {
                    continue;
                }

                visited.Add(current);

                if (current.Value == target.Value)
                {
                    return true;
                }

                foreach (var neighbor in current.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return false;
        }
    }
    public class GraphTests
    {
        [Fact]
        public void TestDepthFirstSearch()
        {
            // Arrange
            var graph = new Graph();

            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);

            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6); ;

            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            node3.Neighbors.Add(node4);
            node4.Neighbors.Add(node5);

            // Act
            bool oneToFive = graph.DepthFirstSearch(node1, node5);
            bool oneToSix = graph.DepthFirstSearch(node1, node6);

            // Assert
            oneToFive.Should().BeTrue("because the node with value 5 is reachable from the start node");
            oneToSix.Should().BeFalse("because the node with value 6 is not in the graph");

        }


        [Fact]
        public void TestDepthFirstSearch2()
        {
            // Arrange
            var graph = new Graph();

            var node1 = new Node(1);
            var node2 = new Node(2);
   
            graph.AddNode(node1);
            graph.AddNode(node2);
       
            node1.Neighbors.Add(node2);
         
            // Act
            bool oneTo2 = graph.DepthFirstSearch(node1, node2);
          
            // Assert
            oneTo2.Should().BeTrue();
        }
    }
}