using System.Collections.Generic;
namespace SetLibrary
{
    public static class BracesEvaluation
    {
        public static bool AreBracesCorrect(string expression)
        {
            //First check the opening and clossing braces if they exist
            if (!expression.StartsWith("{") || !expression.EndsWith("}"))
                return false;
            //Stack that will contain all the 
            Stack<char> elements = new Stack<char>();
            //Remove white space
            //expression = expression.Replace(" ", "");

            int lengthOfString = expression.Length;

            //This will keep track of the number of elements that have been evaluated
            int Count = 0;
            foreach (char character in expression)
            {
                Count++;
                if (character == '{')
                {
                    elements.Push(character);
                    continue;
                }//if we have an oppening brace

                if (character == '}')
                {
                    //Cannot have a clossing brace without an oppening brace
                    if (elements.Count <= 0)
                        return false;
                    //Keep on popping until we either have 
                    while (elements.Count > 0 && elements.Peek() != '{')
                    {
                        //Pop the elements
                        elements.Pop();
                    }
                    //If we have popped everything and have not encounterd an oppening brace
                    if (elements.Count <= 0)
                        return false;

                    //Remove the oppening brace
                    elements.Pop();

                    //Handle edge case for a string like this : 
                    //-{1,2},{3,4}
                    //-Without this condition the Brace evaluation will pass
                    if (elements.Count == 0 && Count != lengthOfString)
                        return false;

                    continue;
                }//end if oppening

                //If there's something in the stack
                //-i.e. An oppening brace
                if (elements.Count > 0)
                    elements.Push(character);
            }//for each loop

            return elements.Count == 0;
        }//CheckBraces
    }//class
}//namespace
