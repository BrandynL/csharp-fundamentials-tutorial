using System;
using GradeBook;
using Xunit;

namespace GradeBook.Tests
{
	public delegate string WriteLogDelegate(string logMessage);

	public class TypeTests
	{
		int count = 0;
		[Fact]
		public void WriteLogMethodDelegateCanPointToMethod()
		{
			WriteLogDelegate log = ReturnMessage;
			log += ReturnMessage;
			log += IncrementCount;

			string result = log("hello");
			Assert.Equal(3, count);

		}

		string IncrementCount(string message)
		{
			count++;
			return message.ToLower();
		}
		string ReturnMessage(string message)
		{
			count++;
			return message;
		}
		[Fact]
		public void ValueTypesAlsoPassByValue()
		{
			int x = GetInt();
			SetInt(ref x);
			Assert.Equal(42, x);
		}

		private void SetInt(ref int x)
		{
			x = 42;
		}

		private int GetInt()
		{
			return 3;
		}

		[Fact]
		public void CSharpCanPassByRef()
		{
			InMemoryBook book1 = GetBook("book1");
			GetBookSetName(ref book1, "New Name");
			Assert.Equal("New Name", book1.Name);
		}
		private void GetBookSetName(ref InMemoryBook book, string name)
		{
			book = new InMemoryBook(name);
		}
		[Fact]
		public void CSharpIsPassByValue()
		{
			InMemoryBook book1 = GetBook("book1");
			GetBookSetName(book1, "New Name");
			Assert.Equal("book1", book1.Name);
		}
		private void GetBookSetName(InMemoryBook book, string name)
		{
			book = new InMemoryBook(name);
		}
		[Fact]
		public void CanSetNameByReference()
		{
			InMemoryBook book1 = GetBook("book1");
			SetName(book1, "New Name");
			Assert.Equal("New Name", book1.Name);
		}
		private void SetName(InMemoryBook book, string name)
		{
			book.Name = name;
		}

		[Fact]
		public void GetBookReturnsDifferentObjects()
		{
			InMemoryBook book1 = GetBook("book1");
			InMemoryBook book2 = GetBook("book2");

			Assert.NotSame(book1, book2);
		}
		[Fact]
		public void TwoVariablesCanReferenceSameObject()
		{
			InMemoryBook book1 = GetBook("book1");
			InMemoryBook book2 = book1;

			Assert.Same(book1, book2);
		}

		InMemoryBook GetBook(string name)
		{
			return new InMemoryBook(name);
		}
		[Fact]
		public void StringsBehaveLikeValueTypes()
		{
			String name = "Brandyn";
			string upper = MakeUpperCase(name);

			Assert.Equal("Brandyn", name);
			Assert.Equal("BRANDYN", upper);
		}

		private string MakeUpperCase(string s)
		{
			return s.ToUpper();
		}
	}
}
