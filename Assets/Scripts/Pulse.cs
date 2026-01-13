using UnityEngine;

public class Pulse : MonoBehaviour
{
    public AnimationCurve curve;
    public float t;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
        }

        float y = curve.Evaluate(t);
        transform.localScale = Vector3.one * curve.Evaluate(t);


    }
}
