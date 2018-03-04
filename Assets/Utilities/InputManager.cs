using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
	void Update () 
    {
        UIManager.pressStart = Input.GetButtonUp("Start");

        if (!UIManager.isPaused)
        {
            if(PlayerSpec.canMove)
            {
                PlayerSpec.moveH = Input.GetAxis("Horizontal");
                PlayerSpec.moveV = Input.GetAxis("Vertical");

                PlayerSpec.pressJump = Input.GetButtonDown("A");
                PlayerSpec.pressGrab = Input.GetButtonUp("X");                

                PlayerSpec.leftTrigger = Input.GetAxis("LeftTrigger");
                PlayerSpec.rightTrigger = Input.GetAxis("RightTrigger");
            }
            else
            {
                PlayerSpec.pressSubmit = Input.GetButtonUp("A");
            }
            PlayerSpec.pressSpawn = Input.GetButtonUp("Y");
            PlayerSpec.pressCancel = Input.GetButtonUp("B");
        }

    }
}
