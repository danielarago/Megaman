using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int life;
    float radius = 5f;
    AIPath myPath;
    Animator myAnim;
    [SerializeField] AudioClip deathSound;
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        if (life == 0)
        {
            myAnim.SetBool("isDead", true);
        }
    }

    public void Death()
    {
        myAudio.PlayOneShot(deathSound);
        Destroy(gameObject, deathSound.length);
    }

    void ChasePlayer()
    {

        Collider2D detectPlayer = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));

        if (detectPlayer != null)
        {
            myPath.isStopped = false;
        } else
        {
            myPath.isStopped = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag("Bullet"))
        {
            life--;
        }
    }
}
