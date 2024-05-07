using System;
using System.Collections.Generic;
namespace SetLibrary
{
    public static class ISetTreeExtensions
    {
        public static List<T> ToListRootElements<T>(this ISetTree<T> tree)
            where T : IComparable
        {
            List<T> elements = new List<T>();
            foreach (var item in tree.GetRootElementsEnumarator())
                elements.Add(item);
            return elements;
        }//ToListRootElements
        public static List<ISetTree<T>> ToListSubSets<T>(this ISetTree<T> tree)
            where T : IComparable
        {
            List<ISetTree<T>> trees = new List<ISetTree<T>>();
            foreach (var item in tree.GetSubsetsEnumarator())
                trees.Add(item);
            return trees;
        }//class
        public static T FindFirstRootElement<T>(this ISetTree<T> tree)
            where T : IComparable
        {
            foreach (var item in tree.GetRootElementsEnumarator())
            {
                //Return the very first item
                return item;
            }
            return default(T);
        }//FindFirstRootElement
        public static T GetRootElementByIndex<T>(this ISetTree<T> tree, int index)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in tree.GetRootElementsEnumarator())
            {
                if (index == count)
                    return item;
                count++;
            }
            return default(T);
        }//GetRootValueByIndex
        public static ISetTree<T> GetSubSetElementByIndex<T>(this ISetTree<T> tree, int index)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in tree.GetSubsetsEnumarator())
            {
                if (index == count)
                    return item;
                count++;
            }
            return default(ISetTree<T>);
        }//GetSubSetElementByIndex
    }//class
}//namespace