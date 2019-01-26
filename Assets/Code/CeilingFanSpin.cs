using UnityEngine;

public class CeilingFanSpin : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}