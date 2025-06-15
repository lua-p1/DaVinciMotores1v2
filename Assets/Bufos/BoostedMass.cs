public class BoostedMass : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 50;
        notBuff = 1;
    }
    protected override void ActivateBuff()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    DelegatesManager.instance.TriggerAction(ACTIONENUM.PLAYERMASS, 50, 1, 5);
        //}
    }
}
