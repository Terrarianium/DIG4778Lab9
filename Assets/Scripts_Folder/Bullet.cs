using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed;
    private float yVelocity;

    private string pointValue;

    private int score;

    public delegate void AddScore(int value);
    public static event AddScore scoreAdd;

    [SerializeField]
    private GameObject bulletPool; // Reference to the BulletPool object

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = GameObject.Find("BulletPool"); // Get the BulletPool object from the scene.
        Invoke("ReturnToBulletPool", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity = speed * Time.deltaTime;
        transform.Translate(Vector3.up * yVelocity, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        pointValue = other.gameObject.tag.ToString();
        int.TryParse(pointValue, out int value);
        scoreAdd?.Invoke(value);
        Destroy(other.gameObject);
        ReturnToBulletPool();
    }

    // Method that returns the bullet to the bullet pool
    private void ReturnToBulletPool()
    {
        transform.parent = bulletPool.transform; // Set the parent of the bullet to the bullet pool.
        gameObject.SetActive(false); // Deactivate the bullet.
    }
}
