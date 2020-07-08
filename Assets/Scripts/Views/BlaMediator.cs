using strange.extensions.mediation.impl;
using TinyRoar.Framework;
using UnityEngine;

class BlaMediator : Mediator
{

    [Inject]
    public BlaView view { get; set; }

    // from view
    [Inject]
    public TryBlaSignal TryBlaSignal { get; set; }

    // from controller
    [Inject]
    public DoBlaSignal DoBlaSignal { get; set; }

    public override void OnRegister()
    {
        // signals from view
        view.ButtonClickedSignal.AddListener(LoginTriggered);

        // controller
        DoBlaSignal.AddListener(DoBla);
    }

    public override void OnRemove()
    {
        // signals from view
        view.ButtonClickedSignal.RemoveListener(LoginTriggered);

        // controller
        DoBlaSignal.RemoveListener(DoBla);

    }

    private void LoginTriggered()
    {
        TryBlaSignal.Dispatch("Bla");
    }

    private void DoBla()
    {
        Print.Log("Bla", Color.green);
        view.ShowText();
        //view.Hide();
    }


}
