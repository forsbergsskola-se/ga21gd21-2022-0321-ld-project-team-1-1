using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProgressController : MonoBehaviour
{
    public MusicController mc;
    public int musicLevel;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }

        Debug.Log("music" + musicLevel);
        mc.changeMusicProgress(musicLevel);
    }

    

}
