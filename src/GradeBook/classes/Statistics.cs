using System;
using System.Collections.Generic;

namespace GradeBook
{
	public class Statistics
	{
		public double Average
		{
			get;
		}
		public double High
		{
			get;
		}
		public double Low
		{
			get;
		}
		public char Letter
		{
			get;
		}
		List<double> Grades
		{
			get;
		}

		public Statistics(List<double> grades)
		{
			Grades = grades;
			Average = ComputeAverageGrade();
			High = GetHighestGrade();
			Low = GetLowestGrade();
			Letter = GetLetterGrade();
		}
		public double ComputeAverageGrade()
		{
			double result = 0.0;
			foreach (double number in Grades)
			{
				result += number;
			}
			return Math.Round(result /= Grades.Count, 2);

		}
		public double GetHighestGrade()
		{
			double value = double.MinValue;
			foreach (double grade in Grades)
			{
				value = Math.Max(value, grade);
			}
			return value;
		}
		public double GetLowestGrade()
		{
			double value = double.MaxValue;
			foreach (double grade in Grades)
			{
				value = Math.Min(value, grade);
			}
			return value;
		}
		public char GetLetterGrade()
		{
			switch (this.Average)
			{
				case var d when d >= 90:
					return 'A';
				case var d when d >= 80:
					return 'B';
				case var d when d >= 70:
					return 'C';
				case var d when d >= 60:
					return 'D';
				default:
					return 'F';
			}
		}
	}
}