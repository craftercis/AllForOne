﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{

    public GameObject unitP1, unitP2;
    public GameObject UnitListP1, UnitListP2;

    private int test,test2 = 0;

    public SliderValue svScript;

    void OnMouseDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if(svScript.playerOnePoints < 10)
            {
                svScript.playerOneDone = true;
            }
            if (svScript.playerTwoPoints < 10)
            {
                svScript.playerTwoDone = true;
            }
            if ((svScript.switchTurn == false))
            {
                if (svScript.playerOnePoints == 0 && test == 0)
                {
                    svScript.playerOneDone = true;
                    svScript.switchTurn = true;
                    GameObject newUnit = Instantiate(unitP1, hit.point, Quaternion.identity);
                    newUnit.transform.parent = UnitListP1.transform;
                    svScript.switchTurn = true;
                    svScript.SwitchPlayer();
                    test = 2;
                }
                else if (test == 0)
                {
                    GameObject newUnit = Instantiate(unitP1, hit.point, Quaternion.identity);
                    newUnit.transform.parent = UnitListP1.transform;
                    if (svScript.playerTwoDone)
                    {
                        svScript.switchTurn = false;
                        svScript.SwitchPlayer();
                    }
                    else
                    {
                        svScript.switchTurn = !svScript.switchTurn;
                        svScript.SwitchPlayer();
                    }
                }
                return;
            }
            if ((svScript.switchTurn == true))
            {
                if (svScript.playerTwoPoints == 0 && test2 == 0)
                {
                    svScript.playerTwoDone = true;
                    svScript.switchTurn = false;
                    GameObject newUnit = Instantiate(unitP2, hit.point, Quaternion.identity);
                    newUnit.transform.parent = UnitListP2.transform;
                    svScript.SwitchPlayer();
                    test2 = 2;
                }
                else if(test2 == 0)
                {
                    GameObject newUnit = Instantiate(unitP2, hit.point, Quaternion.identity);
                    newUnit.transform.parent = UnitListP2.transform;
                    if (svScript.playerOneDone)
                    {
                        svScript.switchTurn = true;
                        svScript.SwitchPlayer();
                    }
                    else
                    {
                        svScript.switchTurn = !svScript.switchTurn;
                        svScript.SwitchPlayer();
                    }
                }
            }
        }
    }
}
