using System.Linq;
using UnityEngine;

public class PagesController : Singleton<PagesController>
{
    [SerializeField] private string _startPageId = "Load";
    [SerializeField] private bool _showStartPage = true;
    [SerializeField] private Page[] _pages;

    public Page CurrentPage { set; private get; }

    protected override void Awake()
    {
        base.Awake();

        if (_showStartPage)
        {
            CurrentPage = GetPage(_startPageId);
            CurrentPage.gameObject.SetActive(true);
        }
    }

    public void ShowPage(string pageId)
    {
        CurrentPage?.Hide();
        CurrentPage = GetPage(pageId);
        CurrentPage.gameObject.SetActive(true);
        CurrentPage.Show();
    }

    public void HidePage()
    {
        CurrentPage?.Hide();
        CurrentPage = null;
    }

    private Page GetPage(string id)
    {
        Page findPage = _pages.FirstOrDefault(page => page._id == id);
        if (findPage == null)
        {
            Debug.LogError("Page Id error: " + id);
        }

        return findPage;
    }

}
