using System.Threading;
using UnityEngine;

public class UiInit : MonoBehaviour
{
    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }
}
