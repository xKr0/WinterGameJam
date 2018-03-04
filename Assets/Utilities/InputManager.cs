using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
	void Update () 
    {
        if(PlayerSpec.canMove)
        {
            PlayerSpec.moveH = Input.GetAxis("Horizontal");
            PlayerSpec.moveV = Input.GetAxis("Vertical");

            PlayerSpec.pressJump = Input.GetButtonUp("A");
            PlayerSpec.pressGrab = Input.GetButtonUp("X");
            PlayerSpec.pressSpawn = Input.GetButtonUp("Y");

            PlayerSpec.leftTrigger = Input.GetAxis("LeftTrigger");
            PlayerSpec.rightTrigger = Input.GetAxis("RightTrigger");
        }
        else
        {
            PlayerSpec.pressSubmit = Input.GetButtonUp("A");
        }
        PlayerSpec.pressTalk = Input.GetButtonUp("Y");
        PlayerSpec.pressCancel = Input.GetButtonUp("B");
    }
}
