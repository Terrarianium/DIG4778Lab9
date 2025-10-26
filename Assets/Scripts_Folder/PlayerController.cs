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

    [SerializeField]
    private GameObject bulletPool; // Reference to the BulletPool object

    // Start is called before the first frame update
    void Start()
    {
         bulletPool = GameObject.Find("BulletPool"); // Get the BulletPool object from the scene
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavingService.SaveGame("SaveData.json");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavingService.LoadGame("SaveData.json");
            Debug.Log("Load");
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
        }
        
    }

    void shootBullet()
    {
        //Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        GameObject bullet = bulletPool.transform.GetChild(0).gameObject; // Get the first bullet from the pool.
        bullet.transform.parent = null; // Detach the bullet from the pool.
        bullet.transform.position = new Vector2(transform.position.x, transform.position.y + 1); // Set the bullet position to the player's position.
        bullet.SetActive(true); // Activate the bullet.
    }

    void PlayerMovement()
    {
        playerPosition = new Vector2(transform.position.x, transform.position.y);
        playerPosition.x += moveInput.x * Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.Clamp(playerPosition.x, -18, 18), transform.position.y);
    }

}
