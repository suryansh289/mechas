
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class multiplayerstuff : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameinputfield = null;
    [SerializeField] private Button b = null;
    [SerializeField] private GameObject ga1 =null;
    [SerializeField] private GameObject ga2 = null; 
    private const string key = "playername";
    public string myname { get; private set; }
    private void Start() => checkforpreviusname();

    private void checkforpreviusname()
    {
        if (!PlayerPrefs.HasKey(key)) { return; }
        string defaultname = PlayerPrefs.GetString(key);
        nameinputfield.text = defaultname;
        setmyname(defaultname) ;
    }
    private void setmyname(string s)
    {
        if (!string.IsNullOrEmpty(s))
        {
            myname = s;
            Debug.Log(s);
            b.interactable = true;
        }
        else
        {
            b.interactable = false;
        }
    }
    public void inputfieldchange(string s)
    {
        setmyname(s);
        PlayerPrefs.SetString(key, s);
    }
    public void play()
    {
        ga1.SetActive(false);
        ga2.SetActive(true);
    }
    public void back()
    {
        ga1.SetActive(true);
        ga2.SetActive(false);
    }
}
