namespace Problem2_ReformatYourOwnCode_ReFormatedd
{
    using System;

    /// <summary>
    /// The class shows the usage of the functions provided by Custom implementation of Tail(Linked List) structure.
    /// </summary>
    public class CustomLinkedListExample
    {
        public static void Main(string[] args)
        {
            var customLinkedList = new CustomLinkedList<int>();

            Console.WriteLine("count = {0}, array = {1}", customLinkedList.Count, string.Join(" ", customLinkedList));
            customLinkedList.Add(1);
            customLinkedList.Add(2);
            customLinkedList.Add(3);
            customLinkedList.Add(1);
            customLinkedList.Add(2);

            Console.WriteLine("count = {0}, array = {1}", customLinkedList.Count, string.Join(" ", customLinkedList));

            Console.WriteLine("first index of (2): " + customLinkedList.FirstIndexOf(2));

            Console.WriteLine("last index of (2): " + customLinkedList.LastIndexOf(2));

            customLinkedList.Remove(2);

            Console.WriteLine("count = {0}, array = {1}", customLinkedList.Count, string.Join(" ", customLinkedList));
        }
    }
}
