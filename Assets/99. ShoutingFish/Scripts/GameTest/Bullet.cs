using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    public GameObject plyer;
    public Player moveTest;
    public Vector3 myDir;
    private void Start()
    {
        
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

    void Update()
    {
        
        transform.Translate(myDir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //부딛힌 물체가 Enemy컴포넌트를 가지고있을때만 파괴함.
        if (other.TryGetComponent<Enemy>(out Enemy enmy))
        {
            Destroy(enmy.gameObject); //부딛힌 게임 오브젝트(몬스터) 삭제
        }

        if(other.CompareTag("Boundary")) // 내가 상호작용한 콜라이더가 부착된 오브젝트의 태그가 "Boundary"라면
        {
            Destroy(gameObject); // 내 오브젝트(총알) 삭제
        }
    }
}
