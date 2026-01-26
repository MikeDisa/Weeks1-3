using System.Threading;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    //storage of the scaled size and original size
    Vector2 Size1 = new Vector2(1,1);
    Vector2 Size2 = new Vector2(1.25f,1.25f);

    bool peak = false;
    
    public AnimationCurve curve;

    public WorldTimer timer;
    public float speed = 0.25f;
    float t = 0f;
    int localCue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer.cue);
        if (timer.cue == 1)
        {
            localCue = 1;
        }

        if (localCue == 1)
        {
            t += Time.deltaTime / Mathf.Max(0.0001f, speed);
            float easedT = curve.Evaluate(Mathf.Clamp01(t));
           
            if (!peak)
            {
                transform.localScale = Vector2.Lerp(Size1 , Size2, easedT);
            }
            if (peak)
            {
                transform.localScale = Vector2.Lerp(Size2 , Size1, easedT);
            }
            
            if (transform.localScale.x >= Size2.x && !peak)
            {
                t = 0f;
                peak = true;
            }
            if (transform.localScale.x <= Size1.x && peak)
            {
                t = 0f;
                peak = false;
                localCue = 0;
            }

               
        }
    }
}
