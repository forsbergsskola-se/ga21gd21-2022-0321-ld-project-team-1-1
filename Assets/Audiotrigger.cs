using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audiotrigger : MonoBehaviour
{
    
    public SoundController trigger;
    public int funcNum = 0;
    

    public void OnTriggerEnter(Collider other)
    {
        trigger.NonLinearNum = funcNum;
            Debug.Log("playDialogue");
            trigger.NonLinearAudio();
            Debug.Log("destroyObject");
            Destroy(gameObject);
    }
    public void OnTriggerExit(Collider other)
    {
        trigger.NonLinearNum = funcNum;
        if (funcNum == 7)
        {
            trigger.NonLinearAudio();
            Destroy(gameObject);
        }
    }
}
