using UnityEngine;

public class GameManager : MonoBehaviour
{
    float speed = 3.0f;
    float counter = 0;

    private void Awake()
    {
        //set initial speed
        speed = 3.0f;
    }

    void Update()
    {
        //starts and stop the movement of the character in the game
        if(Globals.paused == false)
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            //paused when in game menu is open and after deaths
            transform.Translate(0f * Time.deltaTime, 0f, 0f);
        }

        //counter that increments speed based on how long the player has been playing the level
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
    }
}
