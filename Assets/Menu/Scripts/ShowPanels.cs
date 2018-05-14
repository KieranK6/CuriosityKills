using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    GameObject player;


	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
        //player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponentInChildren<PlayerLook>().disableLook = true;
        //player.GetComponent<PlayerMove>().disableMovement = true;
        //ursor.lockState = CursorLockMode.None;
        
        optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
        Cursor.visible = true;
    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        //Cursor.lockState = CursorLockMode.Locked;
        
        optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
        Cursor.visible = true;
    }

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}
}
