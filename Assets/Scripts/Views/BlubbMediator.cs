using strange.extensions.mediation.impl;
using TinyRoar.Framework;
using UnityEngine;

class BlubbMediator : Mediator
{
    [Inject]
    public BlubbView view { get; set; }

    // from view
    [Inject]
    public TryBlubbSignal TryBlaSignal { get; set; }

    // from controller
    [Inject]
    public DoBlubbSignal DoBlubbSignal { get; set; }

    public override void OnRegister()
    {
        // signals from view
        view.ButtonClickedSignal.AddListener(LoginTriggered);

        // controller
        DoBlubbSignal.AddListener(DoBlubb);
    }

    public override void OnRemove()
    {
        // signals from view
        view.ButtonClickedSignal.RemoveListener(LoginTriggered);

        // controller
        DoBlubbSignal.RemoveListener(DoBlubb);
    }

    private void LoginTriggered()
    {
        TryBlaSignal.Dispatch("Blubb");
    }

    private void DoBlubb()
    {
        Print.Log("Blubb", Color.cyan);
        view.ShowText();
        //view.Hide();
    }


}
