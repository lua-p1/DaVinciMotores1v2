using UnityEngine;
public class Lever : MonoBehaviour, IInteractiveObject
{
    private Animation _anim;
    private bool _canPlay;
    public TurretBehaviour turretRef;
    private void Start()
    {
        _canPlay = true;
        _anim = GetComponentInChildren<Animation>();
    }
    public void InteractAction()
    {
        if (!_canPlay) return;
        _anim.Play("Lever_animation");
        if (turretRef == null) return;
        turretRef.OnDead();
        _canPlay = false;
    }
}
