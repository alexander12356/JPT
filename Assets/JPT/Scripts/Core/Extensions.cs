using System;
using UnityEngine;

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
    }
}