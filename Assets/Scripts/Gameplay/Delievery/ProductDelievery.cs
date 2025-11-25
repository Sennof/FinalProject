using UnityEngine;

public class ProductDelievery : MonoBehaviour
{
    [SerializeField] private Transform _playgroundFolder;
    [SerializeField] private Transform _spawnPoint;

    private EventBinding<DelieveryRequestEvent> _eventBinding;
    private DelieveryRequestEvent _eventData;

    public void Initialize()
    {
        _eventBinding = new EventBinding<DelieveryRequestEvent>(HandleDelieveryRequest);
        EventBus<DelieveryRequestEvent>.Register(_eventBinding);
    }

    private void OnDisable()
    {
        EventBus<DelieveryRequestEvent>.Deregister(_eventBinding);
    }

    public void HandleDelieveryRequest(DelieveryRequestEvent eventData)
    {
        _eventData = eventData;

        for(int i = 0; i < eventData.ProductAmount; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject obj = Instantiate(_eventData.Prefab, _playgroundFolder, _spawnPoint);
        obj.SetActive(true);
    }
}
