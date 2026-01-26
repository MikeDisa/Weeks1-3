using System.Threading;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    //storage of the scaled size and original size
    Vector2 Size1 = new Vector2(1,1);
    Vector2 Size2 = new Vector2(1.25f,1.25f);

    //keeps track of if the object is at it's biggest
    bool peak = false;
    
    //activates smoothing curve
    public AnimationCurve curve;

    //hooks up to the global timer and manages animation speed
    public WorldTimer timer;
    public float speed = 0.25f;
    float t = 0f;

    //I needed to store the cue longer than it was staying for
    int localCue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer.cue); left over from a debug session
        if (timer.cue == 1)
        {   //stores the cue signal locally so that the loop finishes
            localCue = 1;
        }

        if (localCue == 1)
        {
            //keeps the Lerp running over time modified by an animation curve
            t += Time.deltaTime / Mathf.Max(0.0001f, speed);
            //found a cool unity thing that acts like Map() to keep a value within a range
            float easedT = curve.Evaluate(Mathf.Clamp01(t));
           
            //runs until it reaches it's largest size
            if (!peak)
            {
                transform.localScale = Vector2.Lerp(Size1 , Size2, easedT);
            }
            //runs after it reaches biggest size
            if (peak)
            {
                transform.localScale = Vector2.Lerp(Size2 , Size1, easedT);
            }
            
            //uses logic to see if it has reached it's peak and resets the animation timer
            if (transform.localScale.x >= Size2.x && !peak)
            {
                t = 0f;
                peak = true;
            }
            //uses logic to see if it has returned to it's original size resets the loop
            if (transform.localScale.x <= Size1.x && peak)
            {
                t = 0f;
                peak = false;
                localCue = 0;
            }

               
        }
    }
}
