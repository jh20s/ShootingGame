using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    IEnumerator mPlayerInvincibility;
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
        if (mPlayerInvincibility== null && other.gameObject.CompareTag(EnemyManager.EnemyTag))
        {
            PlayerSetActive(false);
            ButtonManager.Instance.ShowGameOver();
        }
    }


    private IEnumerator PlayerInvincibility(int InvincibilityCount)
    {
        yield return new WaitForSeconds(InvincibilityCount*1f);
        mPlayerInvincibility = null;
    }

    public void PlayerSetActive(bool state)
    {
        PlayerSetActive(state, Vector3.zero);
    }
    public void PlayerSetActive(bool state, Vector3 pos)
    {
        gameObject.SetActive(state);
        if(pos!=null)
            gameObject.transform.position = pos;
        if(state)
            PlayerSetInvincibility(3);
    }
    public void PlayerSetInvincibility(int InvincibilityCount)
    {
        mPlayerInvincibility = PlayerInvincibility(InvincibilityCount);
        StartCoroutine(mPlayerInvincibility);
    }

    public bool PlayerGetActiveState()
    {
        return gameObject.active;
    }
}
