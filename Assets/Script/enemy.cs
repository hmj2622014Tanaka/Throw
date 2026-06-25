using UnityEngine;

public class Enemy : MonoBehaviour
{
    float lifeTime = 10f;

    [SerializeField] GameObject deathEffectPrefab;
    [SerializeField] int scoreValue = 100;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Naifu"))
        {
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            Destroy(collision.gameObject); // 当たったナイフを消す
            Destroy(gameObject);           // 敵自身を消す
        }
    }
}