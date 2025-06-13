using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    public Vector2 offset = new Vector2(2f, 0f); // 기본 오프셋 (이동 방향에 따라 반전될 수 있음)

    private Vector3 velocity = Vector3.zero;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        Vector3 movementDir = player.position - lastPlayerPosition;

        // 이동 방향에 따라 offset.x 부호 바꾸기
        float directionX = movementDir.x > 0.01f ? 1 : movementDir.x < -0.01f ? -1 : 0;
        Vector2 dynamicOffset = new Vector2(offset.x * directionX, offset.y);

        // 목표 위치 계산
        Vector3 targetPosition = new Vector3(
            player.position.x + dynamicOffset.x,
            player.position.y + dynamicOffset.y,
            transform.position.z
        );

        // 부드럽게 따라감
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        lastPlayerPosition = player.position;
    }
}
