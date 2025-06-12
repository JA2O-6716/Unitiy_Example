using UnityEngine;

public class Spawner : MonoBehaviour
{
    //적을 스폰하도록 할 예정

    public float interval = 3f; //소환 주기

    public float lastSpawnTime; // 마지막 소환 시간


    public GameObject[] enemyPrefabs;

    private void Update()
    {
        if (Time.time > lastSpawnTime + interval)
        {
            //유니티의 랜덤 클래스

            Vector3 spawnPosition = Random.insideUnitCircle * 5; //반지름이 5이고 중심이 0,0인 원 안의 포지션 랜덤생성 (중심은 무조건 0,0)

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            //한번 소환 하고 
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //마지막 소환 시간을 갱신
            lastSpawnTime = Time.time;
        }
    }
}

