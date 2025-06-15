using System.Collections;
using UnityEngine;
public class BoostedJump : PowerUps
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(FindJumpInit());
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerJump, buff, notBuff, buffTime);
        }
    }
    private IEnumerator FindJumpInit()
    {
        yield return new WaitForEndOfFrame();
        buff = 10f;
        notBuff = playerRef.GetInitJump;
        buffTime = 3f;
    }
}
