using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Door : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    private bool _canPlay;
    private float _cooldown;
    private void Start()
    {
        _canPlay = true;
        _cooldown = 5f;
    }
    public void InteractAction()
    {
        if (!_canPlay) return;
        anim.Play("DoorOpen_animation");
        _canPlay = false;
        
    }
    IEnumerator CooldownCourutine()
    {
        yield return new WaitForSeconds(_cooldown);
    }
}
