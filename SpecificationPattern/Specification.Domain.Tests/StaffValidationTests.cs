using Xunit;
using System;
using Specification.Domain.Entities;

namespace Specification.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Staff_Shall_be_valid()
        {
            Staff staff =  new Staff("omid", "0629435656");
        }

        [Fact]
        public void Staff_Shall_throw_exception_for_invalid_phone()
        {
            Assert.Throws<Exception>(() => new Staff("omid", "") );
        }
        
        [Fact]
        public void Staff_Shall_throw_exception_all_invalid_data()
        {
            Assert.Throws<Exception>(() => new Staff("", "") );
        }
    }
}
