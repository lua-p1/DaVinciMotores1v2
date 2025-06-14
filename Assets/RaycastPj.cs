using UnityEngine;
public class RaycastPj
{
    private float _distanceRay;
    Transform _transform;
    public RaycastPj(Transform transform, float distance)
    {
        _transform = transform;
        _distanceRay = distance;
    }
    public void Interact()
    {
        Ray ray = new Ray(_transform.position, _transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * _distanceRay, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, _distanceRay))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.TryGetComponent<IInteractiveObject>(out var InteractuableObject))
            {
                InteractuableObject.InteractAction();
            }
        }
    }
}