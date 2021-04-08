using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    IEnumerator mPlayerInvincibility;


    public delegate void PlayerResetDelegate();
    public event PlayerResetDelegate PlayerResetEvent;

    public void PlayerResetEventSet(PlayerResetDelegate pr)
    {
        PlayerResetEvent += pr;
    }
    public void PlayerReset()
    {
        PlayerResetEvent.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (mPlayerInvincibility == null && other.gameObject.layer.Equals(11))
        {
            PlayerSetActive(false);
            ButtonManager.Instance.ShowGameOver();
        }
    }


    public void PlayerSetActive(bool state)
    {
        PlayerSetActive(state, Vector3.zero);
    }
    public void PlayerSetActive(bool state, Vector3 pos)
    {
        gameObject.SetActive(state);
        if (pos != null)
            gameObject.transform.position = pos;
        if (state)
            PlayerSetInvincibility(3);
    }



    private IEnumerator PlayerInvincibility(int InvincibilityCount)
    {
        yield return new WaitForSeconds(InvincibilityCount * 1f);
        mPlayerInvincibility = null;
    }

    public void PlayerSetInvincibility(int InvincibilityCount)
    {
        mPlayerInvincibility = PlayerInvincibility(InvincibilityCount);
        StartCoroutine(mPlayerInvincibility);
    }
}


