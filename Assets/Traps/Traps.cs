using System.Collections;
using UnityEngine;
public abstract class Traps : MonoBehaviour
{
    protected Life _life;
    protected int _damage;
    protected virtual void Start()
    {
        StartCoroutine(FindLife());
    }
    protected virtual void Update()
    {
        if (_life != null)
        {
            Action();
        }
        if(GameManager.instance.player == null) _life = null;
    }
    protected abstract void Action();
    private IEnumerator FindLife()
    {
        yield return new WaitForEndOfFrame();
        _life = GameManager.instance.player.GetLife;
    }
}
