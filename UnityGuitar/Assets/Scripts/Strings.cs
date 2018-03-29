using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    public string keyString;

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
}

