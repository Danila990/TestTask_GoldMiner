using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenPageButton : BaseButton
{
    [SerializeField] private string _pageId;

    private PagesController _controller;

    protected override void Start()
    {
        base.Start();

        _controller = PagesController.Instance;
    }

    protected override void OnClick()
    {
        base.OnClick();

        _controller.ShowPage(_pageId);
    }
}
