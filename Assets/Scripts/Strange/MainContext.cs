using strange.extensions.context.api;
using UnityEngine;


public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour contextView) : base(contextView)
    {
    }

    public MainContext(MonoBehaviour contextView, ContextStartupFlags flags) : base(contextView, flags)
    {
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        // Services
        injectionBinder.Bind<IUserService>().To<UserService>().ToSingleton();

        // Models
        injectionBinder.Bind<IUser>().To<User>().ToSingleton();

        // Signals to Controller
        commandBinder.Bind<StartSignal>()
            .To<StartCommand>()
            .Once();
        commandBinder.Bind<TryBlaSignal>().To<LoginCommand>().Pooled();
        commandBinder.Bind<TryBlubbSignal>().To<LoginCommand>().Pooled();

        // Signals as Singleton
        injectionBinder.Bind<DoBlaSignal>().ToSingleton();
        injectionBinder.Bind<DoBlubbSignal>().ToSingleton();

    }


}

