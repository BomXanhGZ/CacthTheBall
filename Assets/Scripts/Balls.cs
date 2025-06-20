using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public enum e_BallType
    {
        NONE = 0,
        RED_BALL = 1,
        GREEN_BALL = 2,
        BLUE_BALL = 3,
        YELLOW_BALL = 4,
        BLACK_BALL = 5
    };

    public e_BallType m_Ball_Type = e_BallType.NONE;
    public int m_Score = 0;
    public float x_move = 0;
    public float y_move = 0;

    public Sprite redBall_Sprite;
    public Sprite greenBall_Sprite;
    public Sprite blueBall_Sprite;
    public Sprite yellowBall_Sprite;
    public Sprite blackBall_Sprite;

    private SpriteRenderer sp_render;
    private Catcher catcher;
    private GameController game_controller;


    private void Start()                                            //Start
    {
        catcher = FindObjectOfType<Catcher>();
        game_controller = FindObjectOfType<GameController>();

        sp_render = GetComponent<SpriteRenderer>();
        InitDataBall();
    }

    private void OnCollisionEnter2D(Collision2D col)                //Collider
    {
        if (col.gameObject.name == "CatchBar")
        {
            catcher.IncrementScore(m_Score);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)                   //Trigger
    {
        if (col.gameObject.name == "DeathZone")
        {
            Destroy(gameObject);
            game_controller.Set_IsGameOver(true);
        }
    }

    public void SetBallType(int rand_val)
    {
        if(rand_val < GameData.RANGE_RED)
        {
            m_Ball_Type = e_BallType.RED_BALL;
        }
        else if(rand_val < GameData.RANGE_GREEN)
        {
            m_Ball_Type = e_BallType.GREEN_BALL;
        }
        else if(rand_val < GameData.RANGE_BLUE)
        {
            m_Ball_Type = e_BallType.BLUE_BALL;
        }
        else if (rand_val < GameData.RANGE_YELLOW)
        {
            m_Ball_Type = e_BallType.YELLOW_BALL;
        }
        else if (rand_val < GameData.RANGE_BLACK)
        {
            m_Ball_Type = e_BallType.BLACK_BALL;
        }
        else 
        {
            m_Ball_Type = e_BallType.RED_BALL; 
        }
    }

    private void InitDataBall()                                      //Set data
    {
        if (m_Ball_Type == e_BallType.RED_BALL)
        {
            m_Score = GameData.RED_BALL_SCORE;
            sp_render.sprite = redBall_Sprite;
        }
        else if (m_Ball_Type == e_BallType.GREEN_BALL)
        {
            m_Score = GameData.GREEN_BALL_SCORE;
            sp_render.sprite = greenBall_Sprite;
        }
        else if (m_Ball_Type == e_BallType.BLUE_BALL)
        {
            m_Score = GameData.BLUE_BALL_SCORE;
            sp_render.sprite = blueBall_Sprite;
        }
        else if (m_Ball_Type == e_BallType.YELLOW_BALL)
        {
            m_Score = GameData.YELLOW_BALL_SCORE;
            sp_render.sprite = yellowBall_Sprite;
        }
        else if (m_Ball_Type == e_BallType.BLACK_BALL)
        {
            m_Score = GameData.BLACK_BALL_SCORE;
            sp_render.sprite = blackBall_Sprite;
        }
        else { Debug.Log("error: missing the enter BallType !!"); }
    }
}
