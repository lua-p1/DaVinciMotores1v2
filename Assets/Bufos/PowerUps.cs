using System.Collections;
using UnityEngine;
public abstract class PowerUps : MonoBehaviour
{
    protected Player playerRef;
    protected float buff;
    protected float notBuff;
    protected float buffTime;
    protected virtual void Start()
    {
        StartCoroutine(FindPlayer());
        buffTime = 3f;
    }
    protected virtual void Update()
    {
        ActivateBuff();
    }
    protected abstract void ActivateBuff();
    private IEnumerator FindPlayer()
    {
        yield return new WaitForEndOfFrame();
        playerRef = GameManager.instance.player;
    }
}
