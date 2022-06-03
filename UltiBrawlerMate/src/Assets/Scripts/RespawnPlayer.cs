using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;



public class RespawnPlayer : MonoBehaviour
{
    public Text winner;

    public GameObject winnerGameObject;

    public EventSystem eventSystemWinner;
    public GameObject restartBtn;

    public int Lifes;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;
    [SerializeField]
    private GameObject player4;


    [SerializeField]
    private int player1Life;
    [SerializeField]
    private int player2Life;
    [SerializeField]
    private int player3Life;
    [SerializeField]
    private int player4Life;


    [SerializeField]
    private bool player1Lose;
    [SerializeField]
    private bool player2Lose;
    [SerializeField]
    private bool player3Lose;
    [SerializeField]
    private bool player4Lose;
    private bool is4Player;
    private bool winMenu;

    public Image Life11;
    public Image Life12;
    public Image Life13;
    public Image Life21;
    public Image Life22;
    public Image Life23;
    public Image Life31;
    public Image Life32;
    public Image Life33;
    public Image Life41;
    public Image Life42;
    public Image Life43;
    public Image Life112;
    public Image Life122;
    public Image Life132;
    public Image Life212;
    public Image Life222;
    public Image Life232;

    private PlayerAttack playerAttack;







    void Start()
    {

        player1Life = Lifes;

        player2Life = Lifes;

        player4Life = Lifes;

        player3Life = Lifes;


    }





    void Update()
    {


        if (player1 == null)
        {
            player1 = GameObject.Find("Player1");
        }

        if (player2 == null)
        {
            player2 = GameObject.Find("Player2");
        }

        if (player3 == null)
        {
            player3 = GameObject.Find("Player3");
        }

        if (player4 == null)
        {
            player4 = GameObject.Find("Player4");
        }
        else
        {
            is4Player = true;
        }



        if (player1Life <= 0)
        {

            print("Player 1 Loses");

            player1Lose = true;

            player1.SetActive(false);

        }

        if (player2Life <= 0)
        {

            player2Lose = true;

            print("Player 2 Loses");

            player2.SetActive(false);

        }

        if (player3Life <= 0)
        {

            print("Player 3 Loses");

            player3Lose = true;

            player3.SetActive(false);

        }

        if (player4Life <= 0)
        {

            player4Lose = true;

            print("Player 4 Loses");

            player4.SetActive(false);

        }



        if (is4Player)
        {
            if (player1Lose && player2Lose && player3Lose)
            {

                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                eventSystemWinner.SetSelectedGameObject(winnerGameObject.transform.GetChild(0).GetChild(2).gameObject);
                winner.text = "Player 4 Wins";
                Time.timeScale = 0f;


            }

            if (player1Lose && player2Lose && player4Lose)
            {
                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                eventSystemWinner.SetSelectedGameObject(winnerGameObject.transform.GetChild(0).GetChild(2).gameObject);
                winner.text = "Player 3 Wins";
                Time.timeScale = 0f;

            }

            if (player1Lose && player3Lose && player4Lose)
            {
                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                eventSystemWinner.SetSelectedGameObject(winnerGameObject.transform.GetChild(0).GetChild(2).gameObject);
                winner.text = "Player 2 Wins";
                Time.timeScale = 0f;

            }

            if (player2Lose && player3Lose && player4Lose)
            {
                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                eventSystemWinner.SetSelectedGameObject(winnerGameObject.transform.GetChild(0).GetChild(2).gameObject);
                winner.text = "Player 1 Wins";
                Time.timeScale = 0f;

            }
        }
        else
        {
            if (player2Lose)
            {
                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                winner.text = "Player 1 Wins";
                Time.timeScale = 0f;
            }
            if (player1Lose)
            {
                winnerGameObject.SetActive(true);
                if (!winMenu)
                {
                    eventSystemWinner.SetSelectedGameObject(restartBtn);
                    winMenu = true;
                }
                winner.text = "Player 2 Wins";
                Time.timeScale = 0f;
            }
        }

        UpdateLifeText();
    }



    private void OnTriggerExit2D(Collider2D collision)

    {

        if (collision.gameObject.name == "Player1" && !collision.isTrigger)
        {

            player1Life = RespawnAndLifesHandler(collision, player1Life);

        }

        else if (collision.gameObject.name == "Player2" && !collision.isTrigger)
        {

            player2Life = RespawnAndLifesHandler(collision, player2Life);

        }

        else if (collision.gameObject.name == "Player3" && !collision.isTrigger)
        {

            player3Life = RespawnAndLifesHandler(collision, player3Life);

        }

        else if (collision.gameObject.name == "Player4" && !collision.isTrigger)
        {

            player4Life = RespawnAndLifesHandler(collision, player4Life);

        }
    }

    private void UpdateLifeText()
    {
        if (is4Player)
        {
            switch (player1Life)
            {
                case 0:
                    Life11.gameObject.SetActive(false);
                    break;
                case 1:
                    Life12.gameObject.SetActive(false);
                    break;
                case 2:
                    Life13.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (player2Life)
            {
                case 0:
                    Life21.gameObject.SetActive(false);
                    break;
                case 1:
                    Life22.gameObject.SetActive(false);
                    break;
                case 2:
                    Life23.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (player3Life)
            {
                case 0:
                    Life31.gameObject.SetActive(false);
                    break;
                case 1:
                    Life32.gameObject.SetActive(false);
                    break;
                case 2:
                    Life33.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (player4Life)
            {
                case 0:
                    Life41.gameObject.SetActive(false);
                    break;
                case 1:
                    Life42.gameObject.SetActive(false);
                    break;
                case 2:
                    Life43.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (player1Life)
            {
                case 0:
                    Life112.gameObject.SetActive(false);
                    break;
                case 1:
                    Life122.gameObject.SetActive(false);
                    break;
                case 2:
                    Life132.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (player2Life)
            {
                case 0:
                    Life212.gameObject.SetActive(false);
                    break;
                case 1:
                    Life222.gameObject.SetActive(false);
                    break;
                case 2:
                    Life232.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private int RespawnAndLifesHandler(Collider2D collision, int playerlife)
    {

        collision.gameObject.GetComponent<PlayerAttack>().DamageTaken = 0;

        collision.gameObject.transform.position = new Vector3(Random.Range(-6, 6.1f), 6, 0);

        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        playerlife -= 1;

        return playerlife;

    }
    

}