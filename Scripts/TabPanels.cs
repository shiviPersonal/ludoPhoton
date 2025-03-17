using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPanels : MonoBehaviour
{
    public GameObject Options;
    public GameObject Panels;

    public void Switchtabs(GameObject tabopt) {
        int index = tabopt.transform.GetSiblingIndex();


        for (int i = 0; i < Panels.transform.childCount; i++)
        {
            var child = Panels.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }


        Panels.transform.GetChild(index).gameObject.SetActive(true);
    }
}
