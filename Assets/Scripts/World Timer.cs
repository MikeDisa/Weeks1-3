using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    //a management script that tells other scripts how often to trigger.
    //I actually planned this before we went over it in class

    
    float timer = 0f;
    //lets me change how often the animations play with one slider  
    public float beat = 1.5f;

    //feeds a 1 or 0 to other scripts to tell them when to trigger
    public int cue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //counts up in real time until it hits a set value where it cues an animation and then resets
        timer += Time.deltaTime;
        if (timer >= beat)
        {
            cue = 1;
            timer -= beat;
        }
    }
}
