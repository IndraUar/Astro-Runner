using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To check if the audiomanager script is in the scene and not make it multiply

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Creates a static varible for a MusicControlScript instance

    private void Awake() // Runs before void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Don't destroy this gameObject when loading different scenes

        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }
}