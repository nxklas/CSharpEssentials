using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpEssentials.Helpers
{
    /// <summary>
    /// Represents a helper class for reflective enumerators
    /// </summary>
    public static class ReflectiveEnumerator
    {
        /// <summary>
        /// Gets all derived classes from base type <typeparamref name="T"/> and initializes them
        /// </summary>
        /// <typeparam name="T">The base type</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> which contains all classes which inherit from <typeparamref name="T"/> and whose constructors exhibit <paramref name="constructorArgs"/>' content</returns>
        public static IEnumerable<T> GetEnumerableOfType<T>() where T : class => GetEnumerableOfType<T>(null);

        /// <summary>
        /// Gets all derived classes from base type <typeparamref name="T"/> and initializes them
        /// </summary>
        /// <remarks>Code from: <see href="https://stackoverflow.com/questions/5411694/get-all-inherited-classes-of-an-abstract-class/6944605"/>,
        /// <br>ansered by Jacobs Data Solutions, called on 03.09.2021 at 11:32PM</br></remarks>
        /// <typeparam name="T">The base type</typeparam>
        /// <param name="constructorArgs">Arguments of the constructor which classes must implement or <see langword="null"/> if no arguments are in the constructor</param>
        /// <returns>An <see cref="IEnumerable{T}"/> which contains all classes which inherit from <typeparamref name="T"/> and whose constructors exhibit <paramref name="constructorArgs"/>' content</returns>
        public static IEnumerable<T> GetEnumerableOfType<T>(params object?[]? constructorArgs) where T : class
        {
            var spottedClasses = new List<T>();

            foreach (var type in Assembly.GetAssembly(typeof(T))!.GetTypes()
                .Where(t => t != null && t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T))))
                spottedClasses.Add((T)Activator.CreateInstance(type, constructorArgs)!);

            return spottedClasses;
        }

        /// <summary>
        /// Gets all implemented classes from interface type <typeparamref name="TInterface"/> and initializes them
        /// </summary>
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> which contains all classes which implement <typeparamref name="TInterface"/></returns>
        /// <exception cref="Exception">If <typeparamref name="TInterface"/> is not an interface</exception>
        public static IEnumerable<TInterface> GetImplementationsOfType<TInterface>() => GetImplementationsOfType<TInterface>(null);

        /// <summary>
        /// Gets all implemented classes from interface type <typeparamref name="TInterface"/> and initializes them
        /// </summary>
        /// <typeparam name="TInterface">The interface type</typeparam>
        /// <param name="constructorArgs">Arguments of the constructor which classes must implement or <see langword="null"/> if no arguments are in the constructor</param>
        /// <returns>An <see cref="IEnumerable{T}"/> which contains all classes which implement <typeparamref name="TInterface"/></returns>
        /// <exception cref="Exception">If <typeparamref name="TInterface"/> is not an interface</exception>
        public static IEnumerable<TInterface> GetImplementationsOfType<TInterface>(params object?[]? constructorArgs)
        {
            var interfaceType = typeof(TInterface);

            if (!interfaceType.IsInterface)
                throw new InvalidOperationException($"Type parameter {nameof(TInterface)} must be an interface type");

            var spottedClasses = new List<TInterface>();

            foreach (var type in Assembly.GetAssembly(interfaceType)!.GetTypes()
                .Where(t => t != null && t.IsClass && !t.IsAbstract && t.IsAssignableTo(interfaceType)))
                spottedClasses.Add((TInterface)Activator.CreateInstance(type, constructorArgs)!);

            return spottedClasses;
        }
    }
}