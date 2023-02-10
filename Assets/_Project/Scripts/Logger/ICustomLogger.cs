namespace _Project.Scripts.Logger
{
	public interface ICustomLogger
	{
		void Debug(string message);
		void Warn(string message);
		void Error(string message);
	}
}
