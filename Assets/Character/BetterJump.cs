using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier =3f;

    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if (rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }else if( rb.velocity.y > 0f && !Input.GetButton("A")){
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
