using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPlanner.DTO.Infrastructure
{
	public class DTOException : Exception { }


	public class NotFoundItemException : DTOException { }
	public class UserException : DTOException { }

	public class UserExistsException : UserException { }
	public class WrongPasswordException : UserException { }

}
