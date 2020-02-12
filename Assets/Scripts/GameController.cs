using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Ball;

    public static bool isPaused;
    public static bool StartPlay;
    public static bool ShowInfo;
    public static bool IsReset;
    public static string ballPlayer;
    public static int P1Point;
    public static int P2Point;

    private Text P1Score;
    private Text P2Score;
    private Text info;
    private Text playerWin;
    private GameObject InfoObj;
    private GameObject ShowWinner;


    // Start is called before the first frame update
    void Start()
    {
        ballPlayer = "Player2";
        IsReset = true;
        StartPlay = false;

        P1Score = GameObject.Find("P1Score").GetComponent<Text>();
        P2Score = GameObject.Find("P2Score").GetComponent<Text>();

        P1Point = 0;
        P2Point = 0;
        isPaused = false;
        ShowInfo = false;

        P1Score.text = P1Point.ToString();
        P2Score.text = P2Point.ToString();

        InfoObj = GameObject.Find("Info");
        InfoObj.SetActive(false);

        ShowWinner = GameObject.Find("GameOver");
        ShowWinner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Reset Position
        if (IsReset)
        {
            resetPlay(ballPlayer);
            IsReset = false;
            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        // Start play
        if (StartPlay)
        {
            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Time.timeScale = 1;
            StartPlay = false;
        }

        // Show Info
        if (ShowInfo)
        {
            ShowInfo = false;
            //isPaused = true;
            StartCoroutine(PointInfo());
        }

        // Game End
        if (P1Point == 10 || P2Point == 10)
        {
            InfoObj.SetActive(false);
            Time.timeScale = 0;
            isPaused = true;
            if (P1Point == 10)
            {
                Win("Player1");
            }
            else if (P2Point == 10)
            {
                Win("Player1");
            }
        }
    }

    public void IsPauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void BtnPlay()
    {
        Time.timeScale = 0;
        isPaused = false;
    }

    public void resetPlay(string onPlayer)
    {
        Player1.transform.position = new Vector2(-5f, -3.2f);
        Player2.transform.position = new Vector2(5f, -3.2f);
        Player1.GetComponent<Animator>().SetBool("IsMove", false);
        Player2.GetComponent<Animator>().SetBool("IsMove", false);
        Player1.GetComponent<Animator>().SetBool("IsJump", false);
        Player2.GetComponent<Animator>().SetBool("IsJump", false);

        float xBall = 4.3f;

        if (onPlayer.Equals("Player1"))
        {
            Ball.transform.position = new Vector2(xBall, 1);
            P2Score.text = P2Point.ToString();
        }
        else if (onPlayer.Equals("Player2"))
        {
            Ball.transform.position = new Vector2(xBall * -1, 1);
            P1Score.text = P1Point.ToString();
        }
    }

    public void Win(string winner)
    {
        ShowWinner.SetActive(true);

        Text playerWin = GameObject.Find("TxtGameOver").GetComponent<Text>();

        if (winner.Equals("Player1"))
        {
            playerWin.text = "Player 1 Wins";
        }
        else if (winner.Equals("Player2"))
        {
            playerWin.text = "Player 2 Wins";
        }
    }

    private IEnumerator PointInfo()
    {
        
        InfoObj.SetActive(true);

        Text info = GameObject.Find("TxtInfo").GetComponent<Text>();

        if (ballPlayer.Equals("Player1"))
        {
            info.text = "Point for\n player 2"; 
        }
        else if (ballPlayer.Equals("Player2"))
        {
            info.text = "Point for\n player 1";
        }

        yield return new WaitForSeconds(2f);

        InfoObj.SetActive(false);
        isPaused = false;
        Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
