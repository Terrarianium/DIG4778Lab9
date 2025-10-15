using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMeteorBuilder : MonoBehaviour, IMeteorBuilder
{
    private GameObject fastMeteor; // Get reference for a fast meteor.

    // Set the color of the meteor.
    public void SetColor(Color color)
    {
        fastMeteor.GetComponent<Renderer>().material.color = color;
    }

    // Set the velocity of the meteor.
    public void SetVelocity(Vector3 velocity)
    {
        fastMeteor.GetComponent<Rigidbody>().velocity = velocity;
    }

    // Set the size of the meteor.
    public void SetSize(Vector3 size)
    {
        fastMeteor.transform.localScale = size;
    }

    // Build the meteor.
    public void Build(GameObject meteor, Vector3 location, Quaternion rotation, float direction)
    {
        fastMeteor = Instantiate(meteor, location, rotation);
        SetColor(Color.yellow);
        SetVelocity(new Vector3(10 * direction, 0, 0));
        SetSize(new Vector3(.8f, .8f, .8f));
        fastMeteor.tag = "3"; // Set tag for score.
        Destroy(fastMeteor, 5f);
    }
}
