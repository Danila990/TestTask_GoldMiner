using UnityEngine;

public class ClosePauseButton : BaseButton
{
    private PagesController _controller;

    protected override void Start()
    {
        base.Start();

        _controller = PagesController.Instance;
    }

    protected override void OnClick()
    {
        base.OnClick();

        Time.timeScale = 1.0f;
        _controller.HidePage();
    }
}
