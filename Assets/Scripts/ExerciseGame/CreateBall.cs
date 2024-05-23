using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CreateBall : MonoBehaviour
{
    public GameObject ball;
    public float interval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", 1.0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Create()
    {
        Instantiate(ball).transform.position = new Vector2(Random.Range(-4.0f, 4.0f), 5.0f);
    }
}
