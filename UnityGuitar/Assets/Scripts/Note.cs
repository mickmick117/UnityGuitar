using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public AudioClip note;
    public AudioSource source;

    SpriteRenderer spriteRenderer;

    //MusicController musicController;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
			
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown ()
    {
        if (!spriteRenderer.enabled)
        {
            Play();
        }
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    public void Play()
    {
        source.clip = note;
        source.Play();
    }
}
