using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float detectionRange = 10f;
    public float chaseRange = 5f; // The range at which the monster starts chasing the player
    public float movementSpeed = 5f;
    public float distanceToPlayer = 2f; // The desired distance between the monster and the player while chasing

    private int currentHits = 0;
    private bool isDead = false;
    private bool isChasing = false;

    private void Update()
    {
        if (!isDead && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                if (!isChasing && distanceToPlayer <= chaseRange)
                {
                    isChasing = true;
                }

                if (isChasing)
                {
                    // Calculate the direction to the player
                    Vector3 direction = (player.position - transform.position).normalized;

                    // Move towards the player with a bit of distance
                    Vector3 targetPosition = player.position - direction * distanceToPlayer;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

                    // Rotate to face the player
                    transform.LookAt(player);
                }
            }
            else
            {
                isChasing = false;
            }
        }
    }

    public void TakeDamage()
    {
        if (isDead)
            return;

        currentHits++;
        if (currentHits >= 5)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            // Add your code to make the monster fall here
        }
        else
        {
            animator.SetBool("isAttacking", true);
            // Add your code to handle the monster getting hit by the player's punch here
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
