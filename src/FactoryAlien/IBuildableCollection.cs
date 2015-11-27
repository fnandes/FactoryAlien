using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAlienDotNet
{
    /// <summary>
    /// Collection of randomly generated objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBuildableCollection<T> : IEnumerable<T>
        where T : class
    {
        /// <summary>
        /// Add <paramref name="count"/> elements into collection.
        /// </summary>
        /// <param name="count">Number of elements to be added.</param>
        IBuildableCollection<T> Add(int count);

        /// <summary>
        /// Add <paramref name="count"/> elements into collection 
        /// with <paramref name="transformer"/> transformation.
        /// </summary>
        /// <param name="count">Number of elements to be added.</param>
        /// <param name="transformer">Action to be performed with each added instance.</param>
        IBuildableCollection<T> Add(int count, Action<T> transformer);
    }
}
