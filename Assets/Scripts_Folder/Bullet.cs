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

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity = speed * Time.deltaTime;
        transform.Translate(Vector3.up * yVelocity, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        pointValue = collision.gameObject.tag.ToString();
        int.TryParse(pointValue, out int value);
        scoreAdd?.Invoke(value);
        Destroy(gameObject);
    }
}
