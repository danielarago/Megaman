using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.left, 3.2f, LayerMask.GetMask("Player"));
        
        if (ray.collider != null)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
