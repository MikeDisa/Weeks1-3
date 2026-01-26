using UnityEngine;
using UnityEngine.InputSystem;

public class Dancer: MonoBehaviour
{
    //vectors to save the flipped scale states
    Vector2 lookLeft = new Vector2(-1, 1);
    Vector2 lookRight = new Vector2(1, 1);

    //uses a Lerp to constrain the mouse x between 2 points
    public Vector2 startPosition = new Vector2(-6, -1.5f);
    public Vector2 endPosition = new Vector2(6, -1.5f);
    public float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //it was prioritizing the inspector value so I just hard coded the height in twice
        startPosition.y = -1.5f;

        endPosition.y = -1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //used the Lerp to convert mouse position to a value between 0 and 1
        t = Mathf.InverseLerp(startPosition.x, endPosition.x, mousePos.x);
        //moves between 2 points following the mouse
        //did I over think this?
        transform.position = Vector2.Lerp(startPosition, endPosition, t);

        //makes the dancers flip when passing midpoint
        transform.localScale = Vector2.Lerp(lookLeft, lookRight, t);
        
        //This didn't work because I was overthinking it. here it is anyways
            //conditional statements that make the dancers flip at the midpoint
        //if (t >= 0.5)
        //{
        //transform.localScale = Vector2.Lerp(lookLeft, lookRight, t);
        //}
        //else
        //{
        // transform.localScale = Vector2.Lerp(lookRight, lookLeft, t);

        //}



    }
}
