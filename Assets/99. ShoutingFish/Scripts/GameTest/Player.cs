using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 moveDir;
    public float dashDir;
    
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRenderer;

    public float hp = 100;

    void IsDead()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false); //죽음
        }
    }

    private void Start()
    {
        dashDir = 50 * Time.deltaTime;
    }

    private void Update()
    {
        IsDead();
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스가 스크린 위에서 어디 위치있는지 월드좌표를 반환하는 함수
            //유니티에서는 게임 오브젝트를 "복제"하여 내놓는 함수를 사용함.
            //방향 벡터를 활용할때 , 힘의 크기가 필요없다면 백터 길이를 1로 고정
            Vector3 fireDir =mousePos - transform.position;
            fireDir.z = 0;
            Fire(fireDir.normalized);
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

    void Fire(Vector3 fireDir)
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.myDir = fireDir;
    }

    void OnCollisionStay2D(Collision2D c)
    {
        
        Collider2D other = c.collider;
        Debug.Log(other.name);
        if (other.CompareTag("Enemy"))
        {
            hp--;
            CurrentAlpha(1f / 255f);
        }
    }

    void CurrentAlpha(float Damage)
    {
        Color c = spriteRenderer.color;
        c.a -= Damage;
        spriteRenderer.color = c;
    }
}
