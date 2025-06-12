using UnityEngine;

public class UnitiyAttributeTest : MonoBehaviour
{
    //유니티 에서는 Inspector에서 편집 편의를 위해 다양한 어트리뷰트를 제공한다.

    public int publicIntVar;

    //1. SerializeField : 일반적으로 인스텍터에서 가려져야하는 private 또는 protected 필드를
    //Inspector에서 접근 가능하도록 하는 기능
    [SerializeField]
    private int privateIntVar;

    //2. TextArea : Inspector에서 문자열 입력란을 한줄이 아니라 여러줄로 입력 가능하도록 표시함.
    [TextArea(2,10)] //최소2줄 ~ 10줄까지
    public string text;

    //여기서부터는 옵션사항이라고 기획자나 유니티 에디터 작업자에게 알려주고 싶다.
    //Header : Inspector 중간에 특정 문구를 라벨처럼 끼어넣음
    [Header("여기서부터 옵션")]
    public int otherIntVar;

    //4. Space : Inspector에서 입력칸 사이에 간격을 띄움
    [Space(30)]
    public float floatVar;

    //5. Range : int또는 float 변수의 최대/최소값을 제한하고, 슬라이더바로 값을 변경 할 수 있도록 해줌.
    [Range(-5,5)]
    public int rangedInt;
    [Range(0, 1)]
    public float rangedFloat;

    //6. Tooltip : Inspector에서 해당 변수에 마우스를 올리면 툴팁을 표시
    [Tooltip("이것은 툴팁 입니다.")]
    public string otherText;

    //7 HideInInspector : SerializeField와 반대로, public 변수를 인스펙터에서 숨김
    [HideInInspector]
    public int notSupportedIntVar;

    //인스펙터에서는 가리고, 스크립트에서는 접근 가능하도록 하기위해서 internal 접근 지정자 사용
    internal int internalIntVar;
    //또는 public 프로퍼티로 하는 것이 가장 적합함.
    public int IntProperty { get; set; }
}
