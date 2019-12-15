using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public MapManager manager;
    public GameObject countdownCanvas;
    public Rigidbody rb;
    public BoxCollider collide;
    public Animator characterAnimator;
    public float jumpSpeed = 5f;
    bool jump = false;
    bool duck = false;
    int score = 0;
    float respawnx;

    public float OriginalHeight = 1f;
    public float CrouchHeight = 0.5f;
    public Transform targetMesh;

    private void Awake()
    {
        Globals.lives = 3;
        Globals.gameScore = score;
        Globals.playerPositionX = transform.position.x;
        Globals.paused = false;
        characterAnimator.Play("Run");
    }

    void Update()
    {
        Globals.gameScore = score;
        Globals.playerPositionX = transform.position.x;

        if(transform.position.y < (-5))
        {
            if(Globals.lives < 1)
            {
                manager.reset();
            }
            livesLost();
        }
    }

    public void OnJumpClick()
    {
        //makes the player jump
        if (!jump)
        {
            //characterAnimator.Play("Idle");
            jump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jump = false;
        }
    }

    public void OnDuckClick()
    {
        //makes the player duck then return to normal size after three seconds
        if (!duck)
        {
            duck = true;
            //changes the mesh and collider to fit the smaller player
            targetMesh.localScale = new Vector3(1, 0.5f, 1);
            collide.center = new Vector3(0, -0.25f, 0);
            collide.size = new Vector3(1, 1.5f, 1);
            StartCoroutine(endDuck(1.5f));
            duck = false;
        }
    }

    public void livesLost()
    {
        //removes a life then checks if the character needs to be respawned or game over
        Globals.paused = true;
        respawnx = transform.position.x;
        Globals.lives--;
        if (Globals.lives > 0)
        {
            respawnCharacter();
        }
        else
        {
            manager.reset();
            StartCoroutine(endDuck(3));
            Globals.gameScore = score;
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //checks collided trigger for death or score increment
        if (other.gameObject.name == "Carrot")
        {
            score++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Mace")
        {
            livesLost();
        }
        if (other.gameObject.name == "Spike_Down")
        {
            livesLost();
        }
        if (other.gameObject.name == "Saw")
        {
            livesLost();
        }
    }

    public void respawnCharacter()
    {
        //respawns character after canvas countsdown
        this.transform.position = new Vector3(respawnx, 10f, 0f);
        StartCoroutine(ResumeGame(3));
    }

    private IEnumerator endDuck(float time)
    {
        //halfs the player then returns them to normal size
        float elapsedTime = 0;

        while (elapsedTime / time < 1)
        {
            //transform.position = new Vector3(transform.position.x, -3, transform.position.z);
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        collide.size = new Vector3(1, 1, 1);
        collide.center = new Vector3(0, 0, 0);
        targetMesh.localScale = new Vector3(1, 1, 1);
        characterAnimator.Play("Run");
    }

    private IEnumerator ResumeGame(float time)
    {
        //toggles the countdown times, then resumes the game
        countdownCanvas.SetActive(true);
        TextMeshProUGUI text = countdownCanvas.GetComponentInChildren<TextMeshProUGUI>();
        float elapsedTime = 0;

        while (elapsedTime / time < 1)
        {
            int counter = 3 - (int)elapsedTime;
            text.text = counter.ToString();
            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
        }
        countdownCanvas.SetActive(false);
        Globals.paused = false;
        
        this.transform.position = new Vector3(respawnx, 3f, 0f);
        characterAnimator.Play("Run");
    }
}
