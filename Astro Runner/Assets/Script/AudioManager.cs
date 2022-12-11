using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To check if the audiomanager script is in the scene and not make it multiply

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject); 

        if (instance == null) 
        {
            instance = this; 
        }
        else 
        {
            Destroy(gameObject); 
        }
    }
}