
using UnityEngine;

public class camerafpsoffline : MonoBehaviour
{
    public byte mousesensitivity;
    public Transform playerbody;
    float xrotation;
    bool isescape;
    void OnEnable()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isescape = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isescape = false;
        }
        if (isescape)
        {
            return;
        }
#endif
        float mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        xrotation -= mousey;

        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex);
    }
}
