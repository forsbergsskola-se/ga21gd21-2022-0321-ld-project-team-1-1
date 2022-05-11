using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audiotrigger : MonoBehaviour
{
    public int funcNum = 0;
    SoundController trigger;


    public void OnTriggerEnter(Collider other)
    {
        if (funcNum == 1)
        {
            trigger.DestroyWaterFilter1_Audio();
            Destroy(gameObject);
        }
        else if (funcNum == 2)
        {
            trigger.WaterFilter2_Audio();
            Destroy(gameObject);
        }
        else if (funcNum == 3)
        {
            trigger.DestroyWaterFilter2_Audio();
            Destroy(gameObject);
        }
        else if (funcNum == 4)
        {
            trigger.FindingresourcesAudio();
            Destroy(gameObject);
        }
    }
}
