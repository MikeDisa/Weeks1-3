using UnityEngine;

public class Bounce : MonoBehaviour
{
    float xspeed = 0.01f;
    float yspeed = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x += xspeed;
        newPos.y += yspeed;
        transform.position = newPos;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            xspeed = xspeed * -1;
            yspeed = yspeed * 1;
        }
        
        if (screenPos.y < 0 || screenPos.y > Screen.height)
        {
            yspeed = yspeed * -1;
            xspeed = xspeed * 1;
        }
    }
}
