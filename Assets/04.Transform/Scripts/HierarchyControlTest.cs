using UnityEngine;

public class HierarchyControlTest : MonoBehaviour
{
    //유니티에서 Transform은 월드상에서의 위치제어를 하기도 하지만
    //내 오브젝트를 자식으로 가지고 있는 부모 오브젝트로부터의 상대 좌표 또한 제어함.
    //이런 특징들이 유니티의 Transform은 Hierarchy상의 부모자식관계도 제어한다.

    public GameObject otherObject;                                   

    void Start()
    {
        print($"나 : {transform.name} ");
        //transform.Getchild(index) : 내 자식중 특정 인덱스에 있는 자식을 가져옴
        Transform child = transform.GetChild( 0 );
        print($"내 자식 : {child.name}");

        Transform grandChild = child.GetChild(0);
        print($"내 자식의 자식 : {grandChild.name}");

        Transform secondChild = transform.GetChild( 1 );
        print($"내 두번째 자식 : {secondChild.name}");

        //transform.Find("") : 내 자식중 특정 이름을 가진 자식을 사용

        Transform findMe = transform.Find("FindMe");
        print($"찾은 자식 : {findMe.name}, 그 자식의 인덱스 : {findMe.GetSiblingIndex()}");

        //내 부모를 다른 Transform으로 바꿈.
        //transform.parent = otherObject.transform;
        //transform.SetParent() : 기본적으로 직접 Property에 부모가 될 게임오브젝트의 transform을 대입하는것과 같지만,
        //transform.SetParent(otherObject.transform , false); //위치를 제종하는 기능이 오버로드를 통해 제공이 된다. // true : 이동안함. , false : 부모위치로 이동
        //child.SetParent(otherObject.transform, false);

        //Hierarchy 상 자식 순서도 제어가능. 첫번째로 설정.
        secondChild.SetAsFirstSibling();

        //Hierarchy 상 자식 순서도 제어가능. 마지막로 설정.
        findMe.SetAsLastSibling();

        child.SetSiblingIndex(4); //4번쨰로 설정
    }
}
