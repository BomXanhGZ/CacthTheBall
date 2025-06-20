using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool Is_ShowGameOverPanel = false;
    int m_score = 0;

    public Text scoreText;
    public GameObject gameOverPanel;
    GameController ref_controller;
    Catcher ref_catcher;

    //Set_Function
    public void SetIsShowGameOverPanel(bool state) { Is_ShowGameOverPanel = state;}

    //Get_Function

    void Start()
    {
        ref_controller = FindObjectOfType<GameController>();
        ref_catcher = FindObjectOfType<Catcher>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
        ShowGameOverPanel();
    }

    void ShowScore()
    {
        if (ref_catcher != null)
        {
            m_score =  ref_catcher.GetScore();
            if (scoreText)
            {
                scoreText.text = "Score: " + m_score;
            }
        }
    }

    void ShowGameOverPanel()
    {
        if(!gameOverPanel)
        {
            Debug.Log("game over panel null !");
            return;
        }

        if (Is_ShowGameOverPanel)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void OnClickReplay()
    {
        Time.timeScale = 1.0f;
        ref_controller.ReSetTimeGame();
        ref_controller.Set_IsGameOver(false);
        ref_catcher.ReSetScore();
        Is_ShowGameOverPanel = false;
    }
}
