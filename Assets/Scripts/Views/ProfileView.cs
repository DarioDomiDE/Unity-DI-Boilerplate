using strange.extensions.signal.impl;
using UnityEngine;

public class ProfileView : BaseView<ProfileView>
{
    [Inject]
    public IUser User { get; set; }

    public Signal ButtonClickedSignal = new Signal();

    [SerializeField]
    public GameObject LoggedIn;

    [SerializeField]
    private GameObject LoggedOut;

    public void Start()
    {
        SetTextToLoggedOut();
    }

    public void OnClick()
    {
        ButtonClickedSignal.Dispatch();
    }

    public void SetTextToLoggedIn()
    {
        //LoggedIn.SetActive(true);
        //LoggedOut.SetActive(false);
        Debug.Log("User has nickname: " + User.Nickname);
    }

    public void SetTextToLoggedOut()
    {
        //LoggedIn.SetActive(false);
        //LoggedOut.SetActive(true);
        Debug.Log("logged Out ");
    }




}
