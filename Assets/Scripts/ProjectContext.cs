using UnityEngine;

public class ProjectContext : Singleton<ProjectContext>
{
    [SerializeField] private bool _isTestInput = false;

    [field: SerializeField] public ItemsController ItemsController {  get; private set; }
    [field: SerializeField] public CoinController CoinController { get; private set; }

    public IInputService InputService { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        BindInpitSerice();
        ItemsController.Init(this);
    }

    private void BindInpitSerice()
    {
        if(_isTestInput)
        {
            InputService = gameObject.AddComponent<PcInputService>();
            return;
        }

#if UNITY_ANDROID
        InputService = gameObject.AddComponent<MobileInputService>();
#else
        InputService = gameObject.AddComponent<PcInputService>();
#endif
    }
}
