using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Follow Settings")]
    public Transform player;
    public float moveSpeed;
    public float maxSpeed;
    public float maxDistance;


    private void Update() {
        // Get the direction from this enemy to the player position
        Vector2 direction = (player.position - transform.position).normalized;

        // Get the angle between the current direction and desired direction.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set our rotation to this new angle.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Adjust our move speed based on our distance from the player.
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance > maxDistance)
            distance = maxDistance;

        float speedPercentage = distance / maxDistance;

        moveSpeed = maxSpeed * speedPercentage;
        print(moveSpeed);

        // Move our enemy to the right.
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
