using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    float radius = 5f;
    AIPath myPath;

    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        /*float d = Vector2.Distance(transform.position, player.transform.position);
        if (d > 8)
        {

        }
        Debug.DrawRay(transform.position, player.transform.position, Color.blue);
        */

        Collider2D detectPlayer = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));

        if (detectPlayer != null)
        {
            Debug.Log("Jugador dentro de radio");
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
}
