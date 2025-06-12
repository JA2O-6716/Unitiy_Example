using UnityEngine;

public class ObjectFindTest : MonoBehaviour
{
    //게임이 시작되기 전에 신에서 참조 할 수 있는 오브젝트는 인스펙터에 할당하여 참조할 수 있음
    public GameObject target;
    //근데, 오브젝트를 찾기는 해야하는데, public 이면 안됨. 이런 경우는?
    private GameObject privateTarget;
    private FindMe findTarget;
    private GameObject newTarget;
    private GameObject nameNewTarget;
    private GameObject componentAttachedTarget;

    void Start()
    {
        print(target.name);
        //privateTarget을 찾는 방법.
        //1.전체 신에서 찾는다.
        privateTarget = GameObject.Find("PrivateTarget");
        print(privateTarget.name);

        //씬의 오브젝트가 많을 수록 부하(오버헤드)가 크고,
        //같은 이름의 오브젝트가 여러개 있을 경우, 어떤 오브젝트인지 확신 할 수 없음.
        //이런 이유로 Start함수에서만 제한적으로 쓰임.
    
        //2.전체 신에서 특정 컴포넌트를 가지고 있는 객체를 찾는다.
        findTarget = FindAnyObjectByType<FindMe>(); //기존 findObjectOfType() 와 같은 동작 // 이건 컨포넌트만 찾는 기능
                                                    //(여러개일 경우 뭐가 올지 모름) 하지만 찾는게 빠름.
        findTarget = FindFirstObjectByType<FindMe>(); //Hirachy상 가장 위에 있는 오브젝트를 찾음.
        GameObject findGameObj = findTarget.GetComponent<FindMe>().gameObject; // .gameObject로 findMe를 가지고 있는 게임오브젝트를 찾음.
        print(findTarget.message);

        //3.아예 게임 오브젝트를 직접 생성하고 해당 객체의 참조를 유지한다.

        newTarget = new GameObject(); // component등 유니티의 오브젝트들은 기본적으로 new 키워드로 객체 생성을 막음(지원하지 않는다)

        //예외적으로 게임오브젝트는 new로 통한 객체 생성이 가능... 생성자에서 transform을 비롯한 필요한 컴포넌트를 붙인 객체를 생성함
        //(Hirachy에서 Create Empty를 한것과 같음.)

        nameNewTarget = new GameObject("Name Target"); //생성자 파라미터는 게임오브젝트의 이름...
        componentAttachedTarget = new GameObject("Component Attached GameObject" , typeof(FindMe)); // typeof(int)같은 컴포넌트로 부착 불가능 한 것은 불가능.
        
        //객체를 생성할떈 new GameObject 보다는 Instantiate를 쓰게될 것.
    }
}
