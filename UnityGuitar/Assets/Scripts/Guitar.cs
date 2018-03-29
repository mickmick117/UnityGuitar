using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{

    Transform s6;
    Transform s5;
    Transform s4;
    Transform s3;
    Transform s2;
    Transform s1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayStrings();
        }
    }

    public void PlayStrings()
    {
        Transform s6 = transform.Find("s6");
        Transform s5 = transform.Find("s5");
        Transform s4 = transform.Find("s4");
        Transform s3 = transform.Find("s3");
        Transform s2 = transform.Find("s2");
        Transform s1 = transform.Find("s1");

        s6.GetComponent<Strings>().PlayNote();
        s5.GetComponent<Strings>().PlayNote();
        s4.GetComponent<Strings>().PlayNote();
        s3.GetComponent<Strings>().PlayNote();
        s2.GetComponent<Strings>().PlayNote();
        s1.GetComponent<Strings>().PlayNote();
    }

    public void ClearGuitar()
    {
        for (int i = 1; i <= 6; i++)
        {
            ClearStrings(transform.Find("s" + i));
        }
    }

    void ClearStrings (Transform s)
    {
        Transform f0 = s.transform.Find("f0");
        f0.GetComponent<SpriteRenderer>().enabled = false;

        Transform f1 = s.transform.Find("f1");
        f1.GetComponent<SpriteRenderer>().enabled = false;

        Transform f2 = s.transform.Find("f2");
        f2.GetComponent<SpriteRenderer>().enabled = false;

        Transform f3 = s.transform.Find("f3");
        f3.GetComponent<SpriteRenderer>().enabled = false;
    }
}
