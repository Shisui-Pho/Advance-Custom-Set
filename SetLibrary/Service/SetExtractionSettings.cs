using System;
using System.Collections.Generic;
using System.Linq;
namespace SetLibrary.Generic
{
    public class SetExtractionSettings<T>
        where T : IComparable
    {
        private readonly char seperator;
        public SetExtractionSettings(char _seperator)
        {
            seperator = _seperator;
        }
        public ISetTree<T>  Extract(string expression)
        {
            return SetExtractionSettings<T>.Extract(expression, this.seperator.ToString());
        }//BuildTree
        public static ISetTree<T> Extract(string expression, string seperator)
        {
            //Remove the first and last brace
            if (expression.StartsWith("{") && expression.EndsWith("}"))
            {
                expression = expression.Remove(0, 1);
                expression = expression.Remove(expression.Length - 1);
            }//end removing oppening and clossing braces

            //Base case
            if (!expression.Contains("}") && !expression.Contains("{"))
            {
               List<T> rootElements = SortAndRemoveDuplicates(expression,seperator);
                return new CSetTree<T>(rootElements);
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

                if (oppeningBraces.Count > 0 && oppeningBraces.Count == clossingBraces.Count)//&& (i + 1) < expression.Length)
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
            ISetTree<T> tree = Extract(expression, seperator);//(SortAndRemoveDuplicates(expression));

            //Loop through all the subsets and create their respective trees and add them as a subtree to the root "tree"
            while (subsets.Count > 0)
            {
                string ex = subsets.Pop();
                tree.AddSubSetTree(Extract(ex, seperator));
            }//Build for all the elements
            return tree;
        }//Extract
        public static List<T> SortAndRemoveDuplicates(string rootElements,string seperator)
        {
            rootElements = rootElements.Replace(" ", "");
            //Get the elements
            string[] elements = rootElements.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);

            //Create a list of elements that are unique
            List<T> uniqueElements = new List<T>();

            //Loop through all elements
            foreach (string element in elements)
            {
                T item = default;
                try
                {
                    item = (T)Convert.ChangeType(element, typeof(T));
                }
                catch
                {
                    throw;
                }
                IEqualityComparer<T> c = EqualityComparer<T>.Default;
                if (!uniqueElements.Contains(item, c))//check if it is unique
                    uniqueElements.Add(item);//add if unique
            }//end foreach


            uniqueElements.Sort();
            return uniqueElements;
        }//SortAndRemoveDuplicates
    }//Eval
}
