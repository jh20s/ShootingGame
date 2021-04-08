using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : SingleToneMaker<StageManager>
{
    private float stageTime = 5f;
    public int stage = 1;

    public GameObject stageObect;
    public Text stageUI;
    private void Awake()
    {
        stageObect.SetActive(false);
        StartCoroutine(NextStageCoroutine());
        GameObject.Find("Player").GetComponent<PlayerState>().PlayerResetEventSet(PlayerReset);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextStageCoroutine()
    {
        while (true) {
            int hp = stage > 5 ? 5 : stage;
            float speed = stage * 2;
            int moving = stage * 2 > 20 ? 20 : stage * 2;
            EnemyManager.Instance.enemyStateSet(hp, speed, moving);
            yield return new WaitForSeconds(stageTime);
            
            //보스생성전략  startegy 패턴 메서드로 대체 필요 -> 전략관리 클래스 필요
            EnemyManager.Instance.CreateBoss(stage*5, 1);

            if (GameObject.Find("Player") == null)
            {
                yield return new WaitUntil(()=>GameObject.Find("Player")!=null);
            }

            yield return new WaitUntil(() => GameObject.Find(nameof(EnemyManager.EnemyType.Boss1)) == null);
            stage++;
            StartCoroutine(ShowStage());
            
            
            //startegy 패턴 메서드로 난이도 전략으로 대체 필요 -> 전략관리 클래스 필요
            
        }
    }


    IEnumerator ShowStage()
    {
        stageUI.text = "stage " + stage;
        int count = 0;
        while (count <= 3)
        {
            stageObect.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            stageObect.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }

    public void PlayerReset()
    {
        stage = 1;
        stageObect.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(NextStageCoroutine());
    }
}
