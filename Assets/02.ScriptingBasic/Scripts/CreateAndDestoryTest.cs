using UnityEngine;

public class CreateAndDestoryTest : MonoBehaviour
{
    public GameObject original;
    public FindMe originalComponent;

    //지울것들
    private GameObject clone;
    private GameObject childClone;
    private GameObject moveClone;
    private FindMe cloneComponent ;
    private void Start()
    {
        // original이랑 똑같이 생긴 객체를 생성하고 싶다.
        //GameObject clone = new GameObject("Clone Cube");
        //MeshFilter mf = clone.AddComponent<MeshFilter>();
        //MeshRenderer mr = clone.AddComponent<MeshRenderer>();
        //BoxCollider coll = clone.AddComponent<BoxCollider>();

        //mf.mesh = original.GetComponent<MeshFilter>().mesh;
        //mr.material = original.GetComponent<MeshRenderer>().material;
        //coll.size = original.GetComponent<BoxCollider>().size;
        //coll.center = original.GetComponent<BoxCollider>().center;
        //=======여기까지 뻘짓============

        //그냥 Instantiate 씁니다..
        clone = Instantiate(original);
        clone.name = "clone";
        //TransForm을 파라미터로 전달할 경우, 해당 파라미터의 자식으로 생성
        childClone = Instantiate(original, transform);
        childClone.name = "childClone";
        //Vector3와 Quaternion을 파라미터로 전달할 경우, 해당 위치와 각도로 가지고 생성
        moveClone = Instantiate(original, new Vector3(3, 2, 1), Quaternion.Euler(45,30,90));
        moveClone.name = "moveClone";
        //만약 original이 컴포넌트일 경우, 해당 컴포넌트가 붙어있는 gameObject와 같은 형태로 게임 오브젝트를 생성하고 
        //original과 같은 컴포넌트를 반환한다.

        cloneComponent = Instantiate<FindMe>(originalComponent);
        cloneComponent.message = "이것은 클론입니다.";
        cloneComponent.name = "cloneComponent";
        Invoke("DestroyClones", 3f);
    }

    private void DestroyClones()
    {
        //클론 4종을 파괴하자
        //게임 오브젝트를 없앨 경우
        Destroy(clone); //clone이라는 오브젝트가 파괴될 것인데, // 바로삭제 아니고 삭제할 객체라고 등록만 함.
        print($"{clone.name}을 파괴한다."); //널레퍼런스 떠야할거같은데?

        //Destory는 파라미터를 삭제돼야할 객체로 등록한다
        //해당프레임이 끝날때 삭제
        Destroy(childClone, 3f); //3초 후에 ChildClone삭제, 마찬가지로 해당프레임의 마지막에 일괄 삭제. 3초후 끝날 프레임에 삭제

        Destroy(cloneComponent.gameObject); //만약 파라미터가 gameobjet가 아니면 해당 오브젝트만 딱 삭제.
                                            //.gameobject로 겜오브젝트 접근해서 삭제해야함.. cloneComponent는 컴포넌트니까..
        //이 경우, cloneComponent가 cube(clone)에 부착된 FindMe 컴포넌트이므로, 해당 컴포넌트만 삭제.

        //이번 프레임이 아니라 즉시 파괴해야 할 경우가 가끔 있음.
        //예를들면 유니티에서 싱글톤패턴을 구현하면

        DestroyImmediate(moveClone);// 즉시 객체가 삭제되어 null이됨
        if (moveClone == null)
        {
            print("moveClone는 이제 없음.");
        }
    }

}
