using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalTrigger : MonoBehaviour
{
    public SoundController Jtrigger;
    public int journalLvl;


    public void OnTriggerEnter(Collider other)
    {
        Jtrigger.journalNum = journalLvl;
        Debug.Log("journaTrigger");
        Jtrigger.Journal();
    }

}
