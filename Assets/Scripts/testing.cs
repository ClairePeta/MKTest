using UnityEngine;

public class testing : MonoBehaviour
{
    public MapManager manager;

    void Start()
    {
        
        Debug.Log("about to mall map manager.init");
        manager.init();
    }
    private void FixedUpdate()
    {
        manager.checkTrack();
    }
}
