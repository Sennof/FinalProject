using UnityEngine;

public class InteractRay : MonoBehaviour
{
    private RaycastHit _rayHit;
    private GameObject _hit = null;
    private Interactable _target = null;

    private void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _rayHit, 15, ~3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.yellow);

            if (_hit != _rayHit.collider.gameObject)
            {
                _hit = _rayHit.collider.gameObject;
                _target = _hit.GetComponent<Interactable>();
            }
            else
            {
                if(_target.GetActableDistance() >= Vector3.Distance(transform.position, _target.transform.position))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.green);
                    if (Input.GetKeyDown(_target.GetKeyCode()))
                    {
                        _target.InvokeAction();
                    }
                }
            }
        }
    }
}
