using UnityEngine;
public class Lever : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    private bool _canPlay;
    public TurretBehaviour turretRef;
    private void Start()
    {
        _canPlay = true;
    }
    public void InteractAction()
    {
        if (!_canPlay) return;
        anim.Play("Lever_animation");
        if (turretRef == null) return;
        turretRef.OnDead();
        _canPlay = false;
    }
}
