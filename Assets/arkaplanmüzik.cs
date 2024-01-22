using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaplanmüzik : MonoBehaviour
{
    static arkaplanmüzik instance;
    void Start()
    {
        if(!instance)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    
}
