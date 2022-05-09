using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProgressController : MonoBehaviour
{
    public MusicController mc;
    public int musicLevel = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }


        mc.changeMusicProgress(musicLevel);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "player")
        {

        }

        mc.changeMusicProgressBack(musicLevel);
    }

}
