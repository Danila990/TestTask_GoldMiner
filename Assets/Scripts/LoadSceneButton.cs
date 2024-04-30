using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : BaseButton
{
    [SerializeField] private int _sceneIndex = 0;

    protected override void OnClick()
    {
        base.OnClick();

        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex);
    }
}
