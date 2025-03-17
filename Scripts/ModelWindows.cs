using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelWindows : MonoBehaviour
{
    public GameObject TriggerBtn;
    public GameObject CloseBtn;

    public void OpenWindows()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void CloseWindows()
    {
        this.transform.gameObject.SetActive(false);
    }
}
