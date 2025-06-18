public class BoostedMass : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 500f;
        notBuff = 1f;
        buffTime = 20f;
    }
    protected override void ActivateBuff()
    {
        DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerMass, buff, notBuff, buffTime);
    }
}
