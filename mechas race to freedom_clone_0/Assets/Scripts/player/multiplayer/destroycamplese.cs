
using Mirror;
using UnityEngine;

public class destroycamplese : NetworkBehaviour
{
    public GameObject cam;
    public override void OnStartClient()
    {
        Destroy(cam.gameObject);
    }
}
