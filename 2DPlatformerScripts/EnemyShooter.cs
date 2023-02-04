using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector2[] shootingDirections;
    public float bulletSpeed = 5f;
    public float spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, shootingDirections.Length);
            Vector2 shootingDirection = shootingDirections[randomIndex];
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * bulletSpeed;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}