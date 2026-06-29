using UnityEngine;

public class NaifuContror : MonoBehaviour
{
    [SerializeField] AudioClip hitTargetSe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Shoot(Vector3 dir)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true; // èdóÕÇ≈óéÇøÇ»Ç¢ê›íËÇ‡Ç±Ç±Ç≈îOâüÇµ
            rb.AddForce(dir);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ìIÇ…ìñÇΩÇ¡ÇΩ");
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb != null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    // Update is called once per frame
    void Start()
    {
        //Shoot(new Vector3(0, 200, 2000));
    }
}
