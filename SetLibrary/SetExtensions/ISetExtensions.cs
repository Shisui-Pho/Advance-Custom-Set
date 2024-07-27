using SetLibrary.Operations;
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
        /// <summary>
        /// Tests whether a set is universal to a given set.
        /// </summary>
        /// <typeparam name="T">The datatype</typeparam>
        /// <param name="universalSet">The universal set</param>
        /// <param name="subset">The subset to be contained in the universal set.</param>
        /// <returns>True if the subset is contained in the universal set</returns>
        public static bool IsUnivesalTo<T>(this ICSet<T> universalSet, ICSet<T> subset)
            where T : IComparable
        {
            //One way to test if the universal set is universal to set A is to take the intersection of the two set's.
            //-If the result is not setA then the universal set is not universal to setA

            //Take the intersection
            ICSet<T> setC = universalSet.Intersection(subset);

            //Check if setC is equal to set A
            if (setC.ToString() == subset.ToString())
                return true;

            return false;
        }//IsUnivesalTo
        /// <summary>
        /// Tests whether a set is universal to a given collection of sets.
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="universalSet">The universal set</param>
        /// <param name="subsets">The subset collection</param>
        /// <returns>True if all subsets are contained in the universal set</returns>
        public static bool IsUnivesalTo<T>(this ICSet<T> universalSet, IEnumerable<ICSet<T>> subsets)
            where T : IComparable
        {
            //One way to test if the universal set is universal to set A is to take the intersection of the two set's.
            //-If the result is not setA then the universal set is not universal to setA

            //Take the intersection of every set
            foreach (var subset in subsets)
            {
                ICSet<T> setC = universalSet.Intersection(subset);

                //Check if setC is equal to set A
                if (setC.ToString() != subset.ToString())
                    return false;
            }
            return true;
        }//IsUnivesalTo
    }//class
}//namespace