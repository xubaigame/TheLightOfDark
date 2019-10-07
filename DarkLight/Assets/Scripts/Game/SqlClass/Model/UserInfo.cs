using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    private string userName;
    private string userPwd;

    public string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public string UserPwd
    {
        get
        {
            return userPwd;
        }

        set
        {
            userPwd = value;
        }
    }

}
