using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour {

    public Chord tempChord;
    private List<Chord> chords;
    private bool isRecording = false;
    public Guitar guitar; 

    // Use this for initialization
    void Start () {
		chords = new List<Chord>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addChord (GameObject[] _notes)
    {
        tempChord.notes = _notes;
        chords.Add(tempChord);
    }

    public List<Chord> getChords()
    {
        return chords;
    }

    public void clear()
    {
        chords.Clear();
    }

    public void setRecording (bool onRecord)
    {
        isRecording = onRecord;
    }

    public bool getIsRecording()
    {
        return isRecording;
    }
}
