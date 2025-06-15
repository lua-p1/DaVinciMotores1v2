using UnityEngine;
public class Medikit : MonoBehaviour, IInteractiveObject
{
    private Life _life;
    public int restoreLife;
    private void Start()
    {
        _life = GameManager.instance.player.GetLife;
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            _life.TakeDamage(20);
        }
    }
}
