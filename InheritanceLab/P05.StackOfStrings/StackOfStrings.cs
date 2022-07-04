using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count==0;
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var el in collection)
                this.Push(el);
        }
    }
}