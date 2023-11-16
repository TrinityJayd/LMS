using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_Management.FindingCallNumbers
{
    public class Node<T>
    {
        [JsonPropertyName("value")]
        public T Value { get; set; }

        [JsonPropertyName("children")]
        public List<Node<T>> Children { get; set; }

        public Node()
        {
            Children = new List<Node<T>>();
        }

        public Node(T value)
        {
            Value = value;
            Children = new List<Node<T>>();
        }

        public void AddChild(T value)
        {
            Children.Add(new Node<T>(value));
        }
    }
}
