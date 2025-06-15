using UnityEngine;
public class BoostedSpeed : PowerUps
{
    protected override void Start()
    {
        base.Start();
        notBuff = playerRef.GetInitSpeed;
        buff = playerRef.GetInitSpeed * 5;
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerSpeed, buff, notBuff, buffTime);
        }
    }
}
