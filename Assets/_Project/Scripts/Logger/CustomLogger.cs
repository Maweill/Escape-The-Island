using System;

namespace _Project.Scripts.Logger
{
	public class CustomLogger : ICustomLogger
	{
		private readonly Type _sender;

		public CustomLogger(Type sender)
		{
			_sender = sender;
		}
		
		public void Debug(string message)
		{
			UnityEngine.Debug.Log($"|{_sender.Name}| {message}");
		}

		public void Warn(string message)
		{
			UnityEngine.Debug.LogWarning($"|{_sender.Name}| {message}");
		}

		public void Error(string message)
		{
			UnityEngine.Debug.LogError($"|{_sender.Name}| {message}");
		}
	}
}
