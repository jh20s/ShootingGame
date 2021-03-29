using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;

    private float currentTime;
    private float createTime = 1;
    private float minTime = 0.5f;
    private float maxTime = 1.5f;

    //Spawn point
    public Transform[] spawnPoints;

    //TO-DO 에너미 이름들 정리해서 get으로 반환하는 메서드 만들기.
    public string EnemyTag = "EnemyObject";
    public string Enemy1 = "Enemy1";
    public string Enemy2 = "Enemy2";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Enemy1) as GameObject, Enemy1, EnemyTag);
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Enemy2) as GameObject, Enemy2, EnemyTag);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject enemy = null;
            if (UnityEngine.Random.Range(0, 10) < 7)
            {
                enemy = ObjectPoolManager.Instance.EnableGameObject(Enemy1);
            }
            else
            {
                enemy = ObjectPoolManager.Instance.EnableGameObject(Enemy2);
            }

            if (enemy!= null)
            {
                int index = UnityEngine.Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
            }
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
