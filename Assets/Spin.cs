using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinRate;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, spinRate));
    }
}