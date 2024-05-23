using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public float power = 500f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * power);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >7)
            Destroy(gameObject);
    }
}
