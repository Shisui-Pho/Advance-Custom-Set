using SetLibrary;
using System;
using SetLibrary.Generic;
namespace SetLibrary.Operations
{
    public static class SetOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setA">The current set instance</param>
        /// <param name="setB">The other set to be merged with</param>
        /// <returns>The set of type Iset<typeparamref name="T"/> that consists of all elements belonging to either set A or set B (or both)</returns>
        public static ISet<T> Union<T>(this ISet<T> setA, ISet<T> setB)
            where T : IComparable
        {
            //Return the union
            return setA.MergeWith(setB);
        }//Union
        /// <summary>
        /// The intersection of two sets A and B which are subsets of the universal set U.
        /// </summary>
        /// <typeparam name="T">Datatype which implement the IComparable interface.</typeparam>
        /// <param name="setA">The current set instance.</param>
        /// <param name="setB">The other set to intersect with</param>
        /// <returns>A subset of type Iset<typeparamref name="T"/> which includes all elements that are both in set A and Set B</returns>
        public static ISet<T> Intersection<T>(this ISet<T> setA, ISet<T> setB)
            where T : System.IComparable
        {
            if (setA.Cardinality > setB.Cardinality)
                return FindIntsersection<T>(setA, setB);
            if (setB.Cardinality > setA.Cardinality)
                return FindIntsersection<T>(setB, setA);
            return FindIntsersection<T>(setA, setB);
        }//InterSection
        private static T ConvertTo<T>(string s)
        {
            if(s.StartsWith("{") && s.EndsWith("}"))
            {
                s = s.Remove(0, 1);
                s = s.Remove(s.Length - 1);
            }//end if
            try
            {
                return (T)Convert.ChangeType(s, typeof(T));
            }//try to convert
            catch
            {
                return default(T);
            }//end catch
        }//ConvertToT
        private static ISet<T> FindIntsersection<T>(ISet<T> setA, ISet<T> setB)
            where T : IComparable
        {
            ISet<T> intersection = new GenericSet<T>(setA.Settings);
            for (int i = 0; i < setB.Cardinality; i++)
            {
                ISetTree<T> tree = setB[i];
                if (tree.IsInRoot)
                {
                    T item = ConvertTo<T>(tree.ToString());
                    if (setA.Contains(item) && item != null)
                        intersection.AddElement(item);
                }//end if not in the root
                else if(setA.Contains(setB[i]))
                        intersection.AddElement(setB[i]);
            }//end for
            return intersection;
        }//FindIntserSection
        /// <summary>
        /// The set that includes all the elements of the universal set that are not present in the given set.
        /// </summary>
        /// <typeparam name="T">Datatype</typeparam>
        /// <param name="setA">The current instance that exists in the universal set</param>
        /// <param name="universalSet">The universal set of which setA exists in.</param>
        /// <returns>A new set of type Iset<typeparamref name="T"/> that contains the complement elements.</returns>
        public static ISet<T> Complement<T>(this ISet<T> setA, ISet<T> universalSet, out bool isUniversal)
            where T : IComparable
        {
            //Assume that it is universal
            isUniversal = true;
            //One way to test if the universal set is universal to set A is to take the intersection of the two set's.
            //-If the result is not setA then the universal set is not universal to setA

            //Take the intersection
            ISet<T> setC = universalSet.Intersection(setA);

            //Check if setC is equal to set A
            if(setC.ToString() == setA.ToString())
                return universalSet.Difference(setA);

            //Else return null
            isUniversal = false;
            return default(ISet<T>);
        }//Complement
        /// <summary>
        /// The difference between the two sets, A and B, written as A ∖ B or A − B.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setA">The current instance of the set, will be SetA</param>
        /// <param name="setB">The set which will be removed from setA, will be SetB</param>
        /// <returns> A set of type Iset<typeparamref name="T"/> that contains elements of A that are NOT in B</returns>
        public static ISet<T> Difference<T>(this ISet<T> setA, ISet<T> setB)
            where T : IComparable
        {
            //The methods reads as setA without setB

            //Create the new set
            ISet<T> difference = new GenericSet<T>(setA.Settings);

            //If they are the same set, then the difference will be nothing
            if (setA.ToString() == setB.ToString())
                return difference;
            for(int i =0; i< setA.Cardinality; i++)
            {
                ISetTree<T> tree = setA[i];
                if (tree.IsInRoot)
                {
                    T item = ConvertTo<T>(tree.ToString());
                    if (!setB.Contains(item) && item != null)
                        difference.AddElement(item);
                }//end if not in the root
                else if (!setB.Contains(setA[i]))
                    difference.AddElement(setA[i]);
            }//end for

            //Return the results
            return difference;
        }//Difference
    }//class
}//namespace
