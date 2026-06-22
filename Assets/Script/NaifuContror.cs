using UnityEngine;

public class NaifuContror : MonoBehaviour
{
    [SerializeField] AudioClip hitTargetSe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "target")
        {
            Debug.Log("“I‚É“–‚½‚Á‚½");
            AudioSource.PlayClipAtPoint(hitTargetSe, transform.position);
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
    }
}
