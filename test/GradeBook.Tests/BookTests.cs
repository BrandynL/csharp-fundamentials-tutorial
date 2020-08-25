using System;
using Xunit;

namespace GradeBook.Tests
{
	public class BookTests
	{
		[Fact]
		public void PreventsAddingInvalidGrades()
		{
			InMemoryBook book = new InMemoryBook("");
			// Assert.Equal(book.AddGrade(99.1));
			// Assert.False(book.AddGrade(100.1));

		}
		[Fact]
		public void BookCalculatesStatistics()
		{
			// arrange
			InMemoryBook book = new InMemoryBook("");
			book.AddGrade(78.6);
			book.AddGrade(88.4);
			book.AddGrade(98.4);

			// act
			var result = book.GetStatistics();

			// assert
			Assert.Equal(88.5, result.Average, 1);
			Assert.Equal(78.6, result.Low, 1);
			Assert.Equal(98.4, result.High, 1);
			Assert.Equal('B', result.Letter);
		}
	}
}
