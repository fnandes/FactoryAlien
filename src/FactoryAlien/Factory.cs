using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryAlienDotNet
{
    /// <summary>
    /// Creates new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Object type to generate new instances.</typeparam>
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
        /// Create one instance of <typeparamref name="T"/> and set custom values with an <see cref="Action"/>.
        /// </summary>
        /// <param name="transformer"><see cref="Action"/> thats intercept object creation and set custom values.</param>
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
        /// Create a list of <typeparamref name="T"/> and set custom user values with an <see cref="Action"/>.
        /// </summary>
        /// <param name="transformer"><see cref="Action"/> thats intercept object creation and set custom values.</param>
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

        private void FetchWithRandomData(T createdObject)
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

        private void SetRandomValue(Type objectType, PropertyInfo property, object obj)
        {
            var propertyType = property.PropertyType;

            if (propertyType.Name == NULLABLE_TYPE)
            {
                propertyType = property.PropertyType.GenericTypeArguments[0];
            }

            switch (propertyType.Name)
            {
                case STRING_TYPE:
                    property.SetValue(obj, Any.String());
                    break;
                case BYTE_TYPE:
                    property.SetValue(obj, Any.Byte());
                    break;
                case DOUBLE_TYPE:
                    property.SetValue(obj, Any.Double());
                    break;
                case SHORT_TYPE:
                    property.SetValue(obj, Any.Short());
                    break;
                case INTEGER_TYPE:
                    property.SetValue(obj, Any.Int());
                    break;
                case LONG_TYPE:
                    property.SetValue(obj, Any.Long());
                    break;
                case DECIMAL_TYPE:
                    property.SetValue(obj, Any.Decimal());
                    break;
                case FLOAT_TYPE:
                    property.SetValue(obj, Any.Float());
                    break;
                case DATETIME_TYPE:
                    property.SetValue(obj, Any.DateTime());
                    break;
                case BOOLEAN_TYPE:
                    property.SetValue(obj, Any.Boolean());
                    break;
                default:
                    if (propertyType.IsEnum)
                    {
                        property.SetValue(obj, Any.Enum(enumType: propertyType));
                    }
                    break;
            }
        }
    }
}
