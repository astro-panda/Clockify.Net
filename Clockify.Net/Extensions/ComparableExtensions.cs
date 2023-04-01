using System;

namespace Clockify.Net.Extensions;

public static class ComparableExtensions
{
	public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T> {
		if (val.CompareTo(min) < 0) return min;
		if(val.CompareTo(max) > 0) return max;
		return val;
	}
}