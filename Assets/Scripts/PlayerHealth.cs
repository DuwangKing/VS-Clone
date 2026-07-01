using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damageAmount = 25;
    [SerializeField] private float knockbackSpeed = 3f;
    [SerializeField] private float knokbackDuration = 0.5f;

    private Rigidbody2D playerRb;
    private PlayerController playerController;
    private int currentHealth;
    private bool isDead;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        Debug.Log("HP: " + currentHealth);
        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageAmount);
            PushPlayerAway(collision);
        }
    }
    void PushPlayerAway(Collision2D collision)
    {
        if (isDead) return;

        GameObject enemy = collision.gameObject;

        Vector2 pushDirection = (transform.position - enemy.transform.position).normalized;
        playerRb.linearVelocity = pushDirection * knockbackSpeed;

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        StartCoroutine(StopAfterKnockback());
    }

    private IEnumerator StopAfterKnockback()
    {
        yield return new WaitForSeconds(knokbackDuration);

        playerRb.linearVelocity = Vector2.zero;

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }

    void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage. HP: "
            + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Player died!");
    }
}