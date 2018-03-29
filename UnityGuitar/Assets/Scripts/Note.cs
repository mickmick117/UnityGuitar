using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public AudioClip note;
    public AudioSource source;

    //MusicController musicController;

    // Use this for initialization
    void Start()
    {
        
    }
			
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown ()
    {
        source.clip = note;
        source.Play();
    }
}
