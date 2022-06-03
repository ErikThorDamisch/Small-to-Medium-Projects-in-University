using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Menu currentMenu;
    public Menu player3;
    public Menu chooseMap;

    public Slider backgroundSoundSlider;
    public AudioSource backgroundSound;

    public Slider inGameSlider;

    public Image buttonPress;

    public Sprite squareButton;
    public Sprite aButton;

    string[] controllerNames;


    // Start is called before the first frame update
    void Start()
    {
        deletePlayerPrefs();
        ShowMenu(currentMenu);
        backgroundSound.Play();
        Time.timeScale = 1;
        getController();
        PlayerPrefs.SetFloat("InGameVolumePreferences", inGameSlider.value = 1);
    }

    void Update()
    {
        
    }

    public void ShowMenu(Menu menu)
    {
        if (currentMenu != null)
        {
            currentMenu.IsOpen = false;
        }
        currentMenu = menu;
        currentMenu.IsOpen = true;

    }
    private void getController()
    {
        controllerNames = Input.GetJoystickNames();
        for (int i = 0; i < controllerNames.Length; i++)
        {
            if (controllerNames[i].Length == 19)
            {
                buttonPress.GetComponent<Image>().sprite = squareButton;
                //PS4 controller Returns "Wireless Controller" thats why 19
            }
            if(controllerNames[i].Length == 33)
            {
                buttonPress.GetComponent<Image>().sprite = aButton;
                //XBox controller Returns "Controller (Xbox One For Windows)" 33
            }
        }
    }
    void OnEnable()
    {
        backgroundSoundSlider.onValueChanged.AddListener(delegate { OnSoundSliderChange(); });
        inGameSlider.onValueChanged.AddListener(delegate { OnSoundSliderChange(); });
    }

    public void OnSoundSliderChange()
    {
        PlayerPrefs.SetFloat("BGVolumePreferences", backgroundSoundSlider.value);
        backgroundSound.volume = PlayerPrefs.GetFloat("BGVolumePreferences", backgroundSoundSlider.value);
        PlayerPrefs.SetFloat("InGameVolumePreferences", inGameSlider.value);

    }
    /*if (currentMenu != null)
        currentMenu.IsOpen = false;

    currentMenu = menu;
    currentMenu.IsOpen = true;

    if(PlayerPrefs.GetInt("PlayerNumber")== 4)
    {
        loadPlayer3(player3,menu);
    }*/
    public void numberOfPlayers(int playerNumber)
    {
        PlayerPrefs.SetInt("PlayerNumber", playerNumber);
    }
    public void PlayerOne(int characterNumber)
    {
        PlayerPrefs.SetInt("CharacterPlayer1", characterNumber);
    }

    public void PlayerTwo(int characterNumber)
    {
        PlayerPrefs.SetInt("CharacterPlayer2", characterNumber);
    }
    public void PlayerThree(int characterNumber)
    {
        PlayerPrefs.SetInt("CharacterPlayer3", characterNumber);
    }
    public void PlayerFour(int characterNumber)
    {
        PlayerPrefs.SetInt("CharacterPlayer4", characterNumber);
    }
    public void SoundsPreference(float sound)
    {
        PlayerPrefs.SetFloat("Sound", sound);
    }
    public void loadMorePlayer()
    {
        if (currentMenu != null)
        {
            currentMenu.IsOpen = false;
        }

        if (PlayerPrefs.GetInt("PlayerNumber") == 4)
        {
            currentMenu = player3;
            currentMenu.IsOpen = true;
        }
        else
        {
            currentMenu = chooseMap;
            currentMenu.IsOpen = true;
        }

    }
    
    public void loadScene (string map)
    {
        SceneManager.LoadScene(map);
    }
    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
