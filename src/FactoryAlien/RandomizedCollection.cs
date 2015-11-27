using System;
using System.Collections;
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
    public class BuildableCollection<T> : IBuildableCollection<T>
        where T : class, new()
    {
        private List<T> _baseList;
        private readonly IFactory<T> _factory;

        public BuildableCollection(List<T> baseList)
        {
            _factory = FactoryAlien.Define<T>();
            _baseList = baseList;
        }

        /// <summary>
        /// Add <paramref name="count"/> elements into collection.
        /// </summary>
        /// <param name="count">Number of elements to be added.</param>
        public IBuildableCollection<T> Add(int count)
        {
            var itemsToAdd = _factory.CreateList(count);

            _baseList.AddRange(itemsToAdd);

            return this;
        }

        /// <summary>
        /// Add <paramref name="count"/> elements into collection 
        /// with <paramref name="transformer"/> transformation.
        /// </summary>
        /// <param name="count">Number of elements to be added.</param>
        /// <param name="transformer">Action to be performed with each added instance.</param>
        public IBuildableCollection<T> Add(int count, Action<T> transformer)
        {
            var itemsToAdd = _factory.CreateList(count, transformer);

            _baseList.AddRange(itemsToAdd);

            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _baseList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _baseList.GetEnumerator();
        }
    }
}
