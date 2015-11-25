using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryAlien
{
    /// <summary>
    /// Creates new <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T">Object type to create new random instances.</typeparam>
    public class Factory<T> : IFactory<T>
        where T : class, new()
    {
        internal const string STRING_TYPE = "String";
        internal const string DOUBLE_TYPE = "Double";
        internal const string BYTE_TYPE = "Byte";
        internal const string SHORT_TYPE = "Int16";
        internal const string INTEGER_TYPE = "Int32";
        internal const string LONG_TYPE = "Int64";
        internal const string DECIMAL_TYPE = "Decimal";
        internal const string DATETIME_TYPE = "DateTime";
        internal const string BOOLEAN_TYPE = "Boolean";
        internal const string FLOAT_TYPE = "Single";
        internal const string ENUM_TYPE = "Enum";
        internal const string NULLABLE_TYPE = "Nullable`1";

        /// <summary>
        /// Create one instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        public T CreateOne()
        {
            var newObject = new T();
            FetchWithRandomData(newObject);

            return newObject;
        }

        /// <summary>
        /// Create one instance of <typeparamref name="T"/> and set custom user values with transformer action.
        /// </summary>
        /// <param name="transformer">Action that will set custom user values to created instances.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        public T CreateOne(Action<T> transformer)
        {
            var newObject = CreateOne();
            transformer(newObject);

            return newObject;
        }

        /// <summary>
        /// Create a list of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="count">Number of instances to create.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        public IBuildableCollection<T> CreateList(int count)
        {
            var objectList = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                objectList.Add(CreateOne());
            }

            return new BuildableCollection<T>(objectList);
        }

        /// <summary>
        /// Create a list of <typeparamref name="T"/> and set custom user values with transformer action.
        /// </summary>
        /// <param name="transformer">Action that will set custom user values to created instances.</param>
        /// <param name="count">Number of instances to create.</param>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        public IBuildableCollection<T> CreateList(int count, Action<T> transformer)
        {
            var objectList = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                objectList.Add(CreateOne(transformer));
            }

            return new BuildableCollection<T>(objectList);
        }

        public void FetchWithRandomData(T createdObject)
        {
            var objectType = typeof(T);
            var properties = from prop in objectType.GetProperties()
                             where prop.CanWrite
                             select prop;

            if (properties != null && properties.Any())
            {
                foreach (var property in properties)
                {
                    SetRandomValue(objectType, property, createdObject);
                }
            }
        }

        public void SetRandomValue(Type objectType, PropertyInfo property, object obj)
        {
            var propertyType = property.PropertyType;

            if (propertyType.Name == NULLABLE_TYPE)
            {
                propertyType = property.PropertyType.GenericTypeArguments[0];
            }

            switch (propertyType.Name)
            {
                case STRING_TYPE:
                    property.SetValue(obj, Randomizer.String());
                    break;
                case BYTE_TYPE:
                    property.SetValue(obj, Randomizer.Byte());
                    break;
                case DOUBLE_TYPE:
                    property.SetValue(obj, Randomizer.Double());
                    break;
                case SHORT_TYPE:
                    property.SetValue(obj, Randomizer.Short());
                    break;
                case INTEGER_TYPE:
                    property.SetValue(obj, Randomizer.Int());
                    break;
                case LONG_TYPE:
                    property.SetValue(obj, Randomizer.Long());
                    break;
                case DECIMAL_TYPE:
                    property.SetValue(obj, Randomizer.Decimal());
                    break;
                case FLOAT_TYPE:
                    property.SetValue(obj, Randomizer.Float());
                    break;
                case DATETIME_TYPE:
                    property.SetValue(obj, Randomizer.DateTime());
                    break;
                case BOOLEAN_TYPE:
                    property.SetValue(obj, Randomizer.Boolean());
                    break;
                default:
                    if (propertyType.IsEnum)
                    {
                        property.SetValue(obj, Randomizer.Enum(enumType: propertyType));
                    }
                    break;
            }
        }
    }
}
