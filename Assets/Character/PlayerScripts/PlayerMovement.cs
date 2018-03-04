using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rgbd;
    [SerializeField] Camera cameraPlayer;

    Vector3 lastMove;

    bool isGrounded = true;

    void Start()
    {
        lastMove = Vector3.zero;
    }

    void FixedUpdate ()
    {
        Move();
        Animating();

        if (PlayerSpec.pressJump && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        isGrounded = false;
        rgbd.velocity = Vector3.up * jumpSpeed;
    }

    void Move ()
    {
        if (cameraPlayer.enabled)
        {
            Vector3 movement = new Vector3(PlayerSpec.moveH, 0.0f, PlayerSpec.moveV);
            movement = cameraPlayer.transform.TransformDirection(movement);
            movement.y = 0.0f;
            Turn(movement);
            transform.Translate(movement * speed * Time.fixedDeltaTime, Space.World);
        }
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

    void Animating ()
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool running = PlayerSpec.moveH != 0f || PlayerSpec.moveV != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("isRunning", running);
    }

    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.layer==8 || collision.gameObject.layer==9)
        {
            isGrounded = true;
        }
    }

}