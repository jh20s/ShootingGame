using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    private int DieCount = 10;
    public static ButtonManager Instance = null;
    public GameObject GameOverButton;
    public GameObject RetryCount;
    public Text RetryCountUI;
    IEnumerator ShowDieCorutine;
    PlayerState mPlayerState;

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
        mPlayerState = GameObject.Find("Player").GetComponent<PlayerState>();
        GameOverButton.SetActive(false);
    }

    // Update is called once per frame
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
    }

    public void ShowGameOver()
    {
        GameOverButton.SetActive(true);
        ShowDieCorutine = ShowDie();
        StartCoroutine(ShowDieCorutine);
    }

    public void ClickRetryButton()
    {
        mPlayerState.PlayerSetActive(true);
        GameOverButton.SetActive(false);
        StopCoroutine(ShowDieCorutine);
    }
}
