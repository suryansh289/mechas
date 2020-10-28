
using UnityEngine;
using Mirror;
public class fpsmovement : NetworkBehaviour
{
    Vector3 velosity;
    public float gravity = -9.8f;
    [Header("movement")]
    public CharacterController controller;
    float x, z;


    public float speed;
    public float jumpforce;

    bool isground;

    // Update is called once per frame
    void Update() 
    {

        isground = controller.isGrounded;

        if (isground && velosity.y<0)
        {
            velosity.y = -2f;
        }

        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("Jump") && isground)
            {



                velosity.y = Mathf.Sqrt(jumpforce * speed - 2 * gravity);
            }
        }
        velosity.y += gravity * Time.deltaTime;
        controller.Move(velosity*Time.deltaTime);


        if (isLocalPlayer)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
       

        Vector3 move = transform.forward * z + transform.right * x;
        controller.Move(move * speed * Time.deltaTime);
        
    }



}

