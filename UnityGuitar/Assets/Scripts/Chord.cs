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

   /* void OnMouseDown()
    {
        if (notes == null || notes.Length == 0) // si l'accord ne contient aucune note, Quand on click dessus ça sauvegarde l'état de la guitar dans l'accord.
        {
            CreateChord();
        }
        else
        {
            SelectChord();
        }
    }*/

    public void onClick()
    {
        if (notes == null || notes.Length == 0) // si l'accord ne contient aucune note, Quand on click dessus ça sauvegarde l'état de la guitar dans l'accord.
        {
            CreateChord();
        }
        else
        {
            SelectChord();
        }
    }

    public void SelectChord()
    {
        guitar.ClearGuitar();
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].GetComponent<SpriteRenderer>().enabled = !notes[i].GetComponent<SpriteRenderer>().enabled;
        }
        guitar.PlayStrings();
    }

    private void CreateChord()
    {
        notes = guitar.getState();
    }
}
