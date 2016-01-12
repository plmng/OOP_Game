namespace Problem2_ReformatYourOwnCode_ReFormatedd
{
    /// <summary>
    /// Represents the custom implementation of the Node of the Linked List Structure.
    /// The Node has value and is linked with (conteins) the next Node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CustomListNode<T>
    {
        public CustomListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public CustomListNode<T> NextNode { get; set; }
    }
}
