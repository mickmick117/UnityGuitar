using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Globalization;
using UnityEngine.UI;

public class Songs : MonoBehaviour {

    private List<List<Note>> chords;
    private List<float> silences;
    public Recording recording;
    public GameObject nextSongButton;
    public Guitar guitar;
    public Text recordingText;
    public bool isActive = false;

    private const float tempTime = 1;
    private float timeLeft = tempTime;
    private bool waitForNextChord = false;
    private bool isPlaying = false;
    private int currentChord = 0;

    //  public Guitar guitar;

    // Use this for initialization
    void Start () {

        chords = new List<List<Note>>();
        silences = new List<float>();
            if (!isActive)
            {
                transform.gameObject.SetActive(false);
            }
        }
	
	// Update is called once per frame
	void Update () {

        if(isPlaying && !waitForNextChord)
        {
            SelectChord(currentChord);

            if(currentChord+1 < chords.Count)
            {
                currentChord++;
                waitForNextChord = true;
            }
            else
            {
                stopPlayingSong();                
            }
        }

        if(isPlaying && waitForNextChord)
        {
            timeLeft -= Time.deltaTime;
        }
        
        if (timeLeft < 0)
        {
            if(currentChord < silences.Count)
            {
                timeLeft = silences[currentChord];
            }
            else
            {
                timeLeft = tempTime;
            }
            
            waitForNextChord = false;
        }
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
        Color cb = GetComponent<Image>().color;
        cb = new Color(0.9f,0.55f,0.55f); // rouge pale
        GetComponent<Image>().color = cb;

        //Change le texte du bouton
        transform.Find("Text").GetComponent<Text>().text = "Stop";

        //afficher le recording text
        recordingText.enabled = true;
    }

    public void stopRecordingSong ()
    {
        //arret de l'enregistrement et sauvegarde de la chanson
        recording.setRecording(false);
        chords.AddRange(recording.getChords());
        silences.AddRange(recording.getSilencesTime());
        recording.clear();

        // affiche le text input et met le focus dessus
        Transform t = transform.Find("InputField");
        t.gameObject.SetActive(true);
        t.GetComponent<InputField>().Select();

        // desactive les corde de la guitar
        guitar.enableStrings(false);

        //desactive tous les boutons
        Chord[] chordsButtons = FindObjectsOfType<Chord>();
        for (int i = 0; i < chordsButtons.Length; i++)
        {
            chordsButtons[i].GetComponent<Button>().interactable = false;
        }
        Songs[] songsButtons = FindObjectsOfType<Songs>();
        for (int i = 0; i < songsButtons.Length; i++)
        {
            songsButtons[i].GetComponent<Button>().interactable = false;
        }

        //cacher le recording text
        recordingText.enabled = false;
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

            //change la couleur du bouton courant
            Color cb = GetComponent<Image>().color;
            cb = Color.white; // blanc
            GetComponent<Image>().color = cb;

            //desactive l'input
            transform.Find("InputField").gameObject.SetActive(false);

            //Active le prochain bouton
            if (nextSongButton != null)
                nextSongButton.SetActive(true);

            //desactive tous les boutons
            Chord[] chordsButtons = FindObjectsOfType<Chord>();
            for (int i = 0; i < chordsButtons.Length; i++)
            {
                chordsButtons[i].GetComponent<Button>().interactable = true;
            }
            Songs[] songsButtons = FindObjectsOfType<Songs>();
            for (int i = 0; i < songsButtons.Length; i++)
            {
                songsButtons[i].GetComponent<Button>().interactable = true;
            }

            //active les cordes
            guitar.enableStrings(true);
        }
    }

    public void playSong ()
    {
        isPlaying = true;
        if(silences != null && silences.Count > 0)
        {
            timeLeft = silences[currentChord];
        }

        //desactive toute les panel au dessus des chord selectionné et desactive les boutons
        Chord[] chordsButtons = FindObjectsOfType<Chord>();
        for (int i = 0; i < chordsButtons.Length; i++)
        {
            Transform panel = chordsButtons[i].transform.Find("Panel");
            if (panel != null)
            {
                //desactive les panels
                GameObject objectPanel = panel.gameObject;
                objectPanel.SetActive(false);
            }
            //desactive les boutons pendant que la chanson joue
            chordsButtons[i].GetComponent<Button>().interactable = false;

        }
        Songs[] songsButtons = FindObjectsOfType<Songs>();
        for (int i = 0; i < songsButtons.Length; i++)
        {
            songsButtons[i].GetComponent<Button>().interactable = false;
        }

        //change la couleur du bouton courant
        Color cb = GetComponent<Image>().color;
        cb = new Color(0.0f, 1.0f, 0.0f); // vert 
        GetComponent<Image>().color = cb;
    }

    private void stopPlayingSong()
    {
        currentChord = 0;
        isPlaying = false;
        //active tous les boutons
        Chord[] chordsButtons = FindObjectsOfType<Chord>();
        for (int i = 0; i < chordsButtons.Length; i++)
        {
                chordsButtons[i].GetComponent<Button>().interactable = true;
        }
        Songs[] songsButtons = FindObjectsOfType<Songs>();
        for (int i = 0; i < songsButtons.Length; i++)
        {
            songsButtons[i].GetComponent<Button>().interactable = true;
        }

        //change la couleur du bouton courant
        Color cb = GetComponent<Image>().color;
        cb = Color.white; // vert pale
        GetComponent<Image>().color = cb;
    }

    public void SelectChord(int index)
    {
        guitar.ClearGuitar();
        for (int i = 0; i < chords[index].Count; i++)
        {
            chords[index][i].GetComponent<SpriteRenderer>().enabled = !chords[index][i].GetComponent<SpriteRenderer>().enabled;
        }
        guitar.PlayStrings();
    }
}
