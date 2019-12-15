using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSection : MonoBehaviour
{
    public List<float> pathEnterance;
    public List<float> pathExit;
    public int length;

    //called when the map section falls behind the camera and goes off screen
    public void destroySection()
    {
        Destroy(gameObject, 0.0f);
    }
}
