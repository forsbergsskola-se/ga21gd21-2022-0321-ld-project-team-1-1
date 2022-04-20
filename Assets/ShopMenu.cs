using System;
using SUPERCharacter;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private string interactiveTag = "Shop";
    private static bool GameIsPaused = false;
    
    public GameObject player;
    public Camera camera;
    public GameObject selectionManager;
    public GameObject shopMenuUI;
    public GameObject instructions;

    [SerializeField] private Button gravityGunButton;
    [SerializeField] private Button CrouchButton;
    
    [SerializeField] private float maxDistance;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance) && !GameIsPaused)
        {
            var selection = hit.transform;
            if (selection.CompareTag(interactiveTag))
            {
                instructions.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                Pause();
            }
        }
        var _selection = hit.transform;
        if(_selection == null || !_selection.CompareTag(interactiveTag))
        {
            instructions.SetActive(false);
        }
        if (GameIsPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
 }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;
        player.GetComponent<TapDestroy>().enabled = true;
        camera.GetComponent<GravityGun2>().enabled = true;
        selectionManager.SetActive(true);
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        shopMenuUI.SetActive(true);
        instructions.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;
        player.GetComponent<TapDestroy>().enabled = false;
        camera.GetComponent<GravityGun2>().enabled = false;
        selectionManager.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnableGravityGun()
    {
        camera.GetComponent<GravityGun2>().enabled = true;
        selectionManager.SetActive(true);
        gravityGunButton.enabled = false;
    }
    
    public void EnableCrouch()
    {
        CrouchButton.enabled = false;
    }
}
