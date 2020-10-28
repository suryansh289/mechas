
using UnityEngine;
using Mirror;
public class camerafps : NetworkBehaviour
{
    public float mousesensitivity;
    public Transform playerbody;
    float xrotation;
    void OnEnable()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        float mousex=0;
        float mousey=0;
        if (isLocalPlayer)
        {
            mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
            mousey = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;
        }
        xrotation -= mousey;

        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex);
    }
}
