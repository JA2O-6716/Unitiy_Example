using UnityEngine;

public class LiterlVariableTest : MonoBehaviour
{
    const int MonsterHp = 100;

    //정수
    public byte byteVar = byte.MaxValue;
    public sbyte sbyteBar;
    public short shortVar;
    public ushort ushortVar;
    public int intVar = 1;
    public uint uintVar = MonsterHp;
    public long longVar;
    public ulong ulongVar;

    //실수
    public float floatVar = 1.1f;
    public double doubleVar = 1.4;
    public decimal decimalVar; // decimal 데이터타입은 유니티 인스펙터창에서 데이터 입력 지원 안함.

    //그 외
    public bool boolVar;
    public char charVar;
    public string stringVar;

    void Start()
    {
        Debug.Log(intVar);
    }

    private void Reset() //유니티 인스펙터창 리셋 버튼 눌렀을때 호출.
    {
        Debug.Log("LiterlVariableTest의 Reset 호출됨.");
        floatVar = 1.3f;
    }
}
