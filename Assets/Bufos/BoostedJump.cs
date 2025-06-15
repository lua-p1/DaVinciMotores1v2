using System.Collections;
using UnityEngine;
public class BoostedJump : PowerUps
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(FindInitJump());
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerJump, buff, notBuff, buffTime);
        }
    }
    private IEnumerator FindInitJump()
    {
        yield return new WaitForEndOfFrame();
        buff = playerRef.GetInitJump * 2.5f;
        notBuff = playerRef.GetInitJump;
    }
}
