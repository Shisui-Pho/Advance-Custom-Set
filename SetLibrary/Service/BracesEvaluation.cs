using System.Collections.Generic;
namespace Sets
{
    internal static class BracesEvaluation
    {
        public static bool AreBracesCorrect(string expression)
        {
            //Stack that will contain all the 
            Stack<char> elements = new Stack<char>();
            //{5,{6,7,{9,6,{5,5}}}}
            foreach (char character in expression)
            {
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
