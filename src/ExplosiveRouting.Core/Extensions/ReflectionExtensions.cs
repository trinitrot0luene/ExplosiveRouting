using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("ExplosiveRouting.Benchmarks")]
[assembly: InternalsVisibleTo("ExplosiveRouting.Tests")]

namespace ExplosiveRouting.Core.Extensions
{
    // I swear, it's necessary.
    internal static class ReflectionExtensions
    {
        private static Type[] GetGenericArgumentsForMethod<TTarget, TReturn>(MethodInfo methodInfo)
        {
            var paramInfoArray = methodInfo.GetParameters();
            var typeArray = new Type[paramInfoArray.Length + 2];
            for (int i = 1; i <= paramInfoArray.Length; i++)
            {
                typeArray[i] = paramInfoArray[i - 1].ParameterType;
            }

            typeArray[0] = typeof(TTarget);
            typeArray[typeArray.Length - 1] = typeof(TReturn);

            return typeArray;
        }
        public static Func<TTarget, object, object> CreateGenericInvoker<TTarget, TParam, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker1),
                BindingFlags.Static | BindingFlags.NonPublic);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeof(TTarget), methodInfo.GetParameters()[0].ParameterType, methodInfo.ReturnType);

            return (Func<TTarget, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker2),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker3),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker4),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker5),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker6),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker7),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker8),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker9),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker10),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker11),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker12),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker13),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }

        public static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateGenericInvoker<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TReturn>(this MethodInfo methodInfo)
            where TTarget : class
        {
            var delegateInvoker = typeof(ReflectionExtensions).GetMethod(nameof(CreateDelegateInvoker14),
                BindingFlags.Static | BindingFlags.NonPublic);

            var typeArray = ReflectionExtensions.GetGenericArgumentsForMethod<TTarget, TReturn>(methodInfo);

            var constructedInvoker = delegateInvoker.MakeGenericMethod(typeArray);

            return (Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>)constructedInvoker.Invoke(null, new object[] { methodInfo });
        }
        
        private static Func<TTarget, object, object> CreateDelegateInvoker1<TTarget, TParam1, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            Func<TTarget, TParam1, TReturn> func = (Func<TTarget, TParam1, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TReturn>), methodInfo);

            return (TTarget target, object param1) => func(target, (TParam1)param1);
        }

        private static Func<TTarget, object, object, object> CreateDelegateInvoker2<TTarget, TParam1, TParam2, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2) => func(target, (TParam1)param1, (TParam2)param2);
        }

        private static Func<TTarget, object, object, object, object> CreateDelegateInvoker3<TTarget, TParam1, TParam2, TParam3, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3);
        }

        private static Func<TTarget, object, object, object, object, object> CreateDelegateInvoker4<TTarget, TParam1, TParam2, TParam3, TParam4, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4);
        }

        private static Func<TTarget, object, object, object, object, object, object> CreateDelegateInvoker5<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5);
        }

        private static Func<TTarget, object, object, object, object, object, object, object> CreateDelegateInvoker6<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object> CreateDelegateInvoker7<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker8<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker9<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker10<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9, (TParam10)param10);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker11<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9, (TParam10)param10, (TParam11)param11);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker12<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9, (TParam10)param10, (TParam11)param11, (TParam12)param12);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker13<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9, (TParam10)param10, (TParam11)param11, (TParam12)param12, (TParam13)param13);
        }

        private static Func<TTarget, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> CreateDelegateInvoker14<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TReturn>(MethodInfo methodInfo) where TTarget : class
        {
            var func = (Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TReturn>)Delegate.CreateDelegate(typeof(Func<TTarget, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TReturn>), methodInfo);

            return (TTarget target, object param1, object param2, object param3, object param4, object param5, object param6, object param7, object param8, object param9, object param10, object param11, object param12, object param13, object param14) => func(target, (TParam1)param1, (TParam2)param2, (TParam3)param3, (TParam4)param4, (TParam5)param5, (TParam6)param6, (TParam7)param7, (TParam8)param8, (TParam9)param9, (TParam10)param10, (TParam11)param11, (TParam12)param12, (TParam13)param13, (TParam14)param14);
        }
    }
}
