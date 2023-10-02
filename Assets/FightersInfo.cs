using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FightersInfo : MonoBehaviour
{
    [RangeAttribute(0, 10)]
    public int OffenceStat;

    [SerializeField]

    [RangeAttribute(0, 10)]
    public int DefenceStat;

    [SerializeField]

    [RangeAttribute(4, 10)]
    public int MovementStat;

    [SerializeField]

    [RangeAttribute(0, 15)]
    public int AvailabePoints;

    [SerializeField]

    public GameManager gameManager;
    public bool NPControl, OffensiveBehaviour, DefenciveBehaviour, RandomBehaviour;
    public bool IsMyturn;



    //for movement
    public GameObject[] availableMoves;
    public GridSquare currentSquare;
    public GridSquare newSquare;
    public bool SelectedMe;
    void Start()
    {

        OffenceStat = 0;
        DefenceStat = 0;
        MovementStat = 4;
    }


    void Update()
    {
        if (gameManager.GetComponent<GameManager>().SetUpPhaze == true && gameManager.GetComponent<GameManager>().MovementPhaze == false && gameManager.GetComponent<GameManager>().FightPhaze == false)
        {

            // move to setup screens and enable all fighter ui data
            if (NPControl == true)
            {
                //here turn off all visual ui access to this fighter's data.
                //also enable ai behaviour choice.

            }
            else if (NPControl == false)
            {
                //here have all the data visible to the player so he can be able to choose what is the stats of their character.
            }
        }
        if (gameManager.GetComponent<GameManager>().MovementPhaze == true && gameManager.GetComponent<GameManager>().SetUpPhaze == false && gameManager.GetComponent<GameManager>().FightPhaze == false) 
        {
            //we have moved to move phaze
            if (NPControl == true)
            {
                if (IsMyturn == true)
                {
                    //time to move!, since is ai this will be affected by the behaviour.
                }
                else if (IsMyturn == false)
                {
                    //time to wait
                }
            }
            else if (NPControl == false)
            {
                if (IsMyturn == true)
                {
                    //time to move, you should have the ability here to move to any adjacent tile
                    //you select the fighter.
                }
                else if (IsMyturn == false)
                {
                    //time to wait
                }
            }
        }
        else if (gameManager.GetComponent<GameManager>().MovementPhaze == false && gameManager.GetComponent<GameManager>().SetUpPhaze == false && gameManager.GetComponent<GameManager>().FightPhaze == true)
        {
            //we have moved to fight phaze
        }

    }




    // all bellow are buttons calls, they have to be assigned to buttons in a setup screen.

    void ChangeOffenceStatPositive()
    {
        if (AvailabePoints > 0)
        {
            OffenceStat += 1;
            AvailabePoints -= 1;
        }
        else
        {
            Debug.Log("Not Enough Available Points");
        }
 
    }
  
    void ChangeOffenceStatNegative()
    {
        if (OffenceStat > 0)
        {
            OffenceStat -= 1;
            AvailabePoints += 1;
        } 
        else
        {
            Debug.Log("Not Enough Points");
        }

    }

    void ChangeDeffenceStatPositive()
    {
        if (AvailabePoints > 0)
        {
            DefenceStat += 1;
            AvailabePoints -= 1;
        }
        else
        {
            Debug.Log("Not Enough Available Points");
        }
   
    }

    void ChangeDeffenceStatNegative()
    {
        if (DefenceStat > 0)
        {
            DefenceStat -= 1;
            AvailabePoints += 1;
        }
        else
        {
            Debug.Log("Not Enough Points");
        }

    }

    void ChangeMovementStatPositive()
    {
        if (AvailabePoints > 0)
        {
            MovementStat += 1;
            AvailabePoints -= 1;
        }
        else
        {
            Debug.Log("Not Enough Available Points");
        }
 
    }

    void ChangeMovementStatNegative()
    {
        if (MovementStat > 4)
        {
            MovementStat -= 1;
            AvailabePoints += 1;
        }
        else
        {
            Debug.Log("Not Enough Points");
        }

    }

}
