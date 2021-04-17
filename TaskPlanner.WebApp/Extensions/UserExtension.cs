using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TaskPlanner.WebApp.Extensions
{
	public static class UserExtension
	{
		public static string GetClaimValue(this ClaimsPrincipal claim, string types) =>
			claim.Claims.Where(x => x.Type == types).FirstOrDefault()?.Value ?? string.Empty;

		public static int GetUserId(this ClaimsPrincipal user)
		{
			if (int.TryParse(user.GetClaimValue(ClaimTypes.NameIdentifier), out int i))
				return i;
			else
				return 0;
		}
	}
}
