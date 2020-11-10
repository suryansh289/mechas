
using UnityEngine;
using Mirror;
public class camerafps : NetworkBehaviour
{
    public byte mousesensitivity;
    public Transform playerbody;
    float xrotation;
    bool b = true;
    public NetworkIdentity ni;
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        float mousex=0;
        float mousey=0;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            b = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            b = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
#endif
        if (ni.isLocalPlayer&&b)
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
