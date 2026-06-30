using UnityEngine;

public class NaifuContror : MonoBehaviour
{
    [SerializeField] AudioClip hitTargetSe;
    [SerializeField] AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Shoot(Vector3 dir)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true; // 重力で落ちない設定もここで念押し
            rb.AddForce(dir);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("的に当たった");

            if (hitTargetSe != null)
            {
                AudioSource.PlayClipAtPoint(hitTargetSe, transform.position);
            }
            else
            {
                Debug.LogError("SE（hitTargetSe）がセットされていません！");
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb != null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
 }
