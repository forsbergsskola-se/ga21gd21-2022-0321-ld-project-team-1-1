using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun2 : MonoBehaviour
{
   private float Yrot;
   private RaycastHit hit;
   private GameObject grabbedOBJ;
   public Transform grabPos;

   private void Update()
   {
      /*Yrot -= Input.GetAxis("Mouse Y");
      Yrot = Mathf.Clamp(Yrot, -60, 60);
      transform.localRotation = Quaternion.Euler(Yrot, 0, 0);*/
      if (Input.GetMouseButtonDown(1) && Physics.Raycast(transform.position, transform.forward, out hit, 5) &&
          hit.transform.GetComponent<Rigidbody>())
      {
         grabbedOBJ = hit.transform.gameObject;
      }
      else if (Input.GetMouseButtonUp(1))
      {
         grabbedOBJ = null;
      }

      if (grabbedOBJ)
      {
         grabbedOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabbedOBJ.transform.position);
      }
   }
}