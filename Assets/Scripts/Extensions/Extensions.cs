using System;
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
    }
}
