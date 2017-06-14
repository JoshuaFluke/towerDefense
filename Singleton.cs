using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created generic singleton because we will need one for towers as well as to start the game
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;

    public static T Instance
    {
        //creating the getter to get all the details of game manager
        get
        {
            if (instance == null)
            {
                //find a type of game manager
                instance = FindObjectOfType<T>();
            }
            else if (instance != FindObjectOfType<T>())
            {
                Destroy(FindObjectOfType<T>());
            }
            else
            {
                DontDestroyOnLoad(FindObjectOfType<T>());
            }
            return instance;
        }
    }
}
