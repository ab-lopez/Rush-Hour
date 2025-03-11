using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    	// public GameObject audioManager;
        private AudioSource song;
        // Song Cliff Jumper by AvapXia via Free Music Archive 
        // under Creative Commons license

    // Start is called before the first frame update
    void Start()
    {
        song = this.GetComponent<AudioSource>();
        song.Play();
    }

}
