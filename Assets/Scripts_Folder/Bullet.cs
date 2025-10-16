using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private float yVelocity;

    private string pointValue;

    private int score;

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
        if (collision.gameObject.tag == "1" || collision.gameObject.tag == "2" || collision.gameObject.tag == "3")
        {
            pointValue = collision.gameObject.tag.ToString();
            int.TryParse(pointValue, out int value);
            score = value;
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Score.scoreNumber += score;
    }
}
