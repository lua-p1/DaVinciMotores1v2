public class BoostedMass : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 15f;
        notBuff = 1f;
    }
    protected override void ActivateBuff()
    {
        DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerMass, buff, notBuff, buffTime);
    }
}
