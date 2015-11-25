using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAlien
{
    /// <summary>
    /// FactoryAlien main class that defines object factories.
    /// </summary>
    public static class FactoryAlien
    {
        /// <summary>
        /// Creates a new Factory to create random objects.
        /// </summary>
        /// <typeparam name="T">Type that the factory will create random instances.</typeparam>
        /// <returns>A new Factory of defined type.</returns>
        public static IFactory<T> Define<T>()
        where T : class, new()
        {
            return new Factory<T>();
        }

    }
}
