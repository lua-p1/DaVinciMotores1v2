using UnityEngine;
public class Door : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    private bool _isOpen;
    private void Start()
    {
        _isOpen = false;
    }
    public void InteractAction()
    {
        if (!_isOpen)
        {
            anim.Play("DoorOpen_animation");
            _isOpen = true;
        }
        else
        {
            anim.Play("DoorClose_animation");
            _isOpen = false;
        }
    }
}
