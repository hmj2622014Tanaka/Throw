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
            GameObject igaguri = Instantiate(NaifuPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
            igaguri.GetComponent<NaifuContror>().Shoot(ray.direction * 2000);
        }
    }
}