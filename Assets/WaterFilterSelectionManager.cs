using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFilterSelectionManager : MonoBehaviour
{
    private string interactiveTag1 = "WaterFilter";
    private string interactiveTag2 = "Collectable";

    [Header("Materials")]
    [SerializeField] private Material highlightedMaterial;
    private Material defaultMaterial;

    private Transform _selection;
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(interactiveTag1) || selection.CompareTag(interactiveTag2) )
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightedMaterial;
                }

                _selection = selection;
            }
        }
    }
}
