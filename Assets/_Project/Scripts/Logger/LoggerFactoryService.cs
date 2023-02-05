namespace _Project.Scripts.Logger
{
	public static class LoggerFactory
	{
		private const LoggerType LOGGER_TYPE = LoggerType.Custom;
		
		public static ICustomLogger GetLogger<T>()
		{
			switch (LOGGER_TYPE) {
				case LoggerType.Custom:
					return new CustomLogger(typeof(T));
			}
		}
		
		private enum LoggerType
		{
			Custom
		}
	}
}
