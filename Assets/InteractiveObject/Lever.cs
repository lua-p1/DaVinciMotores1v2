using UnityEngine;
public class Lever : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    public void InteractAction()
    {
        anim.Play("Lever_animation");
        print("Palanca baja");
    }
}
