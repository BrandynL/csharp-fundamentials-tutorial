namespace GradeBook
{
	public class NamedObject : object
	{
		public NamedObject(string name)
		{
			Name = name;
		}

		public string Name
		{
			get;
			set;
		}
	}
}