using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using UnityEngine;

using Firebase.Unity.Editor;

public class AccessDatabase : MonoBehaviour
{

    public string testing;
    // Start is called before the first frame update
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

// Handle initialization of the necessary firebase modules:
    public void InitializeFirebase() {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

// Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null) {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn) {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    private void Start()
    {

        
    }

    public void RunAthing()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://test-32217.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        string json = JsonUtility.ToJson(testing);

        reference.Child("users").Child(user.UserId).SetValueAsync(json);
    }
    
    
}
