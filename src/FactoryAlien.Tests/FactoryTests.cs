using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FactoryAlien;
using FactoryAlien.Tests.Model;

namespace FactoryAlien.Tests
{
    public class FactoryTests
    {
        internal const int RANDOM_STRING_SIZE = 20;

        [Fact]
        public void CreateOne_creates_new_object()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.NotNull(createdObject);
        }

        [Fact]
        public void CreateOne_creates_new_object_with_transformation()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne(c =>
            {
                c.StringProperty = "RIO2016";
                c.IntProperty = 12345;
                c.DecimalProperty = 123.45M;
            });

            Assert.NotNull(createdObject);
            Assert.Equal(createdObject.StringProperty, "RIO2016");
            Assert.Equal(createdObject.IntProperty, 12345);
            Assert.Equal(createdObject.DecimalProperty, 123.45M);
        }

        [Fact]
        public void CreateList_creates_new_object_list()
        {
            const int LIST_SIZE = 20;
            var factory = FactoryAlien.Define<DummyObject>();

            var createdList = factory.CreateList(LIST_SIZE);

            Assert.NotNull(createdList);
            Assert.NotEmpty(createdList);
            Assert.Equal(LIST_SIZE, createdList.Count());
        }

        [Fact]
        public void CreateList_creates_new_object_list_with_transformation()
        {
            const int LIST_SIZE = 20;
            var factory = FactoryAlien.Define<DummyObject>();

            var createdList = factory.CreateList(LIST_SIZE, c =>
            {
                c.StringProperty = "RIO2016";
                c.IntProperty = 12345;
                c.DecimalProperty = 123.45M;
            });

            Assert.NotNull(createdList);
            Assert.NotEmpty(createdList);
            Assert.Equal(LIST_SIZE, createdList.Count());

            var createdObjects = createdList.ToArray();
            for (int i = 0; i < LIST_SIZE; i++)
            {
                Assert.NotNull(createdObjects[i]);
                Assert.Equal(createdObjects[i].StringProperty, "RIO2016");
                Assert.Equal(createdObjects[i].IntProperty, 12345);
                Assert.Equal(createdObjects[i].DecimalProperty, 123.45M);
            }
        }

        [Fact]
        public void generate_random_string_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.NotNull(createdObject.StringProperty);
            Assert.NotEmpty(createdObject.StringProperty);
            Assert.Equal(createdObject.StringProperty.Length, RANDOM_STRING_SIZE);
        }

        [Fact]
        public void generate_random_integer_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.IntProperty > 0);
            Assert.True(createdObject.NullableIntProperty > 0);
        }

        [Fact]
        public void generate_random_decimal_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.DecimalProperty > 0);
            Assert.True(createdObject.NullableDecimalProperty > 0);
        }

        [Fact]
        public void generate_random_double_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.DoubleProperty > 0);
            Assert.True(createdObject.NullableDoubleProperty > 0);
        }

        [Fact]
        public void generate_random_float_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.FloatProperty > 0);
            Assert.True(createdObject.NullableFloatProperty > 0);
        }

        [Fact]
        public void generate_random_short_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.ShortProperty > 0);
            Assert.True(createdObject.NullableShortProperty > 0);
        }

        [Fact]
        public void generate_random_byte_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.True(createdObject.ByteProperty > 0);
            Assert.True(createdObject.NullableByteProperty > 0);
        }

        [Fact]
        public void generate_random_datetime_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            DateTime minDateTime = DateTime.Now.AddMonths(-6);
            Assert.True(createdObject.DateTimeProperty >= minDateTime);
            Assert.True(createdObject.DateTimeProperty >= minDateTime);
        }

        [Fact]
        public void generate_random_boolean_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.NotNull(createdObject.NullableBooleanProperty);
        }

        [Fact]
        public void generate_random_enum_values()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var createdObject = factory.CreateOne();

            Assert.NotNull(createdObject.NullableEnumProperty);
        }
    }
}
