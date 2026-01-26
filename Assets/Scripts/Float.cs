using UnityEngine;

public class Float : MonoBehaviour
{
    //lets me plug in a sprite for it to stick to
    public Transform anchor;

    //holds the value of the top of the screen in world units
    float top;

    //Lerp positions activated to turn it into an arc and not straight line
    public Vector2 firstPosition = new Vector2(0, 0);
    public Vector2 secondPosition = new Vector2(0, 1);
    //music notes always end at the top of the screen
    public Vector2 thirdPosition = new Vector2(0, Screen.height);

    //activate inspector managed speed and animation curve
    public float speed = 0.25f;
    public AnimationCurve ease;

    //t for use with the Lerp and an insert for the global timer
    public float t = 0;
    public WorldTimer timer;

    //manages each stage and the activation of the note arc
    bool playing = false;
    int leg = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Needed to add this to fix a bug where stuff would snap to middle. makes sure that sprites have their anchor sprite from frame 1
            firstPosition = anchor.position;
            secondPosition = firstPosition;
            thirdPosition = firstPosition;
            transform.position = firstPosition;
        
        //making sure it knows where the top of the screen is in world units
        top = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
    }

    // Update is called once per frame
    void Update()
    {
        //logic to stop double triggering and triggering when called by the global timer
        //also refreshes each time a new loop starts to clean everything up
        if (!playing && timer.cue == 1)
        {
            //timer.cue = 0; Moved to a different script so it only plays once
            
            //variables to manage where in the path it is and if it's doing something
            playing = true;
            leg = 0;
            t = 0f;

            //note will always start behind it's respective 
            firstPosition = anchor.position;
            
            //sets up all 3 postions and brings music note back to behind the instrument
            secondPosition = firstPosition + new Vector2(2,3);

            thirdPosition = new Vector2(firstPosition.x, top);

            transform.position = firstPosition;
        }
        //local timer that adjusts speed in line with a animation curve
        t += Time.deltaTime / Mathf.Max(0.0001f, speed);
        //found a cool unity thing that acts like Map() to keep a value within a range
        float easedT = ease.Evaluate(Mathf.Clamp01(t));

        //The actual part of the show that moves the music notes up
        if (leg == 0)
        {
            transform.position = Vector2.Lerp(firstPosition, secondPosition, easedT);

            //runs when note hits the middle position to advance the loop
            if (t >= 1f)
            {
                t = 0f;
                leg = 1;
            }
        }
        else 
        {
            transform.position = Vector2.Lerp(secondPosition, thirdPosition, easedT);

            //runs when the loop finishes
            if (t >= 1f)
            {
                Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

                //loops the music note back to 0 if it leaves the screen
                if (screenPos.y >= top)
                {
                    transform.position = firstPosition;
                    playing = false;
                }
            }
        }
    }
}
