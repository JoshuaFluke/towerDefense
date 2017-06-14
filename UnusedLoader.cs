using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;

    private void Awake()
    {
        KeyValuePair<int, string> course = new KeyValuePair<int, string>(1, "Hello");
        course.Print();
    }
}




public class KeyValuePair<TKey, TValue>
{
    public TKey key;
    public TValue value;

    //initializes the class
    public KeyValuePair(TKey _key, TValue _value) {
        key = _key;
        value = _value;
    }

    public void Print()
    {
        Debug.Log("Key: " + key.ToString());
        Debug.Log("Key: " + value.ToString());
    }
}




