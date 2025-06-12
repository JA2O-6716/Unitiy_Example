using System;
using UnityEngine;

[Serializable] //C# 어트리뷰트(Attribute) : 코드를 구성하는 특정 요소 ( 클래스 , 필드 , 함수) 에 대한 메타데이터 정의
               //이 뒤에 오는 클래스는 직렬화 기능을 부여한다는 의미
public class MyClass // Serializable
{
    public string name;
    public int id;
    public Sprite sprite;
}
public class ReferenceVariableTest : MonoBehaviour
{
    public MyClass myClass; // 개발자가 직접만든 참조형태 데이터는 어떻게 인스펙터창에서 수정 할 수 있을까
                            // 직렬화가 필요함.

    void Start()
    {
        print(myClass.name);
        print(myClass.id);
        print(myClass.sprite.rect);
    }

}
