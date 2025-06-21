using UnityEngine;
public class BoostedMass : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = 500f;
        notBuff = 1f;
        buffTime = 20f;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IBoostedMass>(out var BoostedEntity))
        {
            BoostedEntity.StartMassBuff(buff, notBuff, buffTime);
            Destroy(gameObject);
        }
    }
}
