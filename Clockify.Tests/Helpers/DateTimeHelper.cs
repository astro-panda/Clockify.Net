using System;
using TimeZoneConverter;

namespace Clockify.Tests.Helpers {
	class DateTimeHelper {
		public static DateTime ConvertToTimeZone(string timeZone, DateTimeOffset now) {
			// First, obtain the OS version of time zone based on the Clockify users' settings.
			var tzi = TZConvert.GetTimeZoneInfo(timeZone);

			// Second, translate current time into the Clockify users' time zone.
			var nowTz = now.ToOffset(tzi.BaseUtcOffset).DateTime;

			// Third, just to be safe we need to translate again to make sure Daylight Savings time is accounted for.
			var nowTz2 = now.ToOffset(tzi.GetUtcOffset(nowTz)).DateTime;
			return nowTz2;
		}
	}
}