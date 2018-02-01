
namespace DoublyLinkedList
{
    internal class ListNode<T>
    {
        internal ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public ListNode<T> NextNode { get; internal set; }

        public ListNode<T> PreviousNode { get; internal set; }
    }
}
