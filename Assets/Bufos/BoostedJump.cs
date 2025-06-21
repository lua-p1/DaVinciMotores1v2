using UnityEngine;
public class BoostedJump : PowerUps
{
    protected override void Start()
    {
        base.Start();
        buff = playerRef.GetInitJump * 3f;
        notBuff = playerRef.GetInitJump;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IBoostedJump>(out var BoostedEntity))
        {
            BoostedEntity.StartJumpBuff(buff, notBuff, buffTime);
            Destroy(gameObject);
        }
    }
}
