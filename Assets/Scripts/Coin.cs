using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Main main;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            main.coin += 1;
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        main.coin = 0;
    }
}
