using System;
using SUPERCharacter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private string interactiveTag = "Shop";
    private static bool GameIsPaused = false;
    public static bool shopIsOpen = false;

    
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

    [SerializeField] private GameObject gravityGunNotAffordable;
    [SerializeField] private GameObject crouchNotAffordable;
    
        [Header("Ray")]
    [SerializeField] private float maxDistance;

    private bool gravityGunAffordable;
    private bool crouchAffordable;

    public static bool gravityGunPurchased = false;
    private bool crouchPurchased = false;

    [SerializeField] private int gravityGunCost = 1;
    [SerializeField] private int crouchCost = 2;

         [Header("Audio")]
    //public SoundController playAudio;
    public FMODUnity.EventReference enterShopRef;
    private FMOD.Studio.EventInstance enterShopInst;
    public SoundController sc;
    public FMODUnity.EventReference attractioinGloveRef;
    private FMOD.Studio.EventInstance attractionGloveInst;

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
                if (Input.GetKeyDown(KeyCode.E))

                Pause();

            }
        }
        var _selection = hit.transform;
        if(_selection == null || !_selection.CompareTag(interactiveTag))
        {
            instructions.SetActive(false);
        }
        if (GameIsPaused && Input.GetKeyUp(KeyCode.Escape))
        {
            Resume();
            shopIsOpen = false; //the shop is closed
        }
 }

    public void Resume()
    {
        Debug.Log(shopIsOpen);
        
        Cursor.visible = false; //Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
        
        player.GetComponent<SUPERCharacterAIO>().enabled = true; //Character Controller Enabled
        
        player.GetComponent<TapDestroy>().enabled = true; //Laser Enabled
        
            //camera.GetComponent<GravityGun2>().enabled = true;
            //selectionManager.SetActive(true);
        
        shopMenuUI.SetActive(false); //Deactivate Shop UI
        
        Time.timeScale = 1f; //Resume the Game
        GameIsPaused = false;
    }
    public void Pause()
    {
        shopIsOpen = true; //the shop is open
        Debug.Log(shopIsOpen);
        
        shopMenuUI.SetActive(true); //Activate Shop UI
        
        instructions.SetActive(false); //Disable instructions on screen
        
        Time.timeScale = 0f; //Pause the Game
        GameIsPaused = true;

        EnableButtons();
        
        player.GetComponent<SUPERCharacterAIO>().enabled = false; //Character Controller Disabled
        
        player.GetComponent<TapDestroy>().enabled = false; //Laser Disabled
        
            //camera.GetComponent<GravityGun2>().enabled = false;
            //selectionManager.SetActive(false);
        
        Cursor.visible = true; //Enable Cursor
        Cursor.lockState = CursorLockMode.None;
        
        //Audio
        Debug.Log("EnterShopAudio");
        //playAudio.enterShopAudio();
        enterShopInst = FMODUnity.RuntimeManager.CreateInstance(enterShopRef);
        enterShopInst.start();
        enterShopInst.release();
        sc.ShopDialogue();
    }

    public void EnableGravityGun()
    {
        if (TapDestroy.count >= 1)
        {
            attractionGloveInst = FMODUnity.RuntimeManager.CreateInstance(attractioinGloveRef);
            attractionGloveInst.start();
            Debug.Log("AttractionAudio");
            attractionGloveInst.release();
            camera.GetComponent<GravityGun2>().enabled = true;
            selectionManager.GetComponent<SelectionManager>().enabled = true;
            //gravityGunButton.enabled = false;
            gravityGunPurchased = true;
            gravityGunButton.image.enabled = false;
            //Destroy(info);
            Destroy(gravityGunButton);
            Destroy(gravityGunNotAffordable);
            gravityGunUnlocked.SetActive(true);
            TapDestroy.count -= gravityGunCost;
            CostCheck();
            EnableButtons();

        }
    }
    
    public void EnableCrouch()
    {
        player.GetComponent<Shrink>().enabled = true;
        //CrouchButton.enabled = false;
        CrouchButton.image.enabled = false;
        Destroy(CrouchButton);
        Destroy(crouchNotAffordable);
        crouchUnlocked.SetActive(true);
        crouchPurchased = true;
        TapDestroy.count -= crouchCost;
        CostCheck();
        EnableButtons();
    }

    void EnableButtons()
    {
        if (gravityGunAffordable && !gravityGunPurchased)
        {
            gravityGunButton.enabled = true;
            gravityGunButton.image.enabled = true;
            
            gravityGunNotAffordable.SetActive(false);
        }
        else if(!gravityGunAffordable)
        {
            gravityGunButton.enabled = false;
            gravityGunButton.image.enabled = false;
            
            gravityGunNotAffordable.SetActive(true);
        }

        if (crouchAffordable && !crouchPurchased)
        {
            CrouchButton.enabled = true;
            CrouchButton.image.enabled = true;
            
            crouchNotAffordable.SetActive(false);
        }
        else if (!crouchAffordable)
        {
            CrouchButton.enabled = false;
            CrouchButton.image.enabled = false;
            
            crouchNotAffordable.SetActive(true);
        }
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
        if (TapDestroy.count >= crouchCost)
            crouchAffordable = true;
        else
            crouchAffordable = false;
        /*if (!gravityGunPurchased && TapDestroy.count >= crouchCost)
            info.SetActive(true);
        else
            info.SetActive(false);*/
    }
}
