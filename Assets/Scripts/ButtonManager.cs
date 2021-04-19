using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : SingleToneMaker<ButtonManager>
{
    private int DieCount = 10;
    public GameObject GameOverButton;

    public GameObject RetryButton;
    public GameObject RetryCount;
    public Text RetryCountUI;

    public GameObject RestartButton;

    IEnumerator ShowDieCorutine;
    PlayerState mPlayerState;

    void Start()
    {
        mPlayerState = GameObject.Find("Player").GetComponent<PlayerState>();
        GameOverButton.SetActive(false);
    }

    void Update()
    {
        
    }

    IEnumerator ShowDie()
    {
        int count = 0;
        while (count <= DieCount)
        {
            RetryCountUI.text = ""+(DieCount - count);
            RetryCount.SetActive(true);
            yield return new WaitForSeconds(1f);
            RetryCount.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        RetryButton.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOverButton.SetActiveRecursively(true);
        ShowDieCorutine = ShowDie();
        StartCoroutine(ShowDieCorutine);
    }

    public void OnClickRetryButton()
    {
        GameOverButton.SetActive(false);
        mPlayerState.PlayerSetActive(true);
        StopCoroutine(ShowDieCorutine);
        BulletManager.Instance.PlayerReset();
    }

    public void OnClickRestartButton()
    {
        GameOverButton.SetActive(false);
        mPlayerState.PlayerSetActive(true);
        StopAllCoroutines();
        mPlayerState.PlayerReset();
    }
}
