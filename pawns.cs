using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pawns : MonoBehaviour
{
    public int currentpos;
    public int movetoreach = 56;
    public string pawnteam;
    public bool housed = false;
    public Waypoints pawnsway;
    public GameObject StantByPosition;
    public bool SafeZoned;
    public int PointtoReach;

    void Start()
    {
        housed = true;
        pawnsway = this.transform.parent.GetComponent<Waypoints>();
        pawnteam = this.transform.parent.tag;
        //Debug.Log(housed);
    }
    void Update(){
        this.GetComponent<Button>().onClick.AddListener(PlayTurn);
    }

    void PlayTurn()
    {
        int moves = GamePlay.DiceOutcome;
        if (GamePlay.PlayerTurn == pawnteam && GamePlay.TurnPlayed == false && NewDice.diceisrolled == true)
        {
            if (housed)
            {
                if (moves == 6) {
                    housed = false;
                    currentpos = 0;
                    //Debug.Log(pawnsway.transform.name.ToString());
                    this.transform.position = pawnsway.wayPoint[0].transform.position;
                }
                //iTween.MoveTo(this.gameObject, iTween.Hash("position", pawnsway.wayPoint[0].transform.position += Vector3.left * 2, "easetype", iTween.EaseType.easeInOutSine, "time", .2f));
            }else {
                if (moves <= movetoreach)
                {
                    PointtoReach = currentpos + moves;
                    movetoreach = 56 - currentpos;
                    //Debug.Log(currentpos.ToString());
                    //this.transform.position = pawnsway.wayPoint[currentpos].transform.position;
                    StartCoroutine("GoToNewPoint");
                }
                //iTween.MoveTo(this.gameObject, iTween.Hash("position", pawnsway.wayPoint[currentpos].transform.position += Vector3.left * 2, "easetype", iTween.EaseType.easeInOutSine, "time", .2f));
            }
            GamePlay.TurnPlayed = true;
        }
    }
    void OnTriggerEnter2D(Collider2D Other) {
        if (Other.tag == "House")
        {
            housed = true;
        }
        if (Other.tag == "SafeZone")
        {
            SafeZoned = true;
        }
        if (Other.tag == "Pawns" && Other.GetComponent<pawns>().SafeZoned == false && Other.GetComponent<pawns>().pawnteam != pawnteam && GamePlay.PlayerTurn != pawnteam && pawnsway.wayPoint[PointtoReach].gameObject == Other.GetComponentInParent<Waypoints>().wayPoint[Other.GetComponent<pawns>().currentpos].gameObject) {
            GamePlay.bonused = true;
            Other.transform.position = Other.GetComponent<pawns>().StantByPosition.transform.position;
            Other.GetComponent<pawns>().currentpos = 0;
            Other.GetComponent<pawns>().movetoreach = 56;
            Other.GetComponent<pawns>().housed = true;
        }
    }
    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.tag == "SafeZone")
        {
            SafeZoned = false;
        }
    }
    IEnumerator GoToNewPoint()
    {
        while (currentpos != PointtoReach)
        {
            currentpos += 1;
            this.transform.position = pawnsway.wayPoint[currentpos].transform.position;
            yield return new WaitForSeconds(.5f);
        }
    }

}
