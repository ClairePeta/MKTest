using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    float speed = 3.0f;
    float counter = 0;
    void Update()
    {
        if(Globals.paused == false)
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(0f * Time.deltaTime, 0f, 0f);
        }
        counter += Time.deltaTime;
        if(counter >= 30)
        {
            incrementSpeed();
            counter = 0;
        }

    }
    void incrementSpeed()
    {
        speed += 0.5f;
        Debug.Log("Speed is now " + speed);
    }

}
