using System;
using SUPERCharacter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private string interactiveTag = "Shop";
    private static bool GameIsPaused = false;
    
        [Header("References")]
    public GameObject player;
    public Camera camera;
    public GameObject selectionManager;
    public GameObject shopMenuUI;
    public GameObject instructions;

        [Header("UI")]
    [SerializeField] private TextMeshProUGUI textCurrencyUI;
    [SerializeField] private Button gravityGunButton;
    [SerializeField] private Button CrouchButton;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject gravityGunUnlocked;
    [SerializeField] private GameObject crouchUnlocked;
    
        [Header("Ray")]
    [SerializeField] private float maxDistance;

    private bool gravityGunAffordable;
    private bool crouchAffordable;

    private bool gravityGunPurchased = false;
    private bool crouchPurchased = false;

    [SerializeField] private int gravityGunCost = 1;
    [SerializeField] private int crouchCost = 2;

    void Update()
    {
        CostCheck();
        ResourcesCount();
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
        //camera.GetComponent<GravityGun2>().enabled = true;
        //selectionManager.SetActive(true);
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

        EnableButtons();
        
        player.GetComponent<SUPERCharacterAIO>().enabled = false;
        player.GetComponent<TapDestroy>().enabled = false;
        //camera.GetComponent<GravityGun2>().enabled = false;
        //selectionManager.SetActive(false);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnableGravityGun()
    {
        if (TapDestroy.count >= 1)
        {
            camera.GetComponent<GravityGun2>().enabled = true;
            selectionManager.SetActive(true);
            //gravityGunButton.enabled = false;
            gravityGunPurchased = true;
            gravityGunButton.image.enabled = false;
            //Destroy(info);
            gravityGunUnlocked.SetActive(true);
            TapDestroy.count -= gravityGunCost;
            CostCheck();
            EnableButtons();
        }
    }
    
    public void EnableCrouch()
    {
        player.GetComponent<SUPERCharacterAIO>().canCrouch = true;
        //CrouchButton.enabled = false;
        CrouchButton.image.enabled = false;
        crouchUnlocked.SetActive(true);
        crouchPurchased = true;
        TapDestroy.count -= crouchCost;
        CostCheck();
        EnableButtons();
    }

    void EnableButtons()
    {
        if (gravityGunAffordable && !gravityGunPurchased)
            gravityGunButton.enabled = true;
        else
            gravityGunButton.enabled = false;
        if (crouchAffordable && !crouchPurchased)
            CrouchButton.enabled = true;
        else
            CrouchButton.enabled = false;
    }

    public void ResourcesCount()
    {
        textCurrencyUI.text = TapDestroy.count.ToString();
    }

    public void CostCheck()
    {
        if (TapDestroy.count >= gravityGunCost)
            gravityGunAffordable = true;
        else
            gravityGunAffordable = false;
        if (TapDestroy.count >= crouchCost && gravityGunPurchased)
        {
            crouchAffordable = true;
        }
        else
        {
            crouchAffordable = false;
        }
        
        if (!gravityGunPurchased && TapDestroy.count >= crouchCost)
            info.SetActive(true);
        else
            info.SetActive(false);
    }
}
