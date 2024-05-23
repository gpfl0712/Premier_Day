using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicGame : MonoBehaviour
{
    public bool canBePressed;


    public KeyCode KeyToPress;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                MusicGameManager mg = GameObject.Find("MusicGameManager").GetComponent<MusicGameManager>();
                mg.NoteHit();

                mg.EndGame();

                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            MusicGameManager mg = GameObject.Find("MusicGameManager").GetComponent<MusicGameManager>();
            mg.NoteMissed();
            mg.EndGame();

        }
    }
}
