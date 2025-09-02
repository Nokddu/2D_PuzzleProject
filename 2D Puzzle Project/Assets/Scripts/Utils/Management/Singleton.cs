﻿using System;

namespace Utils.Management
{
    public class Singleton<T> where T : class
    {
        private static T _instance;
        
        protected static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateInstance();
                }

                return _instance;
            }
        }

        private static void CreateInstance()
        {
            var type = typeof(T);
            var constructorInfos = type.GetConstructors();
            if (constructorInfos.Length > 0)
            {
                throw new InvalidOperationException($"{type.Name} has at least one accessible constructor making it impossible to enforce singleton behaviour");
            }

            _instance = (T)Activator.CreateInstance(type, true);
        }
    }
}
