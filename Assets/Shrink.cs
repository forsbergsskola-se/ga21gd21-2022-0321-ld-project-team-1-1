using System;
using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    private bool isShrink = false;
    [SerializeField] private float shrinkHeight = 0.1f;
    [SerializeField] private float standingHeight = 1f;
    //[SerializeField] private CapsuleCollider collider;
    //[SerializeField] private Camera camera;
    //[SerializeField] private Vector3 StandardCameraPosition;
    //[SerializeField] private Vector3 ShrinkCameraPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float slowDown;
    public static float speedMultiplier = 1;

    private float temporarySpeed;

    private void Start()
    {
        isShrink = false;
        //collider.height = standingHeight;
        //camera.transform.position = StandardCameraPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isShrink)
        {
            isShrink = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !isShrink)
        {
            isShrink = true;
        }

        if (isShrink)
        {
            //collider.height = shrinkHeight;
            //collider.center = ShrinkCameraPosition;
            player.localScale = new Vector3(0.1f,0.1f,0.1f);
            speedMultiplier = slowDown;
            //camera.transform.position = ShrinkCameraPosition;
        }
        else
        {
            //collider.height = standingHeight;
            //collider.center = StandardCameraPosition;
            player.localScale = new Vector3(1f,1f,1f);
            speedMultiplier = 1f;
            //camera.transform.position = StandardCameraPosition;
        }
    }
}
