using UnityEngine;

public class TimeScaleTest : MonoBehaviour
{
    [Range(0.001f, 10)]
    public float timeScale;

    void Update()
    {
        Time.timeScale = timeScale;
    }
}
