using UnityEngine;

public class Breathe : MonoBehaviour
{
    public float breathRate;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one + Vector3.one * Mathf.Abs(Mathf.Sin(Time.time * breathRate) * 0.1f);
    }
}
