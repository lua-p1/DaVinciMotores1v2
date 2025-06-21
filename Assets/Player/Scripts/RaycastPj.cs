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
        if (Physics.Raycast(ray,out RaycastHit hit, _distanceRay))
        {
            if (hit.transform.gameObject.TryGetComponent<IInteractiveObject>(out var InteractuableObject))
            {
                InteractuableObject.InteractAction();
            }
        }
    }
    public bool IsObstacleInDirection(Vector3 direction,LayerMask mask ,float checkDistance = 0.6f)
    {
        Ray ray = new Ray(_transform.position, direction);
        Debug.DrawRay(ray.origin, ray.direction * checkDistance, Color.green);
        return Physics.Raycast(ray, checkDistance, mask);
    }
}