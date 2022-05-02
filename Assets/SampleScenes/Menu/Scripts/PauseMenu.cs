using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //private Toggle m_MenuToggle;
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameUI;


    /*void Awake()
    {
        m_MenuToggle = GetComponent <Toggle> ();
	}*/


    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        m_Paused = true;
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void MenuOff ()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void OnMenuStatusChange ()
    {
        if (!m_Paused) //m_MenuToggle.isOn && 
        {
            MenuOn();
        }
        else if (m_Paused) //!m_MenuToggle.isOn && 
        {
            MenuOff();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Quit()
    {
        Application.Quit();
    }

#if !MOBILE_INPUT
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
            OnMenuStatusChange();
		    /*m_MenuToggle.isOn = !m_MenuToggle.isOn;
            Cursor.visible = m_MenuToggle.isOn;//force the cursor visible if anythign had hidden it*/
		}
	}
#endif

}
