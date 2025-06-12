using UnityEngine;

public class ComponentFindTest : MonoBehaviour
{
    //게임 오브젝트를 알고 있는 상태에서, 그 오브젝트에 부착된 특정 컴포넌트를 찾으려 할 경우.

    public GameObject target;
    public Sprite someSprite;    


    private void Start()
    {
        FindMe findMe = target.GetComponent<FindMe>();
        Debug.Log(findMe.message);

        bool isFinded = target.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer);

        if (isFinded)
        {
            Debug.Log("SpriteRenderer 컴포넌트 찾는데 성공");
            spriteRenderer.sprite = someSprite;
        }
        else
        {
            Debug.Log("SpriteRenderer 컴포넌트 찾는데 실패");
        }

        isFinded = target.TryGetComponent<Collider2D>(out Collider2D collider2D);

        if (isFinded)
        {
            print(collider2D.offset);
        }
        else
        {
            print("찾는 Collider2D 컴포넌트가 없습니다.");
        }

        //Hierarchy상 자식 오브젝트들에 붙어있는 컴포넌트들도 찾을 수 있다.
        FindMe[] children = target.GetComponentsInChildren<FindMe>( includeInactive : true); //자기 자신에게 부착된 컴포넌트도 포함한다. 
        //오버로드된 메소드 중 ,매개변수 includeInactive : true이면 비활성화 자식오브젝트의 컴포넌트도 포함한다. 기본값은 : false

        foreach (FindMe child in children)
        {
            print(child.message);
        }

        FindMe newFindMe = target.AddComponent<FindMe>();
        newFindMe.message = "새롭게 저를 찾아주셨군요!";

        print(newFindMe.message);
    }
}
