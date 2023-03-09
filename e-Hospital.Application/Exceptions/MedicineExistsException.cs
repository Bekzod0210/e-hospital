using System;
namespace e_Hospital.Application.Exceptions
{
	public class MedicineExistsException : Exception
	{
		private const string _message = "Medicine Exists!";

		public MedicineExistsException()
			: base(_message) { }
	}
}

