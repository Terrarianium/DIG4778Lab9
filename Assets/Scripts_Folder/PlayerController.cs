using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private bool fire = false;

    public GameObject bullet;

    private Vector2 playerPosition;

    public float speed = 5f;

    private float cooldown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (fire == true && cooldown <= 0)
        {
            shootBullet();
            fire = false;
            cooldown = 0.5f;
        }
        PlayerMovement();
        if (cooldown > 0)
        { 
            cooldown -= Time.deltaTime;
        }
    }

    void OnMove(InputValue move)
    {
        moveInput = move.Get<Vector2>();
    }

    void OnShoot(InputValue shoot)
    {
        if (!fire)
        {
            fire = true;
            Debug.Log(fire);
        }
        
    }

    void shootBullet()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
    }

    void PlayerMovement()
    {
        playerPosition = new Vector2(transform.position.x, transform.position.y);
        playerPosition.x += moveInput.x * Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.Clamp(playerPosition.x, -18, 18), transform.position.y);
    }

}
