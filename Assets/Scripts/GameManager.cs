using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if(Globals.paused == false)
        {
            transform.Translate(3f * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(0f * Time.deltaTime, 0f, 0f);
        }
    }
}