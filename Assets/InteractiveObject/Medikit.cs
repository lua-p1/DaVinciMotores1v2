using System.Collections;
using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life life;
    public int restoreLife;
    private void Start()
    {
        StartCoroutine(FindLife());
    }
    public void InteractAction()
    {
        if (life == null) return;
        life.RestoreLife(restoreLife);
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
        life = GameManager.instance.player.GetLife;
    }
}
