using strange.extensions.context.api;
using strange.extensions.context.impl;

class MainBootstrap : ContextView
{
    protected static MainBootstrap _instance;

    public static MainBootstrap Instance => _instance;

    void Awake()
    {
        _instance = this;
        context = new MainContext(this, ContextStartupFlags.MANUAL_LAUNCH);
    }

    void Start()
    {
        Updater.Instance.ExecuteNextFrame(delegate
        {
            context.Launch();
        });
    }
}
