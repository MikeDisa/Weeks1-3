using UnityEngine;

public class Float : MonoBehaviour
{
    //lets me plug in a sprite for it to stick to
    public Transform anchor;
    //gets the value of the top of the screen in world units
    float top;

    public Vector2 firstPosition = new Vector2(0, 0);
    public Vector2 secondPosition = new Vector2(0, 1);
    public Vector2 thirdPosition = new Vector2(0, Screen.height);

    public float speed = 0.25f;
    public AnimationCurve ease;

    public float t = 0;
    public WorldTimer timer;

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
        if (!playing && timer.cue == 1)
        {
            timer.cue = 0;
            playing = true;
            leg = 0;
            t = 0f;

            firstPosition = anchor ? (Vector2)anchor.position : (Vector2)transform.position;

            secondPosition = firstPosition + new Vector2(2,3);

            thirdPosition = new Vector2(firstPosition.x, top);

            transform.position = firstPosition;
        }

        t += Time.deltaTime / Mathf.Max(0.0001f, speed);
        float easedT = ease.Evaluate(Mathf.Clamp01(t));

        if (leg == 0)
        {
            transform.position = Vector2.Lerp(firstPosition, secondPosition, easedT);

            if (t >= 1f)
            {
                t = 0f;
                leg = 1;
            }
        }
        else 
        {
            transform.position = Vector2.Lerp(secondPosition, thirdPosition, easedT);

            
            if (t >= 1f)
            {
                Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

                if (screenPos.y >= top)
                {
                    transform.position = firstPosition;
                    playing = false;
                }
            }
        }
    }
}
