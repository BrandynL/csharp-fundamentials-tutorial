namespace GradeBook
{

	public interface IBook
	{
		void AddGrade(double grade);
		Statistics GetStatistics();
		public string Name { get; }
		event GradeWasAddedDelegate GradeAdded;
	}
}