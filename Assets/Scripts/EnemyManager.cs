using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager :  SingleToneMaker<EnemyManager>
{
    private float currentTime;
    private float createTime = 1;
    private float minTime = 0.5f;
    private float maxTime = 1.5f;

    //Spawn point
    public Transform[] spawnPoints;

    public enum EnemyType
    {
        Enemy1,
        Enemy2,
        Boss1
    }

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject boss1;

    private int hpNormal = 1;
    private float speedNormal = 5.0f;
    private int movingNormal = 10;
    public void enemyStateSet(int hp, float speed, int moving)
    {
        this.hpNormal = hp;
        this.speedNormal = speed;
        this.movingNormal = moving;
    }

    public void CreateBoss(int hp, int speed)
    {
        GameObject boss = ObjectPoolManager.Instance.EnableGameObject(boss1.name);
        boss.GetComponent<Enemy>().enemyStateSet(hp, speed, 0);
        boss.transform.position = spawnPoints[2].position;
        boss.SetActive(true);
    }



    void Awake()
    {
        enemy1 = Resources.Load(nameof(EnemyType.Enemy1)) as GameObject;
        enemy2 = Resources.Load(nameof(EnemyType.Enemy2)) as GameObject;
        boss1 = Resources.Load(nameof(EnemyType.Boss1)) as GameObject;

    }

    void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
        ObjectPoolManager.Instance.CreateDictTable(enemy1, 10, 5);
        ObjectPoolManager.Instance.CreateDictTable(enemy2, 10, 5);
        ObjectPoolManager.Instance.CreateDictTable(boss1, 2, 5);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject enemy = null;
            if (UnityEngine.Random.Range(0, 10) < 7)
            {
                enemy = ObjectPoolManager.Instance.EnableGameObject(enemy1.name);
            }
            else
            {
                enemy = ObjectPoolManager.Instance.EnableGameObject(enemy2.name);
            }

            if (enemy!= null)
            { 
                enemy.GetComponent<Enemy>().enemyStateSet(hpNormal, speedNormal, movingNormal);
                int index = UnityEngine.Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
            }
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
