using UnityEngine;
public class Door : MonoBehaviour, IInteractiveObject
{
    private Animation _anim;
    private bool _isOpen;
    private void Start()
    {
        _isOpen = false;
        _anim = GetComponent<Animation>();
    }
    public void InteractAction()
    {
        if (!_isOpen)
        {
            _anim.Play("DoorOpen_animation");
            _isOpen = true;
        }
        else
        {
            _anim.Play("DoorClose_animation");
            _isOpen = false;
        }
    }
}
