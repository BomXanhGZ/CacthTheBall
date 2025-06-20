using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool is_GameOver;
    int timeGame = 0;
    float deltaTime;

    UIManager ref_ui;

    //SetFunction
    public void Set_IsGameOver(bool state) {  is_GameOver = state; }
    public void ReSetTimeGame() { timeGame = 0; }
    

    //GetFunction
    public bool Get_IsGameOver() { return is_GameOver; }
    public int GetTimeGame() { return timeGame; }


    void Start()
    {
        is_GameOver = false;
        ref_ui =  FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (is_GameOver) 
        {
            HandleGameOver();
        }
        else
        {
            HandleSpeedGame();
        }
    }

    private void HandleSpeedGame()
    {
        deltaTime += Time.unscaledDeltaTime;
        timeGame += (int)deltaTime;
        if(deltaTime >= GameData.TIME_ONCE_TEMP)
        {
            Time.timeScale += GameData.SPEED_UP_VAL;
            deltaTime -= GameData.TIME_ONCE_TEMP;
        }
    }

    private void HandleGameOver()
    {
        if(is_GameOver)
        {
            Time.timeScale = 0;
            deltaTime = 0;
            ref_ui.SetIsShowGameOverPanel(true);
        }
    }
}
