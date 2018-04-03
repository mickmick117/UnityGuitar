using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class Favorites : MonoBehaviour {

    public GameObject nextFav;
    public Guitar Guitar;
    public bool isActive = false;
    private bool isSet = false;

	// Use this for initialization
	void Start () {
	    if(!isActive)
        {
            transform.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unlockNextButton ()
    {
        if (!isSet)
        {
            //change la couleur du bouton courant
            ColorBlock cb = GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            GetComponent<Button>().colors = cb;

            // affiche le text input et met le focus dessus
            Transform t = transform.Find("InputField");
            t.gameObject.SetActive(true);
            t.GetComponent<InputField>().Select();

            //desactiver les cordes
            Guitar.enableStrings(false);

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

            isSet = true;
        }

    }

    public void setButtonText () // triggered lorsque le nom de l'accord est entré
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
            if (nextFav != null)
                nextFav.SetActive(true);

            //active les cordes
            Guitar.enableStrings(true);

            //activer tous les boutons 
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
        }
    }
}
