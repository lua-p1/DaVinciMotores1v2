using System.Collections;
using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life life;
    public int restoreLife;
    public void InteractAction()
    {
        if (life != null)
        {
            life.RestoreLife(restoreLife);
        }
    }
    private void Start()
    {
        StartCoroutine(FindLife());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            InteractAction();
            print("sdsadasasdasdasdsa");
        }
    }
    private IEnumerator FindLife()
    {
        yield return new WaitForEndOfFrame();
        life = GameManager.instance.player.GetLife;
    }
}
