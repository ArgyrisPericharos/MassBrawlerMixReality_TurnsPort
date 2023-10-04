using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    //NPControl buttons for steup screen
    public Button ButtonForOffensiveBehaviour, ButtonForDefensiveBehaviour, ButtonForRandomBehaviour;

    //Non NPConttrol buttons for setup screen
    public Button NPControlPossitveButton, NPControlNegativeButton, ChangeOffenceStatPositiveButton, ChangeOffenceStatNegativeButton, ChangeDeffenceStatPositiveButton, ChangeDeffenceStatNegativeButton, ChangeMovementStatPositiveButton, ChangeMovementStatNegativeButton;
    public TextMeshProUGUI AvailablePointsTextNum, DefensivePointsTextNum, OffensivePointsTextNum, MovementPointsTextNum;

    public bool ReadyForStart;

    //for movement
    public GameObject[] availableMoves;
    public GridSquare currentSquare;
    public GridSquare newSquare;
    public bool SelectedMe;
    void Start()
    {
        NPControl = false;
        OffensiveBehaviour = false;
        DefenciveBehaviour = false;
        RandomBehaviour = false;
        IsMyturn = false;
        ReadyForStart = false;

        OffenceStat = 0;
        DefenceStat = 0;
        MovementStat = 4;
        AvailabePoints = 15;
    }


    void Update()
    {
        if (gameManager.GetComponent<GameManager>().SetUpPhaze == true && gameManager.GetComponent<GameManager>().MovementPhaze == false && gameManager.GetComponent<GameManager>().FightPhaze == false)
        {

            // move to setup screens and enable all fighter ui data
            if (NPControl == true)
            {
                //NPControlPossitveButton.gameObject.SetActive(false);
                ChangeOffenceStatPositiveButton.gameObject.SetActive(false);
                ChangeOffenceStatNegativeButton.gameObject.SetActive(false);
                ChangeDeffenceStatPositiveButton.gameObject.SetActive(false);
                ChangeDeffenceStatNegativeButton.gameObject.SetActive(false);
                ChangeMovementStatPositiveButton.gameObject.SetActive(false);
                ChangeMovementStatNegativeButton.gameObject.SetActive(false);
                AvailablePointsTextNum.gameObject.SetActive(false);
                DefensivePointsTextNum.gameObject.SetActive(false);
                OffensivePointsTextNum.gameObject.SetActive(false);
                MovementPointsTextNum.gameObject.SetActive(false);

                //ButtonForDefensiveBehaviour.gameObject.SetActive(true);
               // ButtonForDefensiveBehaviour.gameObject.SetActive(true);
               // ButtonForRandomBehaviour.gameObject.SetActive(true);
               // NPControlNegativeButton.gameObject.SetActive(true);

                if (DefenciveBehaviour == true && OffensiveBehaviour == false && RandomBehaviour == false)
                {
                    AvailabePoints = 0;
                    OffenceStat = 10;
                    DefenceStat = 5;
                }
                if (DefenciveBehaviour == false && OffensiveBehaviour == true && RandomBehaviour == false)
                {
                    AvailabePoints = 0;
                    OffenceStat = 5;
                    DefenceStat = 10;
                }
                else if (DefenciveBehaviour == false && OffensiveBehaviour == false && RandomBehaviour == true)
                {
                    AvailabePoints = 0;
                }
                //here turn off all visual ui access to this fighter's data.
                //also enable ai behaviour choice.
                
            }
            else if (NPControl == false)
            {
                //NPControlPossitveButton.gameObject.SetActive(true);
                ChangeOffenceStatPositiveButton.gameObject.SetActive(true);
                ChangeOffenceStatNegativeButton.gameObject.SetActive(true);
                ChangeDeffenceStatPositiveButton.gameObject.SetActive(true);
                ChangeDeffenceStatNegativeButton.gameObject.SetActive(true);
                ChangeMovementStatPositiveButton.gameObject.SetActive(true);
                ChangeMovementStatNegativeButton.gameObject.SetActive(true);
                AvailablePointsTextNum.gameObject.SetActive(true);
                DefensivePointsTextNum.gameObject.SetActive(true);
                OffensivePointsTextNum.gameObject.SetActive(true);
                MovementPointsTextNum.gameObject.SetActive(true);

                //ButtonForDefensiveBehaviour.gameObject.SetActive(false);
               // ButtonForDefensiveBehaviour.gameObject.SetActive(false);
               // ButtonForRandomBehaviour.gameObject.SetActive(false);
                //NPControlNegativeButton.gameObject.SetActive(false);


                AvailablePointsTextNum.text = AvailabePoints.ToString();
                DefensivePointsTextNum.text = DefenceStat.ToString();
                OffensivePointsTextNum.text = OffenceStat.ToString();
                MovementPointsTextNum.text = MovementStat.ToString();
                //here have all the data visible to the player so he can be able to choose what is the stats of their character.
            }
        }
        if (gameManager.GetComponent<GameManager>().MovementPhaze == true && gameManager.GetComponent<GameManager>().SetUpPhaze == false && gameManager.GetComponent<GameManager>().FightPhaze == false) 
        {

            //we have moved to move phaze

            ChangeOffenceStatPositiveButton.gameObject.SetActive(false);
            ChangeOffenceStatNegativeButton.gameObject.SetActive(false);
            ChangeDeffenceStatPositiveButton.gameObject.SetActive(false);
            ChangeDeffenceStatNegativeButton.gameObject.SetActive(false);
            ChangeMovementStatPositiveButton.gameObject.SetActive(false);
            ChangeMovementStatNegativeButton.gameObject.SetActive(false);
            AvailablePointsTextNum.gameObject.SetActive(false);
            DefensivePointsTextNum.gameObject.SetActive(false);
            OffensivePointsTextNum.gameObject.SetActive(false);
            MovementPointsTextNum.gameObject.SetActive(false);

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

    public void ChangeOffenceStatPositive()
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
  
    public void ChangeOffenceStatNegative()
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

    public void ChangeDeffenceStatPositive()
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

    public void ChangeDeffenceStatNegative()
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

    public void ChangeMovementStatPositive()
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

    public void ChangeMovementStatNegative()
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

    public void TurnNPControlOn()
    {
        NPControl = true;
    }

    public void TurnNPControlOff()
    {
        NPControl = false;
    }

    public void TurnOnDefenceControl()
    {
        DefenciveBehaviour = true;
        OffensiveBehaviour = false;
        RandomBehaviour = false;
        ButtonForDefensiveBehaviour.image.color = Color.white;
        ButtonForOffensiveBehaviour.image.color = Color.red;
        ButtonForRandomBehaviour.image.color = Color.red;
    }

    public void TurnOnOffenseControl()
    {
        DefenciveBehaviour = false;
        OffensiveBehaviour = true;
        RandomBehaviour = false;
        ButtonForDefensiveBehaviour.image.color = Color.red;
        ButtonForOffensiveBehaviour.image.color = Color.white;
        ButtonForRandomBehaviour.image.color = Color.red;
    }

    public void TurnOnRandomControl()
    {
        DefenciveBehaviour = false;
        OffensiveBehaviour = false;
        RandomBehaviour = true;
        ButtonForDefensiveBehaviour.image.color = Color.red;
        ButtonForOffensiveBehaviour.image.color = Color.red;
        ButtonForRandomBehaviour.image.color = Color.white;
    }


}
