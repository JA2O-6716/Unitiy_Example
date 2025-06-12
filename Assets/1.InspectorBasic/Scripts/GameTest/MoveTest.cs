using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 moveDir;
    public float dashDir;

    public GameObject bulletPrefab;
    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        dashDir = 50 * Time.deltaTime;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            //유니티에서는 게임 오브젝트를 "복제"하여 내놓는 함수를 사용함.
            Bullet bullet = Instantiate(bulletPrefab, transform.position ,Quaternion.identity).GetComponent<Bullet>(); //새로운 오브젝트를 생성
            bullet.moveTest = this;
        }
        moveDir = new Vector3(x, y, 0);

        print("Update 호출됨.");
        Move(moveDir);
    }

    void Move(Vector3 moveDir)
    {
        if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDir.x < 0)
        {
            spriteRenderer.flipX=true;
        }
        else
        {

        }
        Vector3 currentPosition = transform.position;
        if (Input.GetButtonDown("Jump"))
        {
            print("스페이스 바 눌림");

            currentPosition.x += moveDir.x * dashDir; // Time.deltaTime : 매 프레임마다 이전 프레임과의 시간간격을 반환한다
            currentPosition.y += moveDir.y * dashDir;
            transform.position = currentPosition;
        }
        //transform //transform component는 모든 오브젝트가 가져 있기 때문에 게임오브젝트에 부착되어 있는 transform component를 바로 참조 할 수 있다.
        //transform.position = new Vector3(Time.deltaTime,0,0); //내 객체의 position을 정확히 월드좌표 1,0,0으로 이동 시킴

        //transform.position.x++ 불가능 //Transform.position이 프로퍼티이기 때문에 내부 필드인 x값을 바로 수정할 수 없음.
        transform.Translate(moveDir * moveSpeed * Time.deltaTime); // Translate 메서드 : 이동할 방향 백터를 파라미터로 받으면 현재 위치에서 해당위치로 이동.
        //currentPosition.x += moveDir.x * moveSpeed * Time.deltaTime; // Time.deltaTime : 매 프레임마다 이전 프레임과의 시간간격을 반환한다
        //currentPosition.y += moveDir.y * moveSpeed * Time.deltaTime;

    }
}
