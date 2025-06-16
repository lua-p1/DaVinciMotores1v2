using UnityEngine;
public abstract class PowerUps : MonoBehaviour
{
    protected Player playerRef;
    protected float buff;
    protected float notBuff;
    protected float buffTime;
    protected virtual void Start()
    {
        playerRef = GameManager.instance.player;
        buffTime = 3f;
    }
    protected virtual void Update()
    {
        ActivateBuff();
    }
    protected abstract void ActivateBuff();
}
