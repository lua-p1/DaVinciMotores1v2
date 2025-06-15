using UnityEngine;

public class BoostedMass : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 50f;
        notBuff = 1f;
        buffTime = 3f;
    }
    protected override void ActivateBuff()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerMass, buff, notBuff, buffTime);
        }
    }
}
