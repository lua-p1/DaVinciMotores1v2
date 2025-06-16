using System.Collections;
using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life _lifeRef;
    [SerializeField]private float _restoreLife;
    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }
    public void InteractAction()
    {
        if (_lifeRef == null) return;
        if (_lifeRef.GetLife >= 100f)
        {
            Debug.Log("Ya tenes el maximo de vida");
            return;
        }
        _lifeRef.RestoreLife(_restoreLife);
        Destroy(gameObject);
    }
    private IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        _lifeRef = GameManager.instance.player?.GetLife;
    }
}
