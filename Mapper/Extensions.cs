﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
	public static class Extensions
	{
		public static int GetMonthId(int year, int month)
		{
			string _month = month < 10 ? $"0{month}" : month.ToString();
			return int.Parse($"{year}{_month}");
		}

		public static int GetMonthId(this DateTime date) =>
			GetMonthId(date.Year, date.Month);
	}
}
