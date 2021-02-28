using System;
using Xunit;

namespace GradeBook.tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref int z)
        {
            z=42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");
            //act
            GetBookSetNameByRef(ref book1,"New Name");
            //assert
            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetNameByRef(ref Book book, string newname)
        {
            book = new Book(newname);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");
            //act
            GetBookSetName(book1,"New Name");
            //assert
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(Book book, string newname)
        {
            book = new Book(newname);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            //act
            SetName(book1,"New Name");
            //assert
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(Book book1, string newname)
        {
            book1.Name = newname;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act

            //assert
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act
            book1 = book2;
            //assert
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
