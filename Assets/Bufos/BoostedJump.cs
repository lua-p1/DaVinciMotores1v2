using UnityEngine;
public class BoostedJump : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = playerRef.GetInitJump * 1.5f;
        notBuff = playerRef.GetInitJump;
    }
    protected override void ActivateBuff()
    {
        DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerJump, buff, notBuff, buffTime);
    }
}
