using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.FlowStateWidget;

public class GameManager : MonoBehaviour
{
    public GameObject Fighter1, Fighter2, Fighter3, Fighter4, Fighter5; // 1*used to take all info of the fighters.

    public bool SetUpPhaze, MovementPhaze, FightPhaze; //used to determine the stage/phaze of the game which are: setting up menu screen, moving screen, dealing with encounter screen,

    //for fight phaze

    public GameObject Attacker, Deffender;

    public List<GameObject> AllFighters;

    public bool Sorted;


    void Start()
    {
        //1*take the script info from gameobject.
        SetUpPhaze = true;
        MovementPhaze = false;
        FightPhaze = false;

        Sorted = false;

        for (int i = 0; i < 1; i++)
        {
            AllFighters.Add(Fighter1);
            AllFighters.Add(Fighter2);
            AllFighters.Add(Fighter3);
            AllFighters.Add(Fighter4);
            AllFighters.Add(Fighter5);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (SetUpPhaze == true && MovementPhaze == false && FightPhaze == false)
        {
            //have buttons and screens for setup
        }
        if (SetUpPhaze == false && MovementPhaze == true && FightPhaze == false)
        {

   
            //AllFighters.OrderBy(go => go.gameObject.GetComponent<FightersInfo>().MovementStat).ToArray();

            if (Sorted == false)
            {
                SortInOrder();
                Sorted = true;
            }


            //have to make the grid were the players move and an order of player turns system
        }
        else if (SetUpPhaze == false && MovementPhaze == false && FightPhaze == true)
        {
            //here we will decide a formula that deals the current encounter with dice rolls.?
        }
    }

    void ChangeFromSetupPhazeToMovementPhaze()
    {
        SetUpPhaze = false;
        MovementPhaze = true;
        FightPhaze = false;
    }

    void ChangeFromMovementPhazeToFightPhaze()
    {
        SetUpPhaze = false;
        MovementPhaze = false;
        FightPhaze = true;
    }

    void SortInOrder()
    {
        for (int i = 0; i < AllFighters.Count; i++)
        {
            
        }
    }

}
