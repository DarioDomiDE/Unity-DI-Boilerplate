using System.Threading;
using UnityEngine;

public class UiInit : MonoBehaviour
{
    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
