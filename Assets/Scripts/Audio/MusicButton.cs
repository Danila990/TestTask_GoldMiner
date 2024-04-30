using UnityEngine;
using UnityEngine.UI;

public class MusicButton : BaseButton
{
    [SerializeField] private Sprite _offState;
    [SerializeField] private Image _image;

    private Sprite _onState;

    protected override void Start()
    {
        base.Start();

        _onState = _image.sprite;
        ChangeSprite();
    }

    protected override void OnClick()
    {
        base.OnClick();

        _contoller.ChangeMuteMusic(!_contoller.IsMusicMute);
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (!_contoller.IsMusicMute)
        {
            _image.sprite = _onState;
        }
        else
        {
            _image.sprite = _offState;
        }
    }
}
