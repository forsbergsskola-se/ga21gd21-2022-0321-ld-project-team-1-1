using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipInteraction : MonoBehaviour
{
    [SerializeField] private string interactiveTag = "Ship";
    
        [Header("References")]
    //public Camera camera;
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
                        SceneManager.LoadScene(sceneBuildIndex: 2);
                }
            }

            var _selection = hit.transform;
                if (_selection == null)
                {
                    instructions.SetActive(false);
                }
                if (!_selection.CompareTag(interactiveTag))
                {
                    instructions.SetActive(false);
                }
        }
}

 