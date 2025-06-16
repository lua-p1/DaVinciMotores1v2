using UnityEngine;
public class BoostedJump : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = playerRef.GetInitJump * 2.5f;
        notBuff = playerRef.GetInitJump;
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerJump, buff, notBuff, buffTime);
        }
    }
}
