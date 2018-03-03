using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    bool isGrabbed = false;

    public bool IsGrabbed
    {
        get { return isGrabbed; }
        set { isGrabbed = value; }
    }

}
