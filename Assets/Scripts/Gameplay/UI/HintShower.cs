using TMPro;
using UnityEngine;

public class HintShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _hintText;

    private EventBinding<UIInteractionEvent> _eventBinding;

    public void Initialize()
    {
        _eventBinding = new EventBinding<UIInteractionEvent>(HandleInteractionEvent);
        EventBus<UIInteractionEvent>.Register(_eventBinding);
    }

    private void OnDisable()
    {
        EventBus<UIInteractionEvent>.Deregister(_eventBinding);
    }

    private void HandleInteractionEvent(UIInteractionEvent UIInteractionEvent)
    {
        if(UIInteractionEvent.KeyCode == null)
        {
            _hintText.gameObject.SetActive((bool)UIInteractionEvent.Enabled);
        }
        else
        {
            _hintText.text = $"ֽאזלטעו: \"{UIInteractionEvent.KeyCode}\"";
        }
    }
}
