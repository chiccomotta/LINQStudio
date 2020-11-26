using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LINQStudio
{
    public sealed class KeyValuePairBuilder
    {
        private readonly List<KeyValuePair<string, string>> KeyValuePairs = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Costruisco una lista di coppie chiave/valore leggendo le proprietà di un oggetto passato in input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> BuildKeyValuePair<T>(T instance)
            where T : class, new()
        {
            // get all class properties 
            var properties = instance.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // loop on properties
            foreach (PropertyInfo prop in properties)
            {
                // Property Type 
                Type t = instance.GetType().GetProperty(prop.Name)?.PropertyType;

                // get property
                var property = instance.GetType().GetProperty(prop.Name);

                if (IsPrimitiveType(t))
                {
                    var value = property.GetValue(instance) != null
                        ? property.GetValue(instance).ToString()
                        : string.Empty;

                    var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .Cast<DisplayNameAttribute>().Single();
                    string displayName = attribute.DisplayName;

                    KeyValuePairs.Add(new KeyValuePair<string, string>(displayName, value));
                }
                else if (t.IsClass)
                {
                    var value = property.GetValue(instance);

                    // recursion                    
                    if (value != null)
                        BuildKeyValuePair(value);
                }
            }

            return KeyValuePairs;
        }


        private static bool IsPrimitiveType(Type t)
        {
            return t.IsPrimitive || t == typeof(Decimal) || t == typeof(String) || t == typeof(DateTime) || t == typeof(Guid);
        }
    }    
}