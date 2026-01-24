using UnityEngine;
using UnityEngine.InputSystem;

public class Dancer: MonoBehaviour
{
    //vectors to save the flipped scale states
    Vector2 lookLeft = new Vector2(1, 1);
    Vector2 lookRight = new Vector2(-1, 1);


    public Vector2 startPosition = new Vector2(-6, 0);
    public Vector2 endPosition = new Vector2(6, 0);
    public float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        t = Mathf.InverseLerp(startPosition.x, endPosition.x, mousePos.x);
        transform.position = Vector2.Lerp(startPosition, endPosition, t);

        //conditional statements that make the dancers flip at the midpoint
        if (t >= 0.5)
        {
            transform.localScale = Vector2.Lerp(lookLeft, lookRight, t);
        }
        if (t <= 0.5)
        {
            transform.localScale = Vector2.Lerp(lookRight, lookLeft, t);
        }
    }
}
