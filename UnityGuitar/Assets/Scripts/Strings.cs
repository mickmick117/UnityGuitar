﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    public string keyString;
    private const int maxNotes = 4;
    private bool enable = true;

    public Recording record;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayString();
    }

    void PlayString()
    {
        if (Input.GetKeyDown(keyString))
        {
            PlayNote();
        }
    }

    public void PlayNote()
    {
        Transform note = transform.Find("f3");
        if (note.GetComponent<SpriteRenderer>().enabled)
        {
            note.GetComponent<Note>().Play();
        }
        else
        {
            note = transform.Find("f2");
            if (note.GetComponent<SpriteRenderer>().enabled)
            {
                note.GetComponent<Note>().Play();
            }
            else
            {
                note = transform.Find("f1");
                if (note.GetComponent<SpriteRenderer>().enabled)
                {
                    note.GetComponent<Note>().Play();
                }
                else
                {
                    note = transform.Find("f0");
                    if (note.GetComponent<SpriteRenderer>().enabled)
                    {
                        note.GetComponent<Note>().Play();
                    }
                }
            }
        }
    }

    public List<GameObject> GetNotes ()
    {
        List<GameObject> notes = new List<GameObject>();

        for (int i = 0; i < maxNotes; i++)
        {
            Transform note = transform.Find("f" + i);
            if (note.GetComponent<SpriteRenderer>().enabled)
            {
                notes.Add(note.gameObject);
            }
        }

        return notes;
    }

    public void enableString(bool _enable)
    {
        for (int i = 0; i < maxNotes; i++)
        {
            transform.Find("f" + i).GetComponent<Note>().enableNote(_enable);
        }
    }
}

