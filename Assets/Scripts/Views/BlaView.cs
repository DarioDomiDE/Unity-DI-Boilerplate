using strange.extensions.signal.impl;
using UnityEngine;

public class BlaView : Panel<BlaView>
{
    [Inject]
    public IUser User { get; set; }

    public Signal ButtonClickedSignal = new Signal();

    public void OnClick()
    {
        ButtonClickedSignal.Dispatch();
    }

    public new void ShowText()
    {
        Debug.Log("ShowText Bla");
    }

}
