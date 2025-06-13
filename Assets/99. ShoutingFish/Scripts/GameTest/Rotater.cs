using UnityEngine;

public class Rotater : MonoBehaviour
{
    //한쪽 방향으로 계속 z축 회전하는 스크립트.
    [Tooltip("초당 회전 각도")]
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
    }

}
