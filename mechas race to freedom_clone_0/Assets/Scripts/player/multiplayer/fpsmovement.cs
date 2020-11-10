
using UnityEngine;
using Mirror;
public class fpsmovement : NetworkBehaviour
{
    Vector3 velosity;
    
    [Header("movement")]
    public CharacterController controller;
    float x, z;

    public fpsdata fpsdata; 
   

    bool isground;
    public Animator anime;
    // Update is called once per frame
    void Update() 
    {
        if (isground)
        {
            isground = controller.isGrounded;
        }

        if (isground && velosity.y<0)
        {
            velosity.y = -2f;
        }

        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("Jump") && isground)
            {

                isground = false;

                velosity.y = Mathf.Sqrt(fpsdata.jumpforce *fpsdata.speed - 2 *fpsdata.gravity);
            }
        }
        velosity.y += fpsdata.gravity * Time.deltaTime;
        controller.Move(velosity*Time.deltaTime);


        if (isLocalPlayer)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        if (x != 0 || z != 0)
        {
            anime.SetBool("is running", true);
            Vector3 move = transform.forward * z + transform.right * x;
            controller.Move(move * fpsdata.speed * Time.deltaTime);
        }
        else
        {
            anime.SetBool("is running", false);
        }
        
    }



}

