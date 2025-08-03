using UnityEngine;
public class BoostedLife : PowerUps
{
    private bool _buff;
    private bool _notBuff;
    protected override void Start()
    {
        base.Start();
        _buff = false;
        _notBuff = true;
        buffTime = 10;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IBoostedLife>(out var entity))
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnumWoutFirm.Inmortal, _buff, _notBuff, buffTime);
            Destroy(gameObject);
        }
    }
}
