
namespace LinkedQueue
{
    internal class Node<T>
    {
        internal Node(T value)
        {
            this.Value = value;
            this.NextNode = null;
        }

        internal T Value { get; set; }
        internal Node<T> NextNode { get; set; }
    }
}
