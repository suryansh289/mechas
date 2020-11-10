using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class networkmanagercustom : NetworkManager
{
    [Scene] [SerializeField] private string menuscene = null;
    [SerializeField] private Transform playerspawnpos = null;
    [SerializeField] private TMP_InputField ipadress = null;
    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        if (numPlayers >= maxConnections|| SceneManager.GetActiveScene().name != menuscene)
        {
            conn.Disconnect();
            return;
        }
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if(SceneManager.GetActiveScene().name == menuscene)
        {
            SceneManager.LoadScene(1);
            GameObject go= Instantiate(playerPrefab,playerspawnpos.position,playerspawnpos.rotation);
            NetworkServer.AddPlayerForConnection(conn, go);
        }
    }
    public void joinashost()
    {
        string s = ipadress.text;
        networkAddress = s;
        StartHost();
    }public void joinaclient()
    {
        string s = ipadress.text;
        networkAddress = s;
        StartClient();
    }
}
