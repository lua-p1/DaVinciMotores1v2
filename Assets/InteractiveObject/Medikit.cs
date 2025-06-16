using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life _life;
    [SerializeField]private int _restoreLife;
    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }
    public void InteractAction()
    {
        Debug.Log("medikit");
        if (_life == null) return;
        _life.RestoreLife(_restoreLife);
        Destroy(gameObject);
    }
    private IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        _life = GameManager.instance.player?.GetLife;
    }
}
