using UnityEngine;

public class RelativeTansformTest : MonoBehaviour
{
    public Transform cube;
    public Transform sphere;

    private MeshRenderer origin;

    void Awake()
    {
        origin = sphere.GetComponent<MeshRenderer>();
    }

    private Transform clone1;
    private Transform clone2;
    private Transform clone3;
    private Transform clone4;
    private Transform clone5;
    private Transform clone6;

    void Start()
    {
        MeshRenderer clone1 =Instantiate(origin);
        clone1.material.color = Color.red;
        this.clone1 = clone1.transform; 
        
        MeshRenderer clone2 = Instantiate(origin);
        clone2.material.color = new Color(1, 0.5f , 0);
        this.clone2 = clone2.transform;

        MeshRenderer clone3 = Instantiate(origin);
        clone3.material.color = Color.yellow;
        this.clone3 = clone3.transform;

        MeshRenderer clone4 = Instantiate(origin);
        clone4.material.color = Color.blue;
        this.clone4 = clone4.transform;

        MeshRenderer clone5 = Instantiate(origin);
        clone5.material.color = Color.cyan;
        this.clone5 = clone5.transform;

        MeshRenderer clone6 = Instantiate(origin);
        clone6.material.color = Color.green;
        this.clone6 = clone6.transform;
    }

    void Update()
    {
        //cube의 local상태에서 x축으로 2만큼 움직인 위치의 월드좌표를 얻고싶다.
        //Transform.TransformPoint : 기준 트랜스폼의 로컬 상태에서 2만큼 움직인 월드좌표를 반환
        clone1.position = cube.TransformPoint(2, 0, 0);

        //cube의 위치에 상관 없이, cube로부터 x축으로 2만큼 움직이는 백터를 월드좌표 기준으로 반환
        //Transform.TransformVector : 기준 트랜스폼의 위치(position)값을 무시 
        clone2.position = cube.TransformVector(2, 0, 0); // + cube.position 기존 값 더해줘야함

        //cube의 Scale에 상관없이 cube로부터 x축에서 2만큼 움직이는 벡터를 월드좌표 기준으로 반환
        //Transform.TransformDirection : TransformVector 대비 스케일(Scale)값을 무시
        clone3.position = cube.TransformDirection(2, 0, 0); // + cube.position 기존 값 더해줘야함

        //cube.InverseTransformPoint();
        //cube.InverseTransformVector();
        //cube.InverseTransformDirection();
        clone4.position = cube.InverseTransformPoint(sphere.position);
        clone5.position = cube.InverseTransformVector(sphere.position);
        clone6.position = cube.InverseTransformDirection(sphere.position);
    }
}
