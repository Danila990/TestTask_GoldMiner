using System.Threading.Tasks;
using UnityEngine;

public class LoadPage : Page
{
    [SerializeField] private int _loadDuration = 1;
    [SerializeField] private string _openPageId = "Main";

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    private async void Load()
    {
        await Task.Delay(_loadDuration * 1000);
        PagesController.Instance.ShowPage(_openPageId);
    }
}
