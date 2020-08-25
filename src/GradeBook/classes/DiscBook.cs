using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
	public class DiscBook : Book, IBook
	{
		private List<double> Grades;
		public DiscBook(string name) : base(name)
		{
			Name = name;
			this.Grades = new List<double>();
		}

		public override event GradeWasAddedDelegate GradeAdded;

		public override void AddGrade(double grade)
		{
			if (grade <= 100 && grade >= 0)
			{

				using (StreamWriter writer = File.AppendText($"{this.Name}.txt"))
				{
					writer.WriteLine(grade);
					if (GradeAdded != null)
					{
						GradeAdded(this, new EventArgs());
					}
				}
			}
			else
			{
				throw new ArgumentException($"Invalid {nameof(grade)}");
			}
		}

		public override Statistics GetStatistics()
		{
			this.GetGrades();
			Statistics stats = new Statistics(this.Grades);
			return stats;
		}

		public void GetGrades()
		{
			if (File.Exists($"{Name}.txt"))
			{
				var bookContents = File.ReadAllLines($"{Name}.txt");
				foreach (var grade in bookContents)
				{
					Grades.Add(double.Parse(grade));
				}
			}
		}
	}
}