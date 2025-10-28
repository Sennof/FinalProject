using System.Collections;
using TMPro;
using UnityEngine;

public class HintShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _hintText;

    private EventBinding<UIInteractionEvent> _eventBinding;
    private Coroutine _enablingCor = null;

    public void Initialize()
    {
        _eventBinding = new EventBinding<UIInteractionEvent>(HandleInteractionEvent);
        EventBus<UIInteractionEvent>.Register(_eventBinding);
    }

    private void OnDisable()
    {
        EventBus<UIInteractionEvent>.Deregister(_eventBinding);
    }

    private void UpdateHintText(string text) => _hintText.text = $"ֽאזלטעו: \"{text}\"";


    private void HandleInteractionEvent(UIInteractionEvent UIInteractionEvent)
    {
        UpdateHintText(UIInteractionEvent.KeyCode.ToString());

        if(_enablingCor != null)
        {
            StopCoroutine(_enablingCor);
            _enablingCor = null;
        }

        _enablingCor = StartCoroutine(EnablingCor());
    }

    private IEnumerator EnablingCor()
    {
        _hintText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        _hintText.gameObject.SetActive(false);

        _enablingCor = null;
    }
}
