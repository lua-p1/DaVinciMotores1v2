using System.Collections;
using UnityEngine;
public abstract class Traps : MonoBehaviour
{
    protected Life _life;
    protected int _damage;
    protected virtual void Start()
    {
        StartCoroutine(WaitForPlayer());
    }
    protected abstract void Action();
    private IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        _life = GameManager.instance.player?.GetLife;
    }
}

