using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float turnInterVal = 0.5f;
    float lastTurnTime = 0;
    public float speed = 5;
    float bulletDamage = 10;
    public GameObject plyer;
    //public Vector2 myDir;
    public Player PlayerStat;
    private void Start()
    {
        bulletDamage = 10;
        Destroy(gameObject,5f); //5초후 삭제...

        //if ((moveTest.moveDir.x == 0 && moveTest.moveDir.y == 0) && moveTest.spriteRenderer.flipX == false)
        //{
        //    myDir = new Vector3(1, 0, 0).normalized;
        //}
        //else if ((moveTest.moveDir.x == 0 && moveTest.moveDir.y == 0) && moveTest.spriteRenderer.flipX == true)
        //{
        //    myDir = new Vector3(-1, 0, 0).normalized;
        //}
    }

    void BulletMove()
    {
        float MaxTime =  2;
        float curTime = 0;
        if (curTime == 0.5f)
        {
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
            lastTurnTime = Time.time;
        }

        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
            transform.Translate(-(transform.up) * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime , Space.World);
        //transform.Translate(myDir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //부딛힌 물체가 Enemy컴포넌트를 가지고있을때만 파괴함.
        if (other.TryGetComponent<Enemy>(out Enemy enmy))
        {
            enmy.hp -= bulletDamage; // damage
            Color c = enmy.spriteRenderer.color;
            c.a -= bulletDamage * 2/ 255f;
            enmy.spriteRenderer.color = c;
            Debug.Log("enemy의 체력 : " + enmy.hp);
            Destroy(gameObject);
            if (enmy.hp <= 0)
            {
                Destroy(enmy.gameObject);//부딛힌 게임 오브젝트(몬스터) 삭제
                PlayerStat.exp += 1;
            }
        }

        if(other.CompareTag("Boundary")) // 내가 상호작용한 콜라이더가 부착된 오브젝트의 태그가 "Boundary"라면
        {
            Destroy(gameObject); // 내 오브젝트(총알) 삭제
        }

    }
}
