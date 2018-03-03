using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBehaviour : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] SheepAgent sheepAgent;
    [SerializeField] Rigidbody rgbd;

    private bool enterCollision = false;

	void FixedUpdate () 
    {
        if (enterCollision || LostVelocity())
        {
            Reset();
        }
	}

    void Reset()
    {
        rgbd.velocity = Vector3.zero;
        anim.SetBool("Running", true);
        sheepAgent.enabled = true;
        enterCollision = false;
        this.enabled = false;
    }

    bool LostVelocity()
    {
        return (Mathf.Abs(rgbd.velocity.x) <= 0.1) 
            && (Mathf.Abs(rgbd.velocity.y) <= 0.1) 
            && (Mathf.Abs(rgbd.velocity.z) <= 0.1);
    }

    void OnCollisionEnter()
    {
        enterCollision = true;
    }
}
