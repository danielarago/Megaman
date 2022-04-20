using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    int bulletSpeed = -4;
    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(bulletSpeed, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
