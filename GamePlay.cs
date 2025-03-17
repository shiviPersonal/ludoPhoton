using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public static string PlayerTurn;
    public static bool TurnPlayed = true;
    public GameObject Reds;
    public GameObject Blues;
    public GameObject Greens;
    public GameObject Yallows;
    public static int Players = 2;
    public static int DiceOutcome;
    public static bool bonused = false;
    public pawns[] pawnofTurn;

    void Start()
    {
        PlayerTurn = "RedTeam";
        if (Players == 2) {
            Reds.SetActive(true);
            Yallows.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Players == 2) {
            if (PlayerTurn == "RedTeam")
            {
                pawnofTurn = Reds.transform.GetComponentsInChildren<pawns>();
            }
            else {
                pawnofTurn = Yallows.transform.GetComponentsInChildren<pawns>();
            }
        }
        
        if (TurnPlayed == true) {
            if (Players == 2)
            {
                if (bonused == true)
                {
                    bonused = false;
                }
                else
                {
                    if (PlayerTurn == "RedTeam")
                    {
                        PlayerTurn = "YallowTeam";

                    }
                    else
                    {
                        PlayerTurn = "RedTeam";
                    }
                }
            }
            TurnPlayed = false;
            NewDice.diceisrolled = false;
        }

        
        //Debug.Log(PlayerTurn);
    }
    void LateUpdate() {
        if (NewDice.diceisrolled)
        {
            Possibletomove();
            //Invoke("Possibletomove", 2);
        }
    }
    private void Possibletomove() {
        int canmove = 0;
        int cantmove = 0;
        foreach (pawns tpawn in pawnofTurn)
        {
            if (tpawn.housed && DiceOutcome != 6)
            {
                cantmove = cantmove + 1;
            } else if (DiceOutcome > tpawn.movetoreach) {
                cantmove = cantmove + 1;
            }
            else {
                canmove = canmove + 1;
            }
        }
        Debug.Log(PlayerTurn +' '+canmove.ToString());
        if (canmove == 0)
        {
            TurnPlayed = true;
        }
    }
}
