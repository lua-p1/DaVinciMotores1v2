using UnityEngine;
public class BoostedSpeed : PowerUps
{
    protected override void Start()
    {
        base.Start();
        notBuff = playerRef.GetInitSpeed;
        buff = playerRef.GetInitSpeed * 1;
    }
    protected override void ActivateBuff()
    {
        DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerSpeed, buff, notBuff, buffTime);
    }
}
