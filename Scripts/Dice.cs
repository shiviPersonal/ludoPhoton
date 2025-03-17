using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    public void RollDice()
    {
        int dice = Random.Range(0, 7);
        Debug.Log(dice.ToString());
        this.transform.GetChild(0).gameObject.transform.GetComponent<Text>().text = dice.ToString();
    }
}
