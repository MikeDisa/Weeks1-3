using UnityEngine;

public class Float : MonoBehaviour
{
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

                if (screenPos.y > Screen.height)
                {
                    transform.position = firstPosition;
                    playing = false;
                }
            }
        }
    }
}
