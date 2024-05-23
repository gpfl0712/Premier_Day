using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("RedBall"))
			GameObject.Find("GameManager").GetComponent<GameManager>().AddTime(-3);
        if (collision.gameObject.tag == "Ball")
            Destroy(collision.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
