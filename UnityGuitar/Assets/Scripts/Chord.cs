using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord : MonoBehaviour
{
    public GameObject[] notes;

    public Guitar guitar;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        guitar.ClearGuitar();
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].GetComponent<SpriteRenderer>().enabled = !notes[i].GetComponent<SpriteRenderer>().enabled;
        }
        guitar.PlayStrings();
    }
}
