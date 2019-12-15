using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        //makes the camera follow x position of the player as it runs alog the course
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
