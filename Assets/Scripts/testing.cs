using UnityEngine;

public class testing : MonoBehaviour
{
    public MapManager manager;

    void Awake()
    {
        //Begins the initial spawning of map sections
        manager.init();
    }
    private void FixedUpdate()
    {
        //constantly checks if any track bas fallen behind and needs to be deleted, or need to be spawned infront
        manager.checkTrack();
    }
}
