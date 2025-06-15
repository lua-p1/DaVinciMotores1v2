using System.Collections;
using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life _life;
    public int restoreLife;
    private void Start()
    {
        StartCoroutine(FindLife());
    }
    public void InteractAction()
    {
        if (_life == null) return;
        _life.RestoreLife(restoreLife);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            InteractAction();
        }
    }
    private IEnumerator FindLife()
    {
        yield return new WaitForEndOfFrame();
        _life = GameManager.instance.player.GetLife;
    }
}
