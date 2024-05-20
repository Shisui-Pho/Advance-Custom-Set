using System;
using System.Collections.Generic;

namespace SetLibrary
{
    public static class ISetExtensions
    {
        public static List<T> ToListRootElements<T>(this ICSet<T> set)
           where T : IComparable
        {
            List<T> elem = new List<T>();
            for (int i = 0; i <set.Cardinality ; i++)
            {
                ISetTree<T> tree = set[i];
                if (tree.IsInRoot)
                {
                    elem.Add(tree.FindFirstRootElement());
                }
                else //This means that all of our root elements have been visited
                    break;
            }//end for
            return elem;
        }//ToListRootElements
        public static List<ISetTree<T>> ToListSubSets<T>(this ICSet<T> set)
            where T : IComparable
        {
            List<ISetTree<T>> trees = new List<ISetTree<T>>();
            for(int i = 0; i < set.Cardinality; i++)
            {
                ISetTree<T> tree = set[i];
                if (!tree.IsInRoot)
                    trees.Add(tree);
            }
            return trees;
        }//class
        public static T FindFirstRootElement<T>(this ICSet<T> set)
            where T : IComparable
        {
            ISetTree<T> tree = set[0];
            if (tree.IsInRoot)
                return tree.FindFirstRootElement();

            return default(T);
        }//FindFirstRootElement
        /// <summary>
        /// Get the element in the current set base on the element's index which is zero base. Subsets will be ignored.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set">The current instatnce of the set.</param>
        /// <param name="index">Zero base index of the element(Subsets will be ignored)</param>
        /// <returns>An element of Type <typeparamref name="T"/>.</returns>
        public static T GetRootElementByIndex<T>(this ICSet<T> set, int index)
            where T : IComparable
        {
            int count = 0;
            for(int i = 0; i < set.Cardinality; i++)
            {
                ISetTree<T> tree = set[i];
                if (!tree.IsInRoot)
                    break;

                if (count == index)
                    return tree.FindFirstRootElement();
                count++;
            }//end for
            return default(T);
        }//GetRootValueByIndex
        /// <summary>
        /// Get the subset in the current set base on the subset index which is zero base(exluding root elements).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set">The current instatnce of the set.</param>
        /// <param name="index">Zero base index of the subset(exluding the root elements)</param>
        /// <returns>A subset Tree</returns>
        public static ISetTree<T> GetSubSetElementByIndex<T>(this ICSet<T> set, int index)
            where T : IComparable
        {
            int count = 0;
            for (int i = 0; i < set.Cardinality; i++)
            {
                ISetTree<T> tree = set[i];
                if (!tree.IsInRoot)
                {
                    if (count == index)
                        return tree;
                    count++;
                }//end if not root
            }//end for
            return default(ISetTree<T>);
        }//GetSubSetElementByIndex
    }//class
}//namespace