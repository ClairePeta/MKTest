using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSection : MonoBehaviour
{
    public List<float> pathEnterance;
    public List<float> pathExit;
    public int length;

    public void destroySection()
    {
        Destroy(gameObject, 0.0f);
    }
}
