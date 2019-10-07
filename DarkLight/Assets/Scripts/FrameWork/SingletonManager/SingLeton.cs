using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SingLeton<T> where T : class, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}