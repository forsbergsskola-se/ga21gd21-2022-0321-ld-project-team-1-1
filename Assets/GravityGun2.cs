using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityGun2 : MonoBehaviour
{
   [SerializeField] private string interactiveTag = "Interactive";
   
   [SerializeField] private Material grabbedMaterial;
   [SerializeField] private Material defaultMaterial;

   [SerializeField] private GameObject SelectionManager;
   
   private float Yrot;
   private RaycastHit hit;
   private GameObject grabbedOBJ;
   public Transform grabPos;

    //AudioRef
    public SoundController Gravitygun2;

   private void Update()
   {
      /*Yrot -= Input.GetAxis("Mouse Y");
      Yrot = Mathf.Clamp(Yrot, -60, 60);
      transform.localRotation = Quaternion.Euler(Yrot, 0, 0);*/
      if (Input.GetMouseButtonDown(1) && Physics.Raycast(transform.position, transform.forward, out hit, 5) &&
          hit.transform.GetComponent<Rigidbody>() && hit.transform.CompareTag(interactiveTag))
      {
         SelectionManager.SetActive(false);
         //defaultMaterial = selectionRenderer.material; //save object original material
         grabbedOBJ = hit.transform.gameObject;
         var selectionRenderer = grabbedOBJ.GetComponent<Renderer>();
         selectionRenderer.material = grabbedMaterial; //change material when hold
            //Audio
            //Debug.Log("make noise");
            Gravitygun2.Gravitygun2Audio();
      }
      else if (Input.GetMouseButtonUp(1))
      {
         SelectionManager.SetActive(true);
         grabbedOBJ = null;
         Gravitygun2.Gravitygun2AudioStop();
         
      }
      if (grabbedOBJ)
      {
         grabbedOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabbedOBJ.transform.position);
      }
      
   }
}