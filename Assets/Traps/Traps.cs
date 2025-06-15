using UnityEngine;
public abstract class Traps : MonoBehaviour
{
    protected Life _life;
    protected int _damage;
    protected virtual void Start()
    {
        _life = GameManager.instance.player?.GetLife;
    }
    protected abstract void Action();
}
