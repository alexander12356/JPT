using System;
using UnityEngine;

using Newtonsoft.Json;

namespace JPT
{
    public static class Extensions
    {
        public static Action<T> Subscribe<T>(this Action<T> thisAction, Action<T> action)
        {
            thisAction += action;
            return thisAction;
        }

        public static void SafetyInvoke(this Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError($"{e.Message}\n{e.StackTrace}");
            }
        }

        public static T Deserialize<T>(this string serializedString)
        {
            return JsonConvert.DeserializeObject<T>(serializedString);
        }

        public static string Serialize(this object deserializedObject)
        {
            return JsonConvert.SerializeObject(deserializedObject, Formatting.Indented);
        }
    }
}