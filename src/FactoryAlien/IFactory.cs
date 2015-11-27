using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAlienDotNet
{
    /// <summary>
    /// Creates new <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T">Object type to create new random instances.</typeparam>
    public interface IFactory<T>
        where T : class,new()
    {
        /// <summary>
        /// Create one instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        T CreateOne();

        /// <summary>
        /// Create one instance of <typeparamref name="T"/> and set custom user values with transformer action.
        /// </summary>
        /// <param name="transformer">Action that will set custom user values to created instances.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        T CreateOne(Action<T> transformer);

        /// <summary>
        /// Create a list of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="count">Number of instances to create.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        IBuildableCollection<T> CreateList(int count);

        /// <summary>
        /// Create a list of <typeparamref name="T"/> and set custom user values with transformer action.
        /// </summary>
        /// <param name="transformer">Action that will set custom user values to created instances.</param>
        /// <param name="count">Number of instances to create.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        IBuildableCollection<T> CreateList(int count, Action<T> transformer);
    }
}
