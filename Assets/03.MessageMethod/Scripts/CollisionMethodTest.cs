using UnityEngine;

public class CollisionMethodTest : MonoBehaviour
{
    //물리적인 충돌 발생 시 호출되는 메세지 함수가 있음
    //OnCollisionXX 시리즈
    //이 메세지 함수들은 호출 주체가 Physice 관련이 있으므로, 반드시 오브젝트중 하나는 rigidbody가 붙어 있어야 함

    //1. OnCollisionEnter : 충돌이 났을때 호출

    void OnCollisionEnter(Collision c) // 충돌 상태의 정보가 담긴 객체(Collision ) 충돌된 오브젝트가오는게 아닌 충돌 정보가 들어온다.
    {
        Collider other = c.collider; // 충돌을 이르킨 대상 Collider 충돌 대상에 Collision 충돌 정보를 넣음.

        print($"충돌 발생 나 : {name}, 부딛힌 애 : {other.name}");
    }

    //2. OnCollisionExit : 충돌되던 콜라이더가 다시 충돌이 아니게 되면 호출

    void OnCollisionExit(Collision c)
    {
        Collider other = c.collider;
        print($"충돌 끝... 나 : {name}, 부딛힌 애 : {other.name}");
    }

    //3. OnCollisionStay : 충돌중일 때 프레임마다 호출

    void OnCollisionStay(Collision c)
    {
        Collider other = c.collider;
        print($"충돌 중~~~ 나 : {name}, 부딛힌 애 : {other.name}");
    }
}
