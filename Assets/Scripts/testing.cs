using UnityEngine;

public class testing : MonoBehaviour
{
    public MapManager manager;

    void Awake()
    {
        manager.init();
    }
    private void FixedUpdate()
    {
        manager.checkTrack();
    }
}
