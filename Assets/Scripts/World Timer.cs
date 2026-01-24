using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    float timer = 0f;
    public float beat = 3f;

    public int cue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= beat)
        {
            cue = 1;
            timer -= beat;
        }
    }
}
