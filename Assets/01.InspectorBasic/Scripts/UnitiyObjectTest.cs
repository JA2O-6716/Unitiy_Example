using UnityEngine;

public class UnitiyObjectTest : MonoBehaviour
{
    public GameObject testObject;
    public Transform cubeTransform;
    public MeshFilter cubeMeshFilter;
    public BoxCollider cubeBoxCollider;
    public object systemObject; // C# .net의 모든 클래스들의 부모
    public Object unitiyObject; // 유니티 모든 인스펙터에서 참조가능한 에셋과 컴포넌트의 부모


    void Start()
    {

    }
}

