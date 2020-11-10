
using UnityEngine;

public class shoot : MonoBehaviour
{
    [Header("spawning essential")]
    public shootscriptable shootscriptable;
    public Transform spawnposandrot;
    public Animator anime;
    public Camera cam;
    [Header("sun stats")]

    attributeandhealth ath;
    public AudioSource asa;
    int id;
    //[Header("debuging")]
    //public AnimationCurve acx = new AnimationCurve();
    //public AnimationCurve acy = new AnimationCurve();
    //public AnimationCurve acz = new AnimationCurve();
    private void Start()
    {
        id = Animator.StringToHash("isshooting");
        InvokeRepeating("Updatebullet", 0, 1 / shootscriptable.spawnrate);
        InvokeRepeating("Updatepoint", 0, 1 / shootscriptable.pointupdaterate);
        ath = GetComponent<attributeandhealth>();
    }
    private void Updatebullet()
    {
        if (Input.GetMouseButton(0))
        {
            asa.Play();
            
            anime.SetBool(id,true);
            GameObject gi= objectpoolingoffline.instance.spawnfromqueue("shoot", spawnposandrot.position,spawnposandrot.rotation);
            gi.GetComponent<bullet>().setattribute(ath);
        }
        else
        {
            anime.SetBool("isshooting", false);
        }
    }

    private void Updatepoint()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootscriptable.maxdist))
        {
            spawnposandrot.LookAt(hit.point, Vector3.up);
        }
        //acx.AddKey(Time.time, hit.point.x);
        //acy.AddKey(Time.time, hit.point.y);
        //acz.AddKey(Time.time, hit.point.z);
    }

}
