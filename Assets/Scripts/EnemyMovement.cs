using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float stunDuration = 1f;
    private Transform player;
    private bool isStunned = false;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
    void Update()
    {
        if (isStunned) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StunEnemy());
        }
    }

    private IEnumerator StunEnemy()
    {
        isStunned=true;

        yield return new WaitForSeconds(stunDuration);

        isStunned = false;
    }
}

