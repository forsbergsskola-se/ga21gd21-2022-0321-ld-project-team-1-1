using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalTrigger : MonoBehaviour
{
    public SoundController Jtrigger;


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("journaTrigger");
        Jtrigger.Journal();
        Debug.Log("DestroyObject");
        Destroy(gameObject);
    }

}
