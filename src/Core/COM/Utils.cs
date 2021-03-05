﻿using System;

namespace Core.COM
{
    public static class Utils
    {
        
        public static T FromShell<T>(Guid service)
        {
            var shell = CreateInstance<IServiceProvider>(CLSID.ImmersiveShell);
            if (shell != null)
            {
                shell.QueryService(service, typeof(T).GUID, out object instance);
                return (T) instance;
            }
            else
            {
                throw new InvalidOperationException($"Could not create shell.");
            }

        }
        public static T FromShell<T>()
        {
            return FromShell<T>(typeof(T).GUID);
        }
        
        public static T CreateInstance<T>(Guid guid)
        {
            var vdmType = Type.GetTypeFromCLSID(guid);
            var instance = Activator.CreateInstance(vdmType ?? throw new InvalidOperationException(
                $"Could not get type of {guid}"));
            return (T) instance;
        }
        
        public static T Get<T>(this IObjectArray arr, int i)
        {
            arr.GetAt(
                (uint) i,
                typeof(IVirtualDesktop).GUID,
                out var desktop);
            return (T) desktop;
        }

    }
}