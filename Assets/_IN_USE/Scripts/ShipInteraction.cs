using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipInteraction : MonoBehaviour
{
 private string interactiveTag = "Ship";
    
        [Header("References")]
    public Camera camera;
    public GameObject instructions;
    
        [Header("Ray")]
    [SerializeField] private float maxDistance;

        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
            {
                var selection = hit.transform;
                if (selection.CompareTag(interactiveTag))
                {
                    instructions.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene(sceneBuildIndex: 2);
                    }
                }
            }
        }
}

 