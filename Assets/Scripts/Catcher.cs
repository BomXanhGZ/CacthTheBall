using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Catcher : MonoBehaviour
{
    //variable
    int m_Score = 0;
    [SerializeField] float m_speed = 0;

    //set function
    public void ReSetScore() { m_Score = 0; }

    //get function
    public int GetScore() { return m_Score; }





    #region UNITY METHODS
    private void Awake()
    {
        m_speed = GameData.CATCHER_SPEED;
    }

    void Update()  
    {
        HandleMove();
    }
    #endregion



    #region CUSTOM METHODS
    void HandleMove()
    {
        float Dir = Input.GetAxisRaw("Horizontal");
        if (transform.position.x < -GameData.HALF_SCREEN_X && Dir < 0
         || transform.position.x > GameData.HALF_SCREEN_X && Dir > 0)
        { return; }

        Vector3 Move_val = new Vector3(Dir * m_speed * Time.deltaTime, 0, 0);
        transform.position += Move_val;
    }

    public void IncrementScore(int sc_val)
    {
        m_Score += sc_val;
        Debug.Log("Score: " + m_Score);
    }
    #endregion
}
