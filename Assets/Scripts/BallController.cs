using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float spawn_time = GameData.BALL_SPAWN_TIME;

    public GameObject ref_Balls;
   

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        //make ball
        spawn_time -= Time.deltaTime;
        if (spawn_time < 0)
        {
            SpawnBall();

            spawn_time = GameData.BALL_SPAWN_TIME;
        }
    }

    void SpawnBall()
    {
        if (!ref_Balls)
        {
            Debug.Log("error: enter ref_balls is null !");
            return;
        }

        Vector2 spawn_pos = new Vector2(   Random.Range(-GameData.HALF_SCREEN_X, GameData.HALF_SCREEN_X),
                                           GameData.HALF_SCREEN_y + 1   );

        int Rad_val = Random.Range(1, GameData.MAX_RANDOM_BALL_RANGE);
        GameObject newBall = Instantiate(ref_Balls, spawn_pos, Quaternion.identity);

        Balls ScriptBalls = newBall.GetComponent<Balls>();
        ScriptBalls.SetBallType(Rad_val);
    }
}
