using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject countdownCanvas;
    public Rigidbody rb;
    Animator characterAnimator;
    public enum Animation { Walk, Run, Jump, Hit, None }
    public float jumpSpeed = 6f;
    bool jump = false;
    int score = 0;
    float respawnx;

    private void Awake()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        Globals.lives = 3;
        Globals.gameScore = score;
    }

    void Update()
    {
        Globals.gameScore = score;
        if (Input.GetKeyDown(KeyCode.D))
        {
            characterAnimator.Play("Jump"); 
        }
        if(transform.position.y < (-5))
        {
            Globals.paused = true;
            respawnx = transform.position.x;
            Globals.lives--;
            if(Globals.lives > 0)
            {
                respawnCharacter();
            }
            else
            {
                Globals.gameScore = score;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over");
            }   
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Carrot")
        {
            score++;
            Destroy(other.gameObject);
        }
        /*
         if other equals enemy
         */
    }

    public void respawnCharacter()
    {
        this.transform.position = new Vector3(respawnx, 10f, 0f);
        StartCoroutine(ResumeGame(3));
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
