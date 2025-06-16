using UnityEngine;
public class Lever : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    private bool _canPlay;
    private void Start()
    {
        _canPlay = true;
    }
    public void InteractAction()
    {
        if (!_canPlay) return;
        anim.Play("Lever_animation");
        _canPlay = false;
    }
}
