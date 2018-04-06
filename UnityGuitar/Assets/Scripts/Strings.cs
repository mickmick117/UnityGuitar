using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strings : MonoBehaviour
{
    public string keyString;
    private const int maxNotes = 4;
    public GameObject stringFeedBack;
    public GameObject KeyFeedBack;

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
           bool recordThisNote = PlayNote();

            if (record.getIsRecording() && recordThisNote)
            {
                List<Note> noteSeule = new List<Note>();
                noteSeule.Add(getState());
                record.addChord(noteSeule);
            }

            stringFeedBack.SetActive(true);
            KeyFeedBack.SetActive(true);
        }

        if (Input.GetKeyUp(keyString))
        {
            stringFeedBack.SetActive(false);
            KeyFeedBack.SetActive(false);
        }
    }

    public bool PlayNote() // return false if there is no finger on the string
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
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public List<Note> GetNotes ()
    {
        List<Note> notes = new List<Note>();

        for (int i = 0; i < maxNotes; i++)
        {
            Transform note = transform.Find("f" + i);
            if (note.GetComponent<SpriteRenderer>().enabled)
            {
                notes.Add(note.gameObject.GetComponent<Note>());
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

    public Note getState ()
    {
        Note notePlayed = new Note() ;
        for (int i = maxNotes-1; i >= 0; i--)
        {
            Transform note = transform.Find("f" + i);
            if (note.GetComponent<SpriteRenderer>().enabled)
            {
                notePlayed = note.GetComponent<Note>();
                break;
            }
        }
        return notePlayed;
    }
}

