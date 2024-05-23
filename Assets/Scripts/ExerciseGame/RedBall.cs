using UnityEngine;

public class RedBall : MonoBehaviour
{
    public float speed = 300.0f;
	public Vector2 direction;

	// Start is called before the first frame update
	void Start()
	{
		float angle = Random.Range(-45.0f, -135.0f) * Mathf.Deg2Rad;
		direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		rb.AddForce(direction * speed);
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

}
