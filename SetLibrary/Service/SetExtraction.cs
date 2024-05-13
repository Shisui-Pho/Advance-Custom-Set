using SetLibrary.Generic;
using SetLibrary.Objects_Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary
{
    public static class SetExtraction
    {
        public static ISetTree<T> Extract<T>(string expression, SetExtractionSettings<T> settings)
            where T : IComparable
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
                List<T> rootElements = SortAndRemoveDuplicates(expression, settings);
                return new CSetTree<T>(rootElements,settings);
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
                    i = start;
                    //Clear the stack and queue
                    oppeningBraces = new Queue<int>();
                    clossingBraces = new Stack<int>();

                    subsets.Push(subset);
                }//This is a subset in the same level as the rest of the individual elements
            }//end for

            //Create the set tree with the root element
            ISetTree<T> tree = Extract(expression, settings);//(SortAndRemoveDuplicates(expression));

            //Loop through all the subsets and create their respective trees and add them as a subtree to the root "tree"
            while (subsets.Count > 0)
            {
                string ex = subsets.Pop();
                tree.AddSubSetTree(Extract(ex, settings));
            }//Build for all the elements
            return tree;
        }//Extract
        public static List<T> SortAndRemoveDuplicates<T>(string rootElements, SetExtractionSettings<T> settings)
            where T : IComparable
        {
            //Get the elements
            string[] elements = rootElements.Split(new string[] { settings.ElementSeperator }, StringSplitOptions.RemoveEmptyEntries);

            //Create a list of elements that are unique
            List<T> uniqueElements = new List<T>();

            //Loop through all elements
            foreach (string element in elements)
            {
                T item = default;
                if (element == "\u2205")
                    continue;
                try
                {
                    //First check if the value is an objects that uses the IObjects convert class
                    if(settings.PlaceHolder != null && settings.PlaceHolder is IObjectConverter<T>)
                    {
                        if (element == " ")
                            continue;
                        T placeHolder = settings.PlaceHolder;
                        item = (((IObjectConverter<T>)placeHolder).ToObject(element, settings));
                    }
                    else
                    {
                        //Remove spaces
                        string _elem = element.Replace(" ", "");

                        //If it is a space then continue.
                        if (_elem == "")
                            continue;
                        item = (T)Convert.ChangeType(_elem, typeof(T));
                    }
                        
                }//end try
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
    }//class
}//namespace