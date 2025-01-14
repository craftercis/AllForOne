﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{

    public GameObject unitP1, unitP2;
    public GameObject UnitListP1, UnitListP2;
    
    private int test,test2 = 0;

    public SliderValue svScript;
    public PlayerSwitcher psScript;

    void OnMouseDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) && svScript.raycastOn)
        {
            if(svScript.playerOnePoints < 10)
            {
                svScript.playerOneDone = true;
                StartCoroutine(WaitSecond());
                svScript.raycastOn = false;
            }
            if (svScript.playerTwoPoints < 10)
            {
                svScript.playerTwoDone = true;
                StartCoroutine(WaitSecond());
                svScript.raycastOn = false;
            }
            if ((svScript.switchTurn == false))
            {
                if (svScript.playerOnePoints == 0 && test == 0)
                {
                    psScript = GameObject.Find("GameManager").GetComponent<PlayerSwitcher>();
                    svScript.playerOneDone = true;
                    svScript.switchTurn = true;
                    Vector3 targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    GameObject newUnit = Instantiate(unitP1, targetLocation, Quaternion.identity);
                    newUnit.transform.parent = UnitListP1.transform;

                    UnitValues uvScript = newUnit.GetComponent<UnitValues>();
                    uvScript.health = svScript.sliderValue3[0];
                    uvScript.strength = svScript.sliderValue3[1];
                    uvScript.speed = svScript.sliderValue2[0];
                    uvScript.defense = svScript.sliderValue2[1];

                    svScript.switchTurn = true;
                    svScript.SwitchPlayer();
                    test = 2;
                    svScript.raycastOn = false;
                    StartCoroutine(WaitSecond());
                }
                else if (test == 0)
                {
                    Vector3 targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    GameObject newUnit = Instantiate(unitP1, targetLocation, Quaternion.identity);
                    newUnit.transform.parent = UnitListP1.transform;

                    UnitValues uvScript = newUnit.GetComponent<UnitValues>();
                    uvScript.health = svScript.sliderValue3[0];
                    uvScript.strength = svScript.sliderValue3[1];
                    uvScript.speed = svScript.sliderValue2[0];
                    uvScript.defense = svScript.sliderValue2[1];
                    svScript.raycastOn = false;
                    StartCoroutine(WaitSecond());

                    if (svScript.playerTwoDone)
                    {
                        svScript.switchTurn = false;
                        svScript.SwitchPlayer();
                        svScript.raycastOn = false;
                    }
                    else
                    {
                        svScript.switchTurn = !svScript.switchTurn;
                        svScript.SwitchPlayer();
                        svScript.raycastOn = false;
                    }
                }
                return;
            }
            if ((svScript.switchTurn == true))
            {
                if (svScript.playerTwoPoints == 0 && test2 == 0)
                {
                    Debug.Log("yo");
                    psScript = GameObject.Find("GameManager").GetComponent<PlayerSwitcher>();
                    svScript.playerTwoDone = true;
                    svScript.switchTurn = false;
                    Vector3 targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    GameObject newUnit = Instantiate(unitP2, targetLocation, Quaternion.identity);
                    newUnit.transform.parent = UnitListP2.transform;

                    UnitValues uvScript = newUnit.GetComponent<UnitValues>();
                    uvScript.health = svScript.sliderValue3[0];
                    uvScript.strength = svScript.sliderValue3[1];
                    uvScript.speed = svScript.sliderValue2[0];
                    uvScript.defense = svScript.sliderValue2[1];

                    svScript.SwitchPlayer();
                    test2 = 2;
                    svScript.raycastOn = false;
                    StartCoroutine(WaitSecond());
                }
                else if(test2 == 0)
                {
                    Vector3 targetLocation = hit.point;
                    targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
                    GameObject newUnit = Instantiate(unitP2, targetLocation, Quaternion.identity);
                    newUnit.transform.parent = UnitListP2.transform;

                    UnitValues uvScript = newUnit.GetComponent<UnitValues>();
                    uvScript.health = svScript.sliderValue3[0];
                    uvScript.strength = svScript.sliderValue3[1];
                    uvScript.speed = svScript.sliderValue2[0];
                    uvScript.defense = svScript.sliderValue2[1];
                    StartCoroutine(WaitSecond());

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

    IEnumerator WaitSecond()
    {
        psScript = GameObject.Find("GameManager").GetComponent<PlayerSwitcher>();
        yield return new WaitForSeconds(0.5f);
        psScript.stopFirstClick = true;
    }
}
