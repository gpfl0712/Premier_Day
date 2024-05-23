using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Sprite NORMAL;
    public Sprite ATTACK;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            gameObject.GetComponent<SpriteRenderer>().sprite = ATTACK;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = NORMAL;

    }
}
