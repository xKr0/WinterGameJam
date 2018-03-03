using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
	void Update () 
    {
        PlayerSpec.moveH = Input.GetAxis("Horizontal");
        PlayerSpec.moveV = Input.GetAxis("Vertical");

        PlayerSpec.pressJump = Input.GetButtonUp("A");
        PlayerSpec.pressGrab = Input.GetButtonUp("X");
        PlayerSpec.pressTalk = Input.GetButtonUp("B");

        PlayerSpec.leftTrigger = Input.GetAxis("LeftTrigger");
        PlayerSpec.rightTrigger = Input.GetAxis("RightTrigger");
	}

}
