using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    public GameObject plyer;
    public MoveTest moveTest;
    private Vector3 myDir;
    private void Start()
    {
        
        Destroy(gameObject,5f); //5초후 삭제...

        myDir = moveTest.moveDir .normalized;

        //if (moveTest.moveDir.x > 0)
        //{
        //    myDir = new Vector3(1, 0, 0);
        //}
        //else if (moveTest.moveDir.x < 0)
        //{
        //    myDir = new Vector3(-1, 0, 0);
        //}
        //else if (moveTest.moveDir.y > 0)
        //{
        //    myDir = new Vector3(0, 1, 0);
        //}
        //else if (moveTest.moveDir.y < 0)
        //{
        //    myDir = new Vector3(0, -1, 0);
        //}
    }

    void Update()
    {
        //transform.Translate(Vector3.right * speed *  Time.deltaTime);
        //if (moveTest.moveDir.x > 0)
        //{
        //    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        //}
        //else if (moveTest.moveDir.x < 0)
        //{
        //    transform.position += new Vector3(-(speed * Time.deltaTime), 0, 0);
        //}
        //else if (moveTest.moveDir.y > 0)
        //{
        //    transform.position += new Vector3(0, (speed * Time.deltaTime), 0);
        //}
        //else if (moveTest.moveDir.y < 0)
        //{
        //    transform.position += new Vector3(0, -(speed * Time.deltaTime), 0);
        //}
        transform.Translate(myDir * speed * Time.deltaTime);
        //if(transform.position.x > 20)
        //{
        //    Destroy(gameObject); // 오브젝트 삭제
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        Destroy(gameObject); // 내 오브젝트(총알) 삭제
        Destroy(other.gameObject); //부딛힌 게임 오브젝트(몬스터) 삭제
    }
}
