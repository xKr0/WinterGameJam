using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;      
    [SerializeField] Animator anim;
    Vector3 lastMove;

    void Start()
    {
        lastMove = Vector3.zero;
    }

    void FixedUpdate ()
    {
        // Store the input axes.
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");

        Move (moveHorizontal, moveVertical);
        Animating (moveHorizontal, moveVertical);
    }

    void Move (float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Turn(movement);
        transform.Translate (movement * speed * Time.deltaTime, Space.World);
    }

    void Turn(Vector3 movement)
    {
        movement.Normalize();

        if (movement != Vector3.zero)             
        {                 
            // smooth rotation only if movement is not opposed to last movement                 
            if(lastMove + movement != Vector3.zero)                 
            {                     
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);                 
            }                 
            else                 
            {                     
                transform.rotation = Quaternion.LookRotation(movement);                 
            }                 
            this.lastMove = movement;             
        }
    }

    void Animating (float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool running = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("isRunning", running);
    }
}