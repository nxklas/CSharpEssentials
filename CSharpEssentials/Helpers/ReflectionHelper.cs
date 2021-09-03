using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpEssentials.Helpers
{
    /// <summary>
    /// Represents a helper class for reflective enumerators
    /// </summary>
    /// <remarks>Code from: <see href="https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class/6944605"/>,
    /// <br>ansered by Jacobs Data Solutions, called on 03.09.2021 at 11:32PM</br></remarks>
    public static class ReflectiveEnumerator
    {
        /// <summary>
        /// Gets all derived classes from base <see cref="Type"/> <typeparamref name="T"/> and initializes them
        /// </summary>
        /// <typeparam name="T">The base <see cref="Type"/></typeparam>
        /// <param name="constructorArgs">Arguments of the constructor which classes must implement or <see langword="null"/> if no arguments are in the constructor</param>
        /// <returns>A <see cref="IEnumerable{T}"/> which contains all classes which inherit from <typeparamref name="T"/> and whose constructors exhibit <paramref name="constructorArgs"/>' content</returns>
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            IList<T> spottedClasses = new List<T>();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                spottedClasses.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            return spottedClasses;
        }
    }
}
