using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ItemBase : MonoBehaviour
{
    [SerializeField] private Sprite _icon;

    [SerializeField] private Transform _handsFolder;
    [SerializeField] private Transform _playgroundFolder;

    [SerializeField] private LayerMask _layerMask;

    private Rigidbody _rigidbody;
    private Collider _collider;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        if(_icon == null || _handsFolder == null || _playgroundFolder == null)
            Debug.LogError($"There is not enough data for normal operation | {name}");
    }

    public void PickUp()
    {
        transform.SetParent(_handsFolder);
        transform.localPosition = Vector3.zero;
        _rigidbody.isKinematic = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        _collider.excludeLayers = _layerMask; //TODO: Починить взаимодействие коллайдера с геймобджектами на сцене, ща не работает
    }

    public void Throw()
    {
        transform.SetParent(_playgroundFolder);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(transform.forward * 50, ForceMode.Impulse);
        _collider.excludeLayers = 0;
    }

    public void SetOff() => gameObject.SetActive(false);

    public void SetOn() => gameObject.SetActive(true);
}
