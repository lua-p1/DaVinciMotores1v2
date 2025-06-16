using System.Collections;
using UnityEngine;
public abstract class Traps : MonoBehaviour
{
    protected Life _lifeRef;
    protected float _damage;
    protected virtual void Start()
    {
        StartCoroutine(WaitForPlayer());
    }
    protected abstract void Action();
    private IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        _lifeRef = GameManager.instance.player?.GetLife;
    }
}

