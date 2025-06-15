using UnityEngine;

public class BoostedSpeed : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 50f;
        notBuff = 10f;
        buffTime = 3f;
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerSpeed, buff, notBuff, buffTime);
        }
    }
}
