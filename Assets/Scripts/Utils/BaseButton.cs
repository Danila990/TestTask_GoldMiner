using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    protected AudioController _contoller;

    protected virtual void Start()
    {
        _contoller = AudioController.Instance;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    protected virtual void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    protected virtual void OnClick()
    {
        _contoller.PlayButtonClick();
    }
}
