using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.FlowStateWidget;

public class GameManager : MonoBehaviour
{
    public GameObject Fighter1, Fighter2, Fighter3, Fighter4, Fighter5; // 1*used to take all info of the fighters.
    public GameObject GridSystem;
    public bool SetUpPhaze, MovementPhaze, FightPhaze; //used to determine the stage/phaze of the game which are: setting up menu screen, moving screen, dealing with encounter screen,


    //ForSetupPhaze
    public Button ButtonToMoveFromSetToMove;

    //For sorting the order of who plays in turns.
    [SerializeField] private List<AllFightersData> AllFighters = new List<AllFightersData>();
    public bool Sorted;

    //for fight phaze
    public GameObject Attacker, Deffender;

    void Start()
    {
        //1*take the script info from gameobject.
        SetUpPhaze = true;
        MovementPhaze = false;
        FightPhaze = false;

        ButtonToMoveFromSetToMove.gameObject.SetActive(false);
        GridSystem.SetActive(false);
        Sorted = false;

        /* for (int i = 0; i < 1; i++)
         {
             AllFighters.Add(Fighter1);
             AllFighters.Add(Fighter2);
             AllFighters.Add(Fighter3);
             AllFighters.Add(Fighter4);
             AllFighters.Add(Fighter5);
         }

         AllFighters.Add(new AllFightersData(Fighter1.GetComponent<FightersInfo>().MovementStat));
         AllFighters.Add(new AllFightersData(Fighter2.GetComponent<FightersInfo>().MovementStat));
         AllFighters.Add(new AllFightersData(Fighter3.GetComponent<FightersInfo>().MovementStat));
         AllFighters.Add(new AllFightersData(Fighter4.GetComponent<FightersInfo>().MovementStat));
         AllFighters.Add(new AllFightersData(Fighter5.GetComponent<FightersInfo>().MovementStat));
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (SetUpPhaze == true && MovementPhaze == false && FightPhaze == false)
        {
            if (Fighter1.GetComponent<FightersInfo>().AvailabePoints == 0 && Fighter2.GetComponent<FightersInfo>().AvailabePoints == 0 && Fighter3.GetComponent<FightersInfo>().AvailabePoints == 0 && Fighter4.GetComponent<FightersInfo>().AvailabePoints == 0 && Fighter5.GetComponent<FightersInfo>().AvailabePoints == 0)
            {
                ButtonToMoveFromSetToMove.gameObject.SetActive(true);
            }
            //have buttons and screens for setup
        }
        if (SetUpPhaze == false && MovementPhaze == true && FightPhaze == false)
        {
            ButtonToMoveFromSetToMove.gameObject.SetActive(false);
            GridSystem.SetActive(true);

            //AllFighters.OrderBy(go => go.gameObject.GetComponent<FightersInfo>().MovementStat).ToArray();
            if (Sorted == false)
            {
                AllFighters.Add(new AllFightersData(Fighter1.GetComponent<FightersInfo>().MovementStat, Fighter1.name));
                AllFighters.Add(new AllFightersData(Fighter2.GetComponent<FightersInfo>().MovementStat, Fighter2.name));
                AllFighters.Add(new AllFightersData(Fighter3.GetComponent<FightersInfo>().MovementStat, Fighter3.name));
                AllFighters.Add(new AllFightersData(Fighter4.GetComponent<FightersInfo>().MovementStat, Fighter4.name));
                AllFighters.Add(new AllFightersData(Fighter5.GetComponent<FightersInfo>().MovementStat, Fighter5.name));
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

    private void SortInOrder()
    {
        /*for (int i = 0; i < AllFighters.Count; i++)
        {

        } */

        AllFighters.Sort(SortByMovement);
    }

    private int SortByMovement(AllFightersData a, AllFightersData b)
    {
        if (a.MovementStatInfo > b.MovementStatInfo)
        {
            return -1;
        }
        else if (a.MovementStatInfo < b.MovementStatInfo)
        {
            return 1;
        }
        return 0;
    }


}
