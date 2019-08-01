using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class User
{
    public string username;
    public string email;

    public User() {
    }

    public User(string username, string email) {
        this.username = username;
        this.email = email;
    }
    
}
