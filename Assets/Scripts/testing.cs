using UnityEngine;

public class testing : MonoBehaviour
{
    public MapManager manager;

    void Start()
    {
        manager.init();
    }
    private void FixedUpdate()
    {
        manager.checkTrack();
    }
}
