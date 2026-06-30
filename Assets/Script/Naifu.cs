using UnityEngine;
using UnityEngine.InputSystem;

public class Naifu : MonoBehaviour
{
    [SerializeField] GameObject NaifuPrefab;

    [SerializeField] int maxNaifuCount = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            NaifuContror[] currentKnives = FindObjectsByType<NaifuContror>(FindObjectsSortMode.None);

            //ƒiƒCƒt‚ªÅ‘å”‚Ìê‡
            if (currentKnives.Length >= maxNaifuCount)
            {
                if (currentKnives.Length > 0 && currentKnives[0] != null)
                {
                    Destroy(currentKnives[0].gameObject);
                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            GameObject Naifu = Instantiate(NaifuPrefab, ray.origin, Quaternion.LookRotation(ray.direction));

            Naifu.GetComponent<NaifuContror>().Shoot(ray.direction * 2000);
        }
    }
}