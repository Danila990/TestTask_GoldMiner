using UnityEngine;
using UnityEngine.UI;

public class SoundButton : BaseButton
{
    [SerializeField] private Sprite _offState;
    [SerializeField] private Image _image;

    private Sprite _onState;

    protected override void Start()
    {
        base.Start();

        _image = GetComponent<Image>();
        _onState = _image.sprite;
        ChangeSprite();
    }

    protected override void OnClick()
    {
        base.OnClick();

        _contoller.ChangeMuteSound(!_contoller.IsSoundMute);
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (!_contoller.IsSoundMute)
        {
            _image.sprite = _onState;
        }
        else
        {
            _image.sprite = _offState;
        }
    }
}
