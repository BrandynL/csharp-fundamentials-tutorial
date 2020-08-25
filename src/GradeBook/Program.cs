using System;

namespace GradeBook
{
	class Program
	{
		static void Main(string[] args)
		{
			IBook book = new DiscBook("Brandyn's grade book");
			book.GradeAdded += OnGradeAdded;

			System.Console.WriteLine(book.Name);


			EnterGrades(book);

			Statistics stats = book.GetStatistics();

			System.Console.WriteLine($"Average: {stats.Average}");
			System.Console.WriteLine($"Low: {stats.Low}");
			System.Console.WriteLine($"High: {stats.High}");
			System.Console.WriteLine($"Letter: {stats.Letter}");
		}

		private static void EnterGrades(IBook book)
		{
			Console.WriteLine("Begin entering Grades or enter \"q\" to finish inputing Grades");
			var input = Console.ReadLine();
			while (input != "q")
			{
				try
				{
					double grade = double.Parse(input);
					book.AddGrade(grade);
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
				}
				finally
				{
					// close a network socket or something if needed at  this point
				}

				input = Console.ReadLine();
			}
		}

		static void OnGradeAdded(object sender, EventArgs e)
		{
			Console.WriteLine("event fired: a grade was added");
		}
	}
}
