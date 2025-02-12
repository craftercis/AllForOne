﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public int scrollSpeed;

    public GameObject objectToFollow;

    public float speed = 2.0f;

    public PlayerController pcScript;
    public PlayerSwitcher psScript;
    public TimeBalk tbScript;

    bool camMoveOn, backToTop;

    public GameObject timer;

    public void Start()
    {

    }

    void Update()
    {
        if (camMoveOn)
        {
            pcScript = psScript.playerNow.GetComponent<PlayerController>();

            //CAMERA SMOTHE OBJECT
            float interpolation = speed;

            Vector3 position = this.transform.position;
            Quaternion rotation = this.transform.rotation;
            Vector3 rotation2 = this.transform.eulerAngles;
            position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
            position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z, interpolation);
            if (!backToTop)
            {
                Debug.Log("heheh");
                rotation.x = Mathf.Lerp(this.transform.rotation.x, objectToFollow.transform.rotation.x, interpolation);
                rotation.y = Mathf.Lerp(this.transform.rotation.y, objectToFollow.transform.rotation.y, interpolation);
                rotation.z = Mathf.Lerp(this.transform.rotation.z, objectToFollow.transform.rotation.z, interpolation);
            }
            else if(backToTop)
            {
                Debug.Log("sadsad");
                rotation2.x = Mathf.Lerp(this.transform.eulerAngles.x, objectToFollow.transform.eulerAngles.x, interpolation);
                rotation2.y = Mathf.Lerp(this.transform.eulerAngles.y, objectToFollow.transform.eulerAngles.y, interpolation);
                rotation2.z = Mathf.Lerp(this.transform.eulerAngles.z, objectToFollow.transform.eulerAngles.z, interpolation);
            }

            this.transform.position = position;
            if (!backToTop)
            {
                this.transform.rotation = rotation;
                tbScript.walkOn = true;
            }
            else if(backToTop)
            {
                this.transform.eulerAngles = rotation2;
            }
        }
    }

    public void CameraParent()
    {
        Camera.main.transform.parent = objectToFollow.transform;
        pcScript.walkOn = true;
        camMoveOn = true;
        timer.SetActive(true);
        StartCoroutine(wait());
    }

    public void BackToTop()
    {
        Cursor.lockState = CursorLockMode.None;
        backToTop = true;
        objectToFollow = GameObject.Find("CamTop");
        Camera.main.transform.parent = objectToFollow.transform;
        pcScript.walkOn = false;
        psScript.SwitchPlayer();
        timer.SetActive(false);
        pcScript.canClick = false;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        pcScript.canClick = true;
    }
}
