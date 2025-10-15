using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorBuilder : MonoBehaviour, IMeteorBuilder
{
    private GameObject smallMeteor; // Get reference for a big meteor.

    // Set the color of the meteor.
    public void SetColor(Color color)
    {
        smallMeteor.GetComponent<Renderer>().material.color = color;
    }

    // Set the velocity of the meteor.
    public void SetVelocity(Vector3 velocity)
    {
        smallMeteor.GetComponent<Rigidbody>().velocity = velocity;
    }

    // Set the size of the meteor.
    public void SetSize(Vector3 size)
    {
        smallMeteor.transform.localScale = size;
    }

    // Build the meteor.
    public void Build(GameObject meteor, Vector3 location, Quaternion rotation, float direction)
    {
        smallMeteor = Instantiate(meteor, location, rotation);
        SetColor(Color.red);
        SetVelocity(new Vector3(3 * direction, 0, 0));
        SetSize(new Vector3(.6f, .6f, .6f));
        smallMeteor.tag = "2"; // Set tag for score.
        Destroy(smallMeteor, 14f);
    }
}
