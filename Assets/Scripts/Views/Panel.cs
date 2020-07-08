using UnityEngine;

public abstract class Panel<T> : BaseView<T> where T : Panel<T>
{

    public void ShowText()
    {
        Debug.Log("ShowText Base");
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

}
