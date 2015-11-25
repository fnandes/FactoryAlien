using FactoryAlien.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FactoryAlien.Tests
{
    public class BuildableCollectionTests
    {
        [Fact]
        public void build_random_list_with_fluent_interface()
        {
            var factory = FactoryAlien.Define<DummyObject>();

            var buildableList = factory.CreateList(5, c => c.StringProperty = "BRAZIL");

            buildableList.Add(4)
                         .Add(3, c => c.StringProperty = "EUA")
                         .Add(2, c => c.StringProperty = "CANADA");

            Assert.Equal(14, buildableList.Count());
            Assert.Equal(5, buildableList.Count(c => c.StringProperty == "BRAZIL"));
            Assert.Equal(3, buildableList.Count(c => c.StringProperty == "EUA"));
            Assert.Equal(2, buildableList.Count(c => c.StringProperty == "CANADA"));
        }
    }
}
