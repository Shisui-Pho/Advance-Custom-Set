using System;
using System.Collections.Generic;
namespace SetLibrary.SetExtensions
{
    public static class ISetTreeExtensions
    {
        public static List<T> ToListRootElements<T>(this ISetTree<T> tree)
            where T : IComparable
        {
            List<T> elements = new List<T>();
            foreach (var item in tree)
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
            foreach (var item in tree)
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

            foreach (var item in tree)
            {
                if (index == count)
                    return item;
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
            }
            return default(ISetTree<T>);
        }//GetSubSetElementByIndex
    }//class
}//namespace