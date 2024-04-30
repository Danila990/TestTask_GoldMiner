using UnityEngine;

public class PauseButton : BaseButton
{
    [SerializeField] private string _pageId = "Pause";

    private PagesController _controller;

    protected override void Start()
    {
        base.Start();

        _controller = PagesController.Instance;
    }

    protected override void OnClick()
    {
        base.OnClick();

        Time.timeScale = 0;
        _controller.ShowPage(_pageId);
    }
}
