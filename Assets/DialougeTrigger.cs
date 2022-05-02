using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

    public SoundController DialougeIncrementer;

    private void OnTriggerEnter(Collider Other)
    {
        Debug.Log("DialougeCollision");
        DialougeIncrementer.DialougePlayer();
        Debug.Log("DestroyObject");
        Destroy(gameObject);
    }


}
