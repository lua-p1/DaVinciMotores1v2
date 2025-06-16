using UnityEngine;
public class RaycastPj
{
    private float _distanceRay;
    Transform _transform;
    public RaycastPj(Transform _transform, float _distanceRay)
    {
        this._transform = _transform;
        this._distanceRay = _distanceRay;
    }
    public void Interact()
    {
        Ray ray = new Ray(_transform.position, _transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distanceRay, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, _distanceRay))
        {
            if (hit.transform.gameObject.TryGetComponent<IInteractiveObject>(out var InteractuableObject))
            {
                InteractuableObject.InteractAction();
            }
        }
    }
}