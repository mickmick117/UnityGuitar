using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class Songs : MonoBehaviour {

    private List<Chord> chords;
    public Recording recording;
    public GameObject nextSongButton;
    public Guitar guitar;
    public bool isActive = false;
    //  public Guitar guitar;

    // Use this for initialization
    void Start () {

        chords = new List<Chord>();
            if (!isActive)
            {
                transform.gameObject.SetActive(false);
            }
        }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick ()
    {
        if ((chords == null || chords.Count == 0) && !recording.getIsRecording()) //si la chanson n'a pas été créé encore et qu'on enregistre pas
        {
            recordSong();
        }
        else if ((chords == null || chords.Count == 0) && recording.getIsRecording()) // si la chanson n'a pas été créé encore et qu'on est en enregistrement
        {
            stopRecordingSong();
        }
        else // la chanson est enregistrer
        {
            playSong();
        }
    }

    public void recordSong ()
    {
        //enregistrement
        recording.setRecording(true);

        //change la couleur du bouton courant
        ColorBlock cb = GetComponent<Button>().colors;
        cb.normalColor = Color.white;
        GetComponent<Button>().colors = cb;

        //Change le texte du bouton
        transform.Find("Text").GetComponent<Text>().text = "Stop Recording";
    }

    public void stopRecordingSong ()
    {
        //arret de l'enregistrement et sauvegarde de la chanson
        recording.setRecording(false);
        chords.AddRange(recording.getChords());
        recording.clear();

        // affiche le text input et met le focus dessus
        Transform t = transform.Find("InputField");
        t.gameObject.SetActive(true);
        t.GetComponent<InputField>().Select();

        // desactive les corde de la guitar
        guitar.enableStrings(false);
    }

    public void setButtonText() // triggered lorsque le nom de l'accord est entré
    {
        //aller chercher le texte dans l'input
        string name = transform.Find("InputField").Find("Text").GetComponent<Text>().text;

        if (name != "")
        {
            //set le texte au bouton
            Transform t = transform.Find("Text");
            t.GetComponent<Text>().text = name;

            //desactive l'input
            transform.Find("InputField").gameObject.SetActive(false);

            //Active le prochain bouton
            if (nextSongButton != null)
                nextSongButton.SetActive(true);

            //active les cordes
            guitar.enableStrings(true);
        }
    }

    public void playSong ()
    {
        for (int i = 0; i < chords.Count; i++)
        {
            chords[i].SelectChord();
            Thread.Sleep(1000);
        }
    }
}
