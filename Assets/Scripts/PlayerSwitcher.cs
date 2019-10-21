﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{

    public CameraMove cmScript;
    public GameObject gameUI;

    public bool switchPlayer;
    public bool scriptOn;

    public PlayerController pcScript;

    //public bool switchplayer;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && scriptOn)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.transform.tag == "u_Player1" && !switchPlayer)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    pcScript = hit.transform.GetComponent<PlayerController>();
                    pcScript.speed = hit.transform.gameObject.GetComponent<UnitValues>().speed;

                    Debug.Log("yes");
                    cmScript.objectToFollow = hit.transform.GetChild(0).gameObject;
                    cmScript.pcScript = hit.transform.GetComponent<PlayerController>();
                    cmScript.CameraParent();
                }
                else if(hit.transform.tag == "u_Player2" && switchPlayer)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    pcScript = hit.transform.GetComponent<PlayerController>();
                    pcScript.speed = hit.transform.gameObject.GetComponent<UnitValues>().speed;


                    Debug.Log("yes");
                    cmScript.objectToFollow = hit.transform.GetChild(0).gameObject;
                    cmScript.pcScript = hit.transform.GetComponent<PlayerController>();
                    cmScript.CameraParent();
                }
            }
        }
    }

    public void StartGame()
    {
        cmScript.enabled = true;
        //cmScript.CameraParent();
        gameUI.SetActive(true);
    }

    public void SwitchPlayer()
    {
        switchPlayer = !switchPlayer;
    }
}