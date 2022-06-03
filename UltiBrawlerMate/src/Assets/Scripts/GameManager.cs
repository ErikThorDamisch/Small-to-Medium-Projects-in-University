using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character01;
    public GameObject character02;
    public GameObject character03;
    public GameObject character04;
    private GameObject tempcharacter;

    public Canvas pauseMenu;
    public EventSystem EventSystem;
    public GameObject mainMenuBtn;

    public string scene;

    public Canvas twoPlayer;
    public Canvas fourPlayer;

    public Sprite character01Sprite;
    public Sprite character02Sprite;
    public Sprite character03Sprite;
    public Sprite character04Sprite;

    public Text Player12;
    public Text Player22;
    public Text Player14;
    public Text Player24;
    public Text Player34;
    public Text Player44;

    public AudioSource sounds;
    public AudioClip fight;
    public AudioClip gameMusic;



    bool isGamePause;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        setHUD();
        spawnCharacters();
        scene = SceneManager.GetActiveScene().name;
        sounds.PlayOneShot(fight, PlayerPrefs.GetFloat("InGameVolumePreferences"));
        sounds.volume = PlayerPrefs.GetFloat("InGameVolumePreferences") / 4;
        sounds.PlayDelayed(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
    }
    void setHUD()
    {
        if (PlayerPrefs.GetInt("PlayerNumber") == 4)
        {
            twoPlayer.gameObject.SetActive(false);
            fourPlayer.gameObject.SetActive(true);
        }
        else
        {
            twoPlayer.gameObject.SetActive(true);
            fourPlayer.gameObject.SetActive(false);
        }
        

    }
    void PauseGame()
    {
        isGamePause = !isGamePause;
        if (isGamePause)
        {
            Time.timeScale = 0f;
            pauseMenu.gameObject.SetActive(true);
            
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.gameObject.SetActive(false);
        }
    }
    void spawnCharacters()
    {
        int characterSelect = PlayerPrefs.GetInt("CharacterPlayer1");
        switch (characterSelect)
        {
            case 1:
                tempcharacter = Instantiate<GameObject>(character01);
                tempcharacter.name = "Player1";
                tempcharacter.transform.position = new Vector3(-11,5,0);
                GameObject.Find("Player1Image").GetComponent<Image>().sprite = character01Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player12 : Player14;
                break;
            case 2:
                tempcharacter = Instantiate<GameObject>(character02);
                tempcharacter.name = "Player1";
                tempcharacter.transform.position = new Vector3(-11, 5, 0);
                GameObject.Find("Player1Image").GetComponent<Image>().sprite = character02Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player12 : Player14;

                break;
            case 3:
                tempcharacter = Instantiate<GameObject>(character03);
                tempcharacter.name = "Player1";
                tempcharacter.transform.position = new Vector3(-11, 5, 0);
                GameObject.Find("Player1Image").GetComponent<Image>().sprite = character03Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player12 : Player14;

                break;
            case 4:
                tempcharacter = Instantiate<GameObject>(character04);
                tempcharacter.name = "Player1";
                tempcharacter.transform.position = new Vector3(-11, 5, 0);
                GameObject.Find("Player1Image").GetComponent<Image>().sprite = character04Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player12 : Player14;

                break;

        }
        characterSelect = PlayerPrefs.GetInt("CharacterPlayer2");
        switch (characterSelect)
        {
            case 1:
                tempcharacter = Instantiate<GameObject>(character01);
                tempcharacter.name = "Player2";
                tempcharacter.transform.position = new Vector3(5, 5, 0);
                GameObject.Find("Player2Image").GetComponent<Image>().sprite = character01Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player22 : Player24;

                break;
            case 2:
                tempcharacter = Instantiate<GameObject>(character02);
                tempcharacter.name = "Player2";
                tempcharacter.transform.position = new Vector3(5, 5, 0);
                GameObject.Find("Player2Image").GetComponent<Image>().sprite = character02Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player22 : Player24;

                break;
            case 3:
                tempcharacter = Instantiate<GameObject>(character03);
                tempcharacter.name = "Player2";
                tempcharacter.transform.position = new Vector3(5, 5, 0);
                GameObject.Find("Player2Image").GetComponent<Image>().sprite = character03Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player22 : Player24;

                break;
            case 4:
                tempcharacter = Instantiate<GameObject>(character04);
                tempcharacter.name = "Player2";
                tempcharacter.transform.position = new Vector3(5, 5, 0);
                GameObject.Find("Player2Image").GetComponent<Image>().sprite = character04Sprite;
                tempcharacter.GetComponent<PlayerAttack>().DamageText = PlayerPrefs.GetInt("PlayerNumber") == 2 ? Player22 : Player24;

                break;
        }
        if(PlayerPrefs.GetInt("PlayerNumber") == 4)
        {
            characterSelect = PlayerPrefs.GetInt("CharacterPlayer3");
            switch (characterSelect)
            {
                case 1:
                    tempcharacter = Instantiate<GameObject>(character01);
                    tempcharacter.name = "Player3";
                    tempcharacter.transform.position = new Vector3(-13, 5, 0);
                    GameObject.Find("Player3Image").GetComponent<Image>().sprite = character01Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player34;
                    break;
                case 2:
                    tempcharacter = Instantiate<GameObject>(character02);
                    tempcharacter.name = "Player3";
                    tempcharacter.transform.position = new Vector3(-13, 5, 0);
                    GameObject.Find("Player3Image").GetComponent<Image>().sprite = character02Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player34;

                    break;
                case 3:
                    tempcharacter = Instantiate<GameObject>(character03);
                    tempcharacter.name = "Player3";
                    tempcharacter.transform.position = new Vector3(-13, 5, 0);
                    GameObject.Find("Player3Image").GetComponent<Image>().sprite = character03Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player34;

                    break;
                case 4:
                    tempcharacter = Instantiate<GameObject>(character04);
                    tempcharacter.name = "Player3";
                    tempcharacter.transform.position = new Vector3(-13, 5, 0);
                    GameObject.Find("Player3Image").GetComponent<Image>().sprite = character04Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player34;

                    break;
            }
            characterSelect = PlayerPrefs.GetInt("CharacterPlayer4");
            switch (characterSelect)
            {
                case 1:
                    tempcharacter = Instantiate<GameObject>(character01);
                    tempcharacter.name = "Player4";
                    tempcharacter.transform.position = new Vector3(7, 5, 0);
                    GameObject.Find("Player4Image").GetComponent<Image>().sprite = character01Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player44;

                    break;
                case 2:
                    tempcharacter = Instantiate<GameObject>(character02);
                    tempcharacter.name = "Player4";
                    tempcharacter.transform.position = new Vector3(7, 5, 0);
                    GameObject.Find("Player4Image").GetComponent<Image>().sprite = character02Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player44;

                    break;
                case 3:
                    tempcharacter = Instantiate<GameObject>(character03);
                    tempcharacter.name = "Player4";
                    tempcharacter.transform.position = new Vector3(7, 5, 0);
                    GameObject.Find("Player4Image").GetComponent<Image>().sprite = character03Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player44;

                    break;
                case 4:
                    tempcharacter = Instantiate<GameObject>(character04);
                    tempcharacter.name = "Player4";
                    tempcharacter.transform.position = new Vector3(7, 5, 0);
                    GameObject.Find("Player4Image").GetComponent<Image>().sprite = character04Sprite;
                    tempcharacter.GetComponent<PlayerAttack>().DamageText = Player44;

                    break;
            }
        }
        
    }
    public void OnClickResumeGame()
    {
        PauseGame();
    }
    public void OnClickRestartGame()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    public void OnClickBackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }
}
