using System.Linq;

namespace Mapper
{
	public static class Mapper
	{
		private static void Map<T, O>(T toItem, O onItem)
		{
			if (toItem != null && onItem != null)
			{
				foreach (var field in toItem.GetType().GetProperties().AsParallel())
				{
					try
					{
						if (field.CanWrite
							&& field.GetCustomAttributes(typeof(NotMappedAttribute), false).Length == 0)
						{
							var info = onItem.GetType().GetProperty(field.Name);
							if (info != null)
								field.SetValue(toItem, info.GetValue(onItem));
						}
					}
					catch
					{
						continue;
					}
				}
			}
		}

		public static T MapOn<T, O>(this T toItem, O onItem) where O : class
		{
			Map(toItem, onItem);
			return toItem;
		}

		public static T MapTo<T, O>(this O onItem, T toItem) where O : class
		{
			Map(toItem, onItem);
			return toItem;
		}
	}
}
