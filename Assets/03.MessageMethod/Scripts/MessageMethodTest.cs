using UnityEngine;

public class MessageMethodTest : MonoBehaviour
{
    //메시지 함수
    //개발자가 호출 할 수 있지만 따로 호출 하지 않아도 유니티 게임 프로세스상 발생하는 이벤트에 따라 
    //유니티 엔진이 호출해주는 함수
    //접근지정자가 무엇이 되던 상관 없음(private이어도 호출되고 , public이면 다른 클래스에서 직접 호출도 가능)

    //1. Awake : 객체(어떤 경로 로든 생성)가 로드되자마자 호출.
    //Scene 로드시에 Awake 함수에서 다른 객체를 참조할 경우 아직 객체는 로드되지 않은 상태일 수 있어서
    //그러므로 Awake 에서는 내 게임오브젝트에 붙은 다른 컴포넌트에 대한 초기화를 진행하는 용도로 사용해야 한다.

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        //내 게임오브젝트에 붙은 spriteRenderer를 가져옴.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        print($"Awake 호출, 호출시간 : {Time.time}");
    }

    //2. Start : Updata가 호출되기 직전 한번 호출
    void Start()
    {
        print($"Start 호출, 호출시간 : {Time.time}");
    }

    //3. Updata : 게임이 시작된 후  , 매 프레임마다 한번씩 호출
    //int frameCount = 0;
    void Update()
    {
        //print($"Updata 호출, 호출횟수 : {frameCount++}");
    }

    //4 OnEnable / OnDisable : 이 컴포넌트나 게임 오브젝트가 활성화 / 비활성화 될 시 호출.
    //주의 : OnEnable은 게임오브젝트 로드가 완료된 후에 호출 되므로, 첫 1회는 Start보다 먼저 호출.

    void OnEnable()
    {
        print("OnEnable 호출");
    }

    void OnDisable()
    {
        print("OnDisable 호출");
    }

    //5. OnDestory : 게임 오브젝트 또는 컴포넌트가 삭제될때 호출.
    //주의 : 따로 비활성화 하지 않더라도, 활성화 되어있던 오브젝트가 삭제될때는 OnDisable()이 먼저 호출됨
    void OnDestroy()
    {
        print($"{name} OnDestroy 호출");
    }
}
