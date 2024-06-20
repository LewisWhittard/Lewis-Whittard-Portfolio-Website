﻿using Infrastructure.Models.Data.Table;

namespace UIFactoryTests.Concrete
{
    public class HeaderTests
    {
        private List<Header> _headers;

        //setup
        public void SetUp()
        {
            _headers = new List<Header>();
            _headers.Add(new Header(0,false,false,1,2,"HeaderValue","GUIDHeader0"));
            _headers.Add(new Header(1, false, false, 2, 3, "HeaderValue1", "GUIDHeader1"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Header_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var header = _headers.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var headerConcrete = new UIFactory.Factory.Concrete.Table.Header(header);
        
            //Assert
            Assert.NotNull(headerConcrete);
            Assert.Equal(header.Id, headerConcrete.HeaderData.Id);
            Assert.Equal(header.DisplayOrder, headerConcrete.DisplayOrder);
            Assert.Equal(header.UIConcreteType, headerConcrete.UIConcreteType);

            TearDown();
        }

        public void TearDown()
        {
            _headers = null;
        }
    }
}