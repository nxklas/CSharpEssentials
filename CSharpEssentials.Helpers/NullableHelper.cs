using System;

namespace CSharpEssentials.Helpers
{
    public static class NullableHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>From <see href="https://stackoverflow.com/questions/374651/how-to-check-if-an-object-is-nullable"/>, answered by Marc Gravell, called on 14.01.2023 03:13AM.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullable<T>(this T obj)
        {
            if (obj == null)
                return true; // obvious

            var type = typeof(T);

            if (!type.IsValueType)
                return true; // ref-type

            if (Nullable.GetUnderlyingType(type) != null)
                return true; // Nullable<T>

            return false; // value-type
        }
    }
}