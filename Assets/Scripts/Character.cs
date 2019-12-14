using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject countdownCanvas;
    public Rigidbody rb;
    public BoxCollider collide;
    Animator characterAnimator;
    public enum Animation { Walk, Run, Jump, Hit, None }
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
        characterAnimator = GetComponentInChildren<Animator>();
        Globals.lives = 3;
        Globals.gameScore = score;
    }

    void Update()
    {
        Globals.gameScore = score;
        Globals.playerPositionX = transform.position.x;
        if (Input.GetKeyDown(KeyCode.D))
        {
            characterAnimator.Play("Jump"); 
        }
        if(transform.position.y < (-5))
        {
            livesLost();
        }
    }

    public void OnJumpClick()
    {
        if (!jump)
        {
            jump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jump = false;
        }
    }

    public void OnDuckClick()
    {
        if (!duck)
        {
            duck = true;
            targetMesh.localScale = new Vector3(1, 0.5f, 1);
            collide.center = new Vector3(0, -0.25f, 0);
            collide.size = new Vector3(1, 1.5f, 1);
            StartCoroutine(endDuck(1.5f));
            duck = false;
        }
    }

    public void livesLost()
    {
        Globals.paused = true;
        respawnx = transform.position.x;
        Globals.lives--;
        if (Globals.lives > 0)
        {
            respawnCharacter();
        }
        else
        {
            Globals.gameScore = score;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over");
        }
    }

    void OnTriggerEnter(Collider other)
    {
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
        this.transform.position = new Vector3(respawnx, 10f, 0f);
        StartCoroutine(ResumeGame(3));
    }

    private IEnumerator endDuck(float time)
    {
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
    }

    private IEnumerator ResumeGame(float time)
    {
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
        
        this.transform.position = new Vector3(respawnx, 1.5f, 0f);
    }
}
