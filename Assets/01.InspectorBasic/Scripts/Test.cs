using UnityEngine;

public class Test : MonoBehaviour
{
    //게임이 시작되고 1회 호출
    void Start()
    {
        //콘솔에 메세지 출력
        Debug.Log("Hello World");

        MyDataContainer myData = new MyDataContainer();

        myData.a = 1;
        myData.b = 2;

        Debug.Log($"myData.a : {myData.a} myData.b : { myData.b}");
    }

    // 매 프레임마다 한번씩 호출
    void Update()
    {

    }
}

public class MyDataContainer
{
    public int a;
    public int b;
}

