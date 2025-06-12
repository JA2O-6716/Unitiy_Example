using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed= 2f; // 적들이 기본 움직임 속도
    float turnInterVal =1f ; // 적들이 방향을 바꿀 주기
    private Vector2 moveDir; //적들이 움직일 방향
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        turnInterVal = 1;
    }

    private float lastTurnTime; //마지막으로 바꿀 시간

    void Update()
    {
        if (Time.time > lastTurnTime + turnInterVal)
        {
            moveDir = Random.insideUnitCircle;
            lastTurnTime = Time.time;
            rigid.linearVelocity = moveDir * moveSpeed; //직선 운동 속도 운동량 프로퍼티 linearVelocity
        }

        //rigidibody가 붙어있으르모 TransForm 자체를 제어하는것 보단 Rigidibody에 의존하는게 좋다.
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
