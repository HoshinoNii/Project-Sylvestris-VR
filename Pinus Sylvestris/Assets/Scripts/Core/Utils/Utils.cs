using System;
using System.Collections;
using UnityEngine;

namespace Sylvestris.Core.Utils {
	public static class Utils {
		// Utilities Class
		public static IEnumerator Fade(float time, Material material, bool fadeOut) {
			// Fade to transparent
			while (fadeOut ? material.color.a > 0.0f : material.color.a < 1.0f) {
				material.color = new Color(material.color.r, material.color.g, material.color.b,
					material.color.a - Time.deltaTime / time);
				yield return null;
			}
		}
	}
	
	public static class EnumHelper
	{
		public static  T GetEnumValue<T>(string str) where T : struct, IConvertible
		{
			Type enumType = typeof(T);
			if (!enumType.IsEnum)
			{
				throw new Exception("T must be an Enumeration type.");
			}
			return Enum.TryParse(str, true, out T val) ? val : default;
		}

		public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
		{
			Type enumType = typeof(T);
			if (!enumType.IsEnum)
			{
				throw new Exception("T must be an Enumeration type.");
			}
        
			return (T)Enum.ToObject(enumType, intValue);
		}
	}
}