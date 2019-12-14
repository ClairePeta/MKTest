using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    Animator characterAnimator;
    public enum Animation { Walk, Run, Jump, Hit, None }
    public float jumpSpeed = 6f;
    bool jump = false;
    int score = 0;


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

    public void StartAnimation(Animation animation, float speed = 1)
    {
        switch (animation)
        {
            case Animation.Walk:
                characterAnimator.SetBool("isWalking", true);
                break;
            case Animation.Run:
                characterAnimator.SetBool("isRunning", true);
                break;
            case Animation.Jump:
                characterAnimator.SetTrigger("Jump");
                break;
            case Animation.Hit:
                characterAnimator.SetTrigger("Hit");
                break;
            default:
                break;
        }
    }

    public void StopAnimation(Animation animation)
    {
        switch (animation)
        {
            case Animation.Walk:
                characterAnimator.SetBool("isWalking", false);
                break;
            case Animation.Run:
                characterAnimator.SetBool("isRunning", false);
                break;
        }
    }


    public void respawnCharacter()
    {

           /* if (ClientLink.Lives > 0)
            {
                this.transform.position = new Vector3(respawnPosition.VisualPosition.x, 0.5f, respawnPosition.VisualPosition.z);
                this.respawnNeeded = false;
                this._currentBlock = respawnPosition;
                respawnPosition.CurrentPlayer = this;
                this.stuck = false;
            }
            else
            {
                this.transform.position = new Vector3(-50, 0.5f, 0);
                this.respawnNeeded = false;
                this._currentBlock = respawnPosition;
                respawnPosition.CurrentPlayer = this;
                this.stuck = false;
            }*/

    }
}
