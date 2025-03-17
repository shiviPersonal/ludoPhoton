using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class NewDice : MonoBehaviour
{
    public GameObject Trigger;
    public Animator Controllar;
    public Animator ArrowControllar;
    //public GameObject Outputtext;
    public static bool diceisrolled = false;
    public int thenumber;
    void Update()
    {
        Trigger.GetComponent<Button>().onClick.AddListener(Rolldice);
        /*--if (GamePlay.PlayerTurn == "RedTeam")
        {
            Trigger.GetComponent<Image>().color = Color.red;
        }
        else {
            Trigger.GetComponent<Image>().color = Color.yellow;
        }-*/
        if (diceisrolled == false) {
            Controllar.SetBool("Rolled", false);
            ArrowControllar.SetBool("TurnToRoll", true);
        }
    }

    public void Rolldice() {
        if (diceisrolled == false) {
            ArrowControllar.SetBool("TurnToRoll", false);
            thenumber = Random.Range(1, 7);
            
            //Outputtext.GetComponent<Text>().text = thenumber.ToString();
            if (thenumber == 6) {
                GamePlay.bonused = true;
            }
            StartCoroutine("Rolling");
        }
    }
    IEnumerator Rolling(){
        Controllar.SetBool("Rolled", true);
        Controllar.SetInteger("DiceValue", thenumber);
        GamePlay.DiceOutcome = thenumber;
        GamePlay.TurnPlayed = false;
        diceisrolled = true;
        yield return new WaitForSeconds(.5f);
    }


}
