using System;
using System.Collections.Generic;

namespace GradeBook
{
	public delegate void GradeWasAddedDelegate(object sender, EventArgs args);
	public abstract class Book : NamedObject, IBook
	{
		protected Book(string name) : base(name)
		{
			Name = name;
		}
		public abstract event GradeWasAddedDelegate GradeAdded;
		public abstract void AddGrade(double grade);
		public abstract Statistics GetStatistics();
	}

}