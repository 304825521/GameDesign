using System;
using UnityEngine;

namespace FS2.Utility
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static T Instantiate<T>(this T obj) where T: UnityEngine.Object
        {
            return UnityEngine.Object.Instantiate<T>(obj);
        }

		public static T AddComponentIfNotExist<T>(this GameObject go, bool isdelete = false) where T : Component
		{
			T t = go.GetComponent<T>();
			if (t == null)
			{
				t = go.AddComponent<T>();
			}
			else if (isdelete)
			{
				t.DestoryImmediate<T>();
				t = go.AddComponent<T>();
			}
			return t;
		}

		public static void DestoryImmediate<T>(this T obj) where T : UnityEngine.Object
		{
			UnityEngine.Object.DestroyImmediate(obj);
		}
	}
}
