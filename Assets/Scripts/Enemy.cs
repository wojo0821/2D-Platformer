using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private Transform playerCheck = null;
    [SerializeField] private float playerCheckRadius = 0.2f;
    [SerializeField] private LayerMask playerLayer = 0;
    [SerializeField] private GameObject coinPrefab = null;
    float speed = 2f;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayer) && speed != 0)
        {
            animator.SetBool("Enemy_Die", true);
            speed = 0;
            Destroy(gameObject, 0.7f);
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !animator.GetBool("Enemy_Die"))
        {
            collision.gameObject.GetComponent<Playermove>().Die();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }
}
