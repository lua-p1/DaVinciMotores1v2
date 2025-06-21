using UnityEngine;
public class BoostedSpeed : PowerUps
{
    protected override void Start()
    {
        base.Start();
        notBuff = playerRef.GetInitSpeed;
        buff = playerRef.GetInitSpeed * 2;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IBoostedSpeed>(out var BoostedEntity))
        {
            BoostedEntity.StartSpeedBuff(buff, notBuff, buffTime);
            Destroy(gameObject);
        }
    }
}
