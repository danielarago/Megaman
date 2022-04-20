using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myBody;
    Animator myAnim;
    bool IsGrounded = true;
    [SerializeField] float JumpForce;
    [SerializeField] GameObject bullet;
    [SerializeField] float FireRate;
    private float AllowFire;
    AudioSource myAudio;
    [SerializeField] AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(Corutina());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Ground"));
        IsGrounded = (ray.collider != null);

        Jump();
        Fire();
    }

    private void FixedUpdate()
    {
        float dirH = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(dirH * speed, myBody.velocity.y);

        if (dirH != 0)
        {
            myAnim.SetBool("isRunning", true);
            if (dirH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if (IsGrounded && !myAnim.GetBool("isJumping"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                myAnim.SetBool("isJumping", true);
            }
        }

        if (myBody.velocity.y != 0 && !IsGrounded)
        {
            myAnim.SetBool("isJumping", true);
        } else
        {
            myAnim.SetBool("isJumping", false);
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            myAnim.SetLayerWeight(1, 1);
            if (Time.time > AllowFire)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                AllowFire = Time.time + FireRate;
                myAudio.PlayOneShot(myAudio.clip);
            }
        } 
        else
        {
            myAnim.SetLayerWeight(1, 0);
        }
    }

    public void FinishingRun()
    {
        Debug.Log("Termina de correr :3");
    }

    IEnumerator Corutina()
    {
        while (true)
        {
            Debug.Log("Esperando 4 segundos");
            yield return new WaitForSeconds(4);
            Debug.Log("Pasaron 4 segundos");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over bestie");
            myAnim.SetBool("isDying", true);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        new WaitForSeconds(2);
        myAudio.PlayOneShot(deathSound);
        new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


}
