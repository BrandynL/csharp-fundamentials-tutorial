using System;
using System.Collections.Generic;

namespace GradeBook
{
	public class InMemoryBook : Book
	{
		private List<double> Grades;
		public const string CATEGORY = "Science";
		public InMemoryBook(string name, String Category = "") : base(name)
		{
			Name = name;
			this.Grades = new List<double>();
		}

		public void AddGrade(char letter)
		{
			switch (letter)
			{
				case 'A':
					AddGrade(90);
					break;
				case 'B':
					AddGrade(80);
					break;
				case 'C':
					AddGrade(70);
					break;
				case 'D':
					AddGrade(60);
					break;
				default:
					AddGrade(0);
					break;
			}
		}
		public override void AddGrade(double grade)
		{
			if (grade <= 100 && grade >= 0)
			{
				Grades.Add(grade);
				if (GradeAdded != null)
				{
					GradeAdded(this, new EventArgs());
				}
			}
			else
			{
				throw new ArgumentException($"Invalid {nameof(grade)}");
			}
		}

		public override event GradeWasAddedDelegate GradeAdded;
		public override Statistics GetStatistics()
		{
			Statistics result = new Statistics(this.Grades);
			return result;
		}
	}
}