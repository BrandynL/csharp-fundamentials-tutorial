using System;

namespace GradeBook
{
	class Program
	{
		static void Main(string[] args)
		{
			IBook book;
			System.Console.WriteLine("Enter a gradebook label, such \"[your_name]'s book\" or an example class like \"science\" or \"math\" ( this won't catch exceptions :) )");
			string bookLabel = Console.ReadLine();

			Console.WriteLine("Enter one of the following\n1: Save grades to file in src directory\n2: Save grades to memory only");
			string inputBookType = Console.ReadLine();
			switch (int.Parse(inputBookType))
			{
				case int d when d == 1:
					book = new DiscBook($"{bookLabel} grade book");
					break;
				default:
					book = new InMemoryBook($"{bookLabel} grade book");
					break;
			}
			book.GradeAdded += OnGradeAdded;

			System.Console.WriteLine(book.Name);


			EnterGrades(book);

			Statistics stats = book.GetStatistics();
			System.Console.WriteLine($"** {book.Name} Gradebook Statistics **");
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
