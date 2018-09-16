using System;

namespace JPT
{
    public static class Extensions
    {
        public static Action<T> Subscribe<T>(this Action<T> thisAction, Action<T> action)
        {
            thisAction += action;
            return thisAction;
        }
    }
}