using System.Runtime.Serialization;

namespace elempleo.Authentication.Middlewares
{
	public class ErrorException : Exception
	{
		public List<string> Errores { get; set; } = new List<string>();


		public ErrorException()
		{
		}

		public ErrorException(string message)
			: base(message)
		{
			Errores.Add(message);
		}

		public ErrorException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected ErrorException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
