using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private bool fire = false;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (fire == true)
        {
            shootBullet();
        }
        PlayerMovement();
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
        
    }

}
