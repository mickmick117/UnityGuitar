﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public AudioClip note;
    public AudioSource source;
    private bool enable = true;

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
        if (enable)
        {
            source.clip = note;
            source.Play();
        }
    }

    public void enableNote (bool _enable)
    {
        enable = _enable;
    }
}
