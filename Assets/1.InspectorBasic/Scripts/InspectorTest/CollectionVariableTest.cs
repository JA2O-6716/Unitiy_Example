using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CollectionVariableTest : MonoBehaviour
{
    //유니티 인스펙터창에서 지원됨.
    public string[] array; //초기화 하지 않아도 유니티에서 새 객체를 주입
    public List<string> list;

    //유니티 인스펙터창에서는 지원안됨. 소스코드로 제어
    public LinkedList<string> linkedList; 
    public Queue<string> queue;
    public Stack<string> stack;
    public Dictionary<string, string> dictionary;

    void Start()
    {
        foreach (var item in array)
        {
            Debug.Log(item);
        }

        Debug.Log(array.Length);

        foreach (var item in list)
        {
            Debug.Log(item);
        }

        Debug.Log(list.Count);
    }
}
