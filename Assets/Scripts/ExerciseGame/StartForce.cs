using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public float power = 500f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("BlueBall"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
			Destroy(collision.gameObject);
            Destroy(gameObject);
        }
		if (collision.gameObject.name.Contains("RedBall"))
		{
            GameObject.Find("GameManager").GetComponent<GameManager>().AddTime(-3);
			Destroy(collision.gameObject);
            Destroy(gameObject);
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * power);
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
