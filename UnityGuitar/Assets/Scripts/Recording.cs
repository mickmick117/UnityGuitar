using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour {

   // public Chord tempChord;
    private List<List<Note>> chords;
    private List<float> silencesTime; 
    private bool isRecording = false;
    private bool playOnce = false;
    private float timeBetweenNote = 0;
    public Guitar guitar; 

    // Use this for initialization
    void Start () {
		chords = new List<List<Note>>();
        silencesTime = new List<float>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(playOnce && isRecording)
        {
            timeBetweenNote += Time.deltaTime;
        }
	}

    public void addChord (List<Note> _notes)
    {
        //tempChord.notes = _notes;
        //chords.Add(Instantiate(tempChord) as Chord);
        chords.Add(_notes);
        

        if (!playOnce)
        {
            playOnce = true;
        }
        else
        {
            silencesTime.Add(timeBetweenNote);
        }
        timeBetweenNote = 0;


    }

    public List<List<Note>> getChords()
    {
        return chords;
    }

    public List<float> getSilencesTime()
    {
        return silencesTime;
    }

    public void clear()
    {
        chords.Clear();
        silencesTime.Clear();
    }

    public void setRecording (bool onRecord)
    {
        isRecording = onRecord;

        if(!onRecord)
        {
            playOnce = false;
            timeBetweenNote = 0;
        }
    }

    public bool getIsRecording()
    {
        return isRecording;
    }
}
