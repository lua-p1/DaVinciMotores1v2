using System.Collections;
using UnityEngine;
public class BoostedSpeed : PowerUps
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(FindInitSpeed());
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerSpeed, buff, notBuff, buffTime);
        }
    }
    private IEnumerator FindInitSpeed()
    {
        yield return new WaitForEndOfFrame();
        notBuff = playerRef.GetInitSpeed;
        buff = playerRef.GetInitSpeed * 5;
    }
}
