using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_Management.FindingCallNumbers
{
    public class Tree<T>
        where T : IComparable<T>
    {
        [JsonPropertyName("root")]
        public Node<T> Root { get; set; }

        public Tree()
        {
            Root = null;
        }

        public Tree(T root)
        {
            Root = new Node<T>(root);
        }

        // Add children nodes to a specific parent node
        public void AddChildren(T parent, List<T> children)
        {
            Node<T> parentNode = FindNode(parent);
            if (parent != null)
            {
                foreach (T child in children)
                {
                    parentNode.AddChild(child);
                }
            }
        }

        private Node<T> FindNode(T value)
        {
            return FindNode(Root, value);
        }

        private Node<T> FindNode(Node<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Value.Equals(value))
            {
                return currentNode;
            }

            foreach (Node<T> child in currentNode.Children)
            {
                Node<T> foundNode = FindNode(child, value);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }

        // Get path to a node
        public List<T> GetPathToRandomNode(T value)
        {
            Node<T> node = FindNode(value);
            if (node == null)
            {
                return null; // Node not found
            }

            List<T> path = new List<T>();
            GetPathToNode(Root, node, path);
            return path;
        }

        private bool GetPathToNode(Node<T> current, Node<T> target, List<T> path)
        {
            if (current == null)
            {
                return false;
            }

            if (current.Equals(target))
            {
                path.Add(current.Value);
                return true;
            }

            path.Add(current.Value);

            foreach (Node<T> child in current.Children)
            {
                if (GetPathToNode(child, target, path))
                {
                    return true;
                }
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }

        public T GetRandom(int level)
        {
            Node<T> current = Root;

            for (int i = 0; i < level; i++)
            {
                Random r = new Random();

                int index = r.Next(current.Children.Count);

                current = current.Children[index];
            }
            return current.Value;
        }

        public List<T> GetChildren(T parentValue)
        {
            Node<T> parentNode = FindNode(parentValue);
            if (parentNode != null)
            {
                List<T> childrenList = new List<T>();
                foreach (Node<T> child in parentNode.Children)
                {
                    childrenList.Add(child.Value);
                }
                return childrenList;
            }
            return null; // Parent node not found or has no children
        }
    }
}
