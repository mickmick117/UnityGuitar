using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord : MonoBehaviour
{
    public List<Note> notes;

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

        //desactive toute les panel au dessus des boutons selectionné
        Chord[] chordsButtons = FindObjectsOfType<Chord>();
        for (int i = 0; i < chordsButtons.Length; i++)
        {
            Transform panel = chordsButtons[i].transform.Find("Panel");
            if (panel != null)
            {
                GameObject objectPanel = panel.gameObject;
                objectPanel.SetActive(false);
            }

        }

        if (notes == null || notes.Count == 0) // si l'accord ne contient aucune note, Quand on click dessus ça sauvegarde l'état de la guitar dans l'accord.
        {
            CreateChord();
        }
        else
        {           
            //active le panel au dessus du bouton courant
            transform.Find("Panel").gameObject.SetActive(true);
            SelectChord();
        }
    }

    public void SelectChord()
    {
        guitar.ClearGuitar();
        for (int i = 0; i < notes.Count; i++)
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
