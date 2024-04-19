using System;
using System.Collections.Generic;
namespace Advanced_Sets.Set
{
    public static class TreeExtraction
    {
        /// <summary>
        /// This method takes in a string that has been evaluated for braces and then do some extraction to build a tree of relation of all the elements
        /// </summary>
        /// <param name="expression">An evaluated string expression.</param>
        /// <returns>A set tree of all the elements and nested sets</returns>
        public static CSetTree Extract(string expression)
        {
            //Remove the first and last brace
            if (expression.StartsWith("{") && expression.EndsWith("}"))
            {
                expression = expression.Remove(0, 1);
                expression = expression.Remove(expression.Length - 1);
            }//end removing oppening and clossing braces

            //Base case
            if(!expression.Contains("}") && !expression.Contains("{"))
            {
                string rootElement = SortAndRemoveDuplicates(expression, out int count);
                return new CSetTree(rootElement, count);
            }//end expression


            //This queue will hold all the oppening braces index in an ascending order
            Queue<int> oppeningBraces = new Queue<int>();

            //The stack will hold all the closing braces index in a descending order
            Stack<int> clossingBraces = new Stack<int>();

            //This will contain the subsets that are in the first nesting level/element level
            Stack<string> subsets = new Stack<string>();

            //Loop through all the characters
            for (int i = 0; i < expression.Length; i++) 
            { 
                if (expression[i] == '{')
                    oppeningBraces.Enqueue(i);
                if (expression[i] == '}')
                    clossingBraces.Push(i);

                if (oppeningBraces.Count > 0 && oppeningBraces.Count == clossingBraces.Count )//&& (i + 1) < expression.Length)
                {
                    //Only extract the outer most elements
                    int start = oppeningBraces.Dequeue();
                    int end = clossingBraces.Pop();

                    int length = end - start + 1;

                    string subset = expression.Substring(start, length);

                    //This will also remove duplicates, since a set must not have duplicates
                    expression = expression.Replace(subset, "");
                    i = -1;
                    //Clear the stack and queue
                    oppeningBraces = new Queue<int>();
                    clossingBraces = new Stack<int>();

                    subsets.Push(subset);
                }//This is a subset in the same level as the rest of the individual elements
            }//end for

            //Create the set tree with the root element
            CSetTree tree = Extract(expression);//(SortAndRemoveDuplicates(expression));

            //Loop through all the subsets and create their respective trees and add them as a subtree to the root "tree"
            while(subsets.Count > 0)
            {
                string ex = subsets.Pop();
                tree.AddSubSetTree(Extract(ex));
            }//Build for all the elements
            return tree;
        }//BuildTree
        private static string SortAndRemoveDuplicates(string rootElements, out int count)
        {
            rootElements = rootElements.Replace(" ", "");
            //Get the elements
            string[] elements = rootElements.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //Create a list of elements that are unique
            List<string> uniqueElements = new List<string>();

            //Loop through all elements
            foreach (string element in elements)
                if (!uniqueElements.Contains(element))//check if it is unique
                    uniqueElements.Add(element);//add if unique

            uniqueElements.Sort();
            count = uniqueElements.Count;
            return String.Join(",", uniqueElements.ToArray());//Return the dorted set
        }//SortAndRemoveDuplicates
    }//Eval
}//namespace