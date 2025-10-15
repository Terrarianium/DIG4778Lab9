using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private float yVelocity;

    public delegate void AddScore();
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
        if (collision.gameObject.tag == "Enemy")
        {
            int score = int.Parse(collision.gameObject.tag);
            scoreAdd.Invoke(score);
            Destroy(gameObject);
        }
    }
}
