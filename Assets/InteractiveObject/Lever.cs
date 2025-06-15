using UnityEngine;
public class Lever : MonoBehaviour, IInteractiveObject
{
    public Animation anim;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.Play("Lever_animation");
        }
    }
    public void InteractAction()
    {
        print("Palanca baja");
    }
}
