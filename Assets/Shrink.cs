using System;
using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    private bool isShrink = false;
    
    private bool canShrink = false;
    
    [SerializeField] private float shrinkHeight;
    [SerializeField] private float standingHeight = 1f;
    //[SerializeField] private CapsuleCollider collider;
    //[SerializeField] private Camera camera;
    //[SerializeField] private Vector3 StandardCameraPosition;
    //[SerializeField] private Vector3 ShrinkCameraPosition;
    [SerializeField] private Transform player;
    [SerializeField] private float slowDown;
    public static float speedMultiplier = 1;

    [SerializeField] private GameObject selectionManager;
    [SerializeField] private GameObject playerController;

    private float temporarySpeed;

    private void Start()
    {
        isShrink = false;
        //collider.height = standingHeight;
        //camera.transform.position = StandardCameraPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanShrink"))
        {
            canShrink = true;
        }
        /*if (other.CompareTag("Pipe"))
        {
            canShrink = false;
        }*/
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("CanShrink"))
        {
            canShrink = false;
            //isShrink = false;
        }
        /*else if (other.CompareTag("Pipe"))
        {
            canShrink = true;
        }*/
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isShrink)
        {
            isShrink = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !isShrink && canShrink)
        {
            isShrink = true;
        }

        if (isShrink)
        {
            //collider.height = shrinkHeight;
            //collider.center = ShrinkCameraPosition;
            player.localScale = new Vector3(shrinkHeight,shrinkHeight,shrinkHeight);
            speedMultiplier = slowDown;
            Camera.main.GetComponent<GravityGun2>().enabled = false;
            selectionManager.GetComponent<SelectionManager>().enabled = false;
            playerController.GetComponent<SUPERCharacterAIO>().canSprint = false;
            //camera.transform.position = ShrinkCameraPosition;
        }
        else
        {
            //collider.height = standingHeight;
            //collider.center = StandardCameraPosition;
            player.localScale = new Vector3(1f,1f,1f);
            speedMultiplier = 1f;
            Camera.main.GetComponent<GravityGun2>().enabled = true;
            selectionManager.GetComponent<SelectionManager>().enabled = true;
            playerController.GetComponent<SUPERCharacterAIO>().canSprint = true;
            //camera.transform.position = StandardCameraPosition;
        }
    }
}
