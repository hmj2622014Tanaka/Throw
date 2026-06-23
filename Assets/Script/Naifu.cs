using UnityEngine;
using UnityEngine.InputSystem;

public class Naifu : MonoBehaviour
{
    [SerializeField] GameObject NaifuPrefab;
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
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            GameObject Naifu = Instantiate(NaifuPrefab, ray.origin, Quaternion.LookRotation(ray.direction));

            Naifu.GetComponent<NaifuContror>().Shoot(ray.direction * 2000);
        }
    }
}