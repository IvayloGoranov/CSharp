
namespace LinkedStack
{
    internal class Node<T>
    {
        internal Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        internal T Value { get; set; }
        internal Node<T> NextNode { get; set; }
    }
}
