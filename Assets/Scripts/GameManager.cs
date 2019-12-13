using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(3f * Time.deltaTime, 0f, 0f);
    }
}