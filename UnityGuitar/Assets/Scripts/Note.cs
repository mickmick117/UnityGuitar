using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour {

    public AudioClip note;
    public AudioSource source;
    private bool enable = true;
    public Recording record;

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
        if (enable)
        {
            if (!spriteRenderer.enabled)
            {
                Play();

                if (record.getIsRecording())
                {
                    List<Note> noteSeule = new List<Note>();
                    noteSeule.Add(transform.GetComponent<Note>());
                    record.addChord(noteSeule);
                }
            }
            spriteRenderer.enabled = !spriteRenderer.enabled;

            selectNewChord();
        }
    }

    public void Play()
    {
        if (enable)
        {
            source.clip = note;
            source.Play();
        }
    }

    public void selectNewChord ()
    {
        //desactive toute les panel au dessus des boutons selectionné
        Chord[] chordsButtons = FindObjectsOfType<Chord>();
        for (int i = 0; i < chordsButtons.Length; i++)
        {
            Transform text = chordsButtons[i].transform.Find("Text");
            Transform panel = chordsButtons[i].transform.Find("Panel");
            bool active = false;

            if (text.GetComponent<Text>().text == "Save" + "\n" +  "Chord") 
            {
                active = true; // on met la selection sur le bouton savechord
            }

            if (panel != null)
            {
                GameObject objectPanel = panel.gameObject;
                objectPanel.SetActive(active);
            }




        }
    }

    public void enableNote (bool _enable)
    {
        enable = _enable;
    }

}
