using strange.extensions.mediation.impl;
using TinyRoar.Framework;
using UnityEngine;

class ProfileMediator : Mediator
{

    [Inject]
    public ProfileView view { get; set; }

    // from view
    [Inject]
    public TryLoginSignal TryLoginSignal { get; set; }

    // from controller
    [Inject]
    public LoggedInSignal LoggedInSignal { get; set; }
    [Inject]
    public LoginFailedSignal LoginFailedSignal { get; set; }

    public override void OnRegister()
    {
        // signals from view
        view.ButtonClickedSignal.AddListener(LoginTriggered);

        // controller
        LoggedInSignal.AddListener(OnLoggedIn);
        LoginFailedSignal.AddListener(OnLoginFailed);
    }

    public override void OnRemove()
    {
        // signals from view
        view.ButtonClickedSignal.RemoveListener(LoginTriggered);

        // controller
        LoggedInSignal.RemoveListener(OnLoggedIn);
        LoginFailedSignal.RemoveListener(OnLoginFailed);

    }

    private void LoginTriggered()
    {
        TryLoginSignal.Dispatch();
    }

    private void OnLoggedIn(string nickname)
    {
        Print.Log("Loggin In", Color.green);
        view.SetTextToLoggedIn();
    }

    private void OnLoginFailed()
    {
        Print.Log("Logged Out", Color.red);
        view.SetTextToLoggedOut();
    }


}
