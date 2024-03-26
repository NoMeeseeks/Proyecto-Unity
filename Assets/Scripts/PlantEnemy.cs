using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitedTimeAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    public void Start()
    {
        waitedTime = waitedTimeAttack;

    }

    private void update()
    {
        if(waitedTime<=0)
        {
            waitedTime = waitedTimeAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
