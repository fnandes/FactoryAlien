using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAlienDotNet.Tests.Model
{
    public class DummyObject
    {
        public string StringProperty { get; set; }

        public int IntProperty { get; set; }

        public int? NullableIntProperty { get; set; }

        public decimal DecimalProperty { get; set; }

        public decimal? NullableDecimalProperty { get; set; }

        public double DoubleProperty { get; set; }

        public double? NullableDoubleProperty { get; set; }

        public float FloatProperty { get; set; }

        public float? NullableFloatProperty { get; set; }

        public short ShortProperty { get; set; }

        public short? NullableShortProperty { get; set; }

        public byte ByteProperty { get; set; }

        public byte? NullableByteProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public DateTime? NullableDateTimeProperty { get; set; }

        public bool BooleanProperty { get; set; }

        public bool? NullableBooleanProperty { get; set; }

        public Status EnumProperty { get; set; }

        public Status? NullableEnumProperty { get; set; }
    }

    public enum Status
    {
        Active,
        Disabled,
        Pending
    }
}
