using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    //public AudioClip[] sixthString;
    //public AudioClip[] fifthString;
    //public AudioClip[] fourthString;
    //public AudioClip[] thirdString;
    //public AudioClip[] secondString;
    //public AudioClip[] firstString;

    public AudioSource source;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayNote(AudioClip note)
    {
        source.clip = note;
        source.Play();
        //switch (String)
        //{
        //    case (1):
        //        source.clip = firstString[fret];
        //        break;
        //    case (2):
        //        source.clip = secondString[fret];
        //        break;
        //    case (3):
        //        source.clip = thirdString[fret];
        //        break;
        //    case (4):
        //        source.clip = fourthString[fret];
        //        break;
        //    case (5):
        //        source.clip = fifthString[fret];
        //        break;
        //    case (6):
        //        source.clip = sixthString[fret];
        //        break;
        //    default:
        //        break;
        //}
    }
}
        

