using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        //ensure object with audio player attached is not deleted between sceen swap
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
