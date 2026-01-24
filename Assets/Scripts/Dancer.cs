using UnityEngine;
using UnityEngine.InputSystem;

public class Dancer: MonoBehaviour
{
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
    }
}
