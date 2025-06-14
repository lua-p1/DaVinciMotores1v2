using System.Collections;
using UnityEngine;
public class PowerUps : MonoBehaviour
{
    protected Movement movement;
    protected float buff;
    protected float notBuff;
    protected virtual void Start()
    {
        StartCoroutine(FindMovement());
    }
    protected virtual void Update()
    {
        if (movement != null)
        {
        }
        if (GameManager.instance.player == null) { movement = null; }
    }
    private IEnumerator FindMovement()
    {
        yield return new WaitForEndOfFrame();
        if (movement == null)
        {
            print("movement no asignado correctamente en Trap.");
        }
        else
        {
            print("movement SI asignado correctamente en Trap.");
        }
    }
}
