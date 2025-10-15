using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalMeteorBuilder : MonoBehaviour, IMeteorBuilder
{
    private GameObject normalMeteor; // Get reference for a normal meteor.

    // Set the color of the meteor.
    public void SetColor(Color color)
    {
        normalMeteor.GetComponent<Renderer>().material.color = color;
    }

    // Set the velocity of the meteor.
    public void SetVelocity(Vector3 velocity)
    {
        normalMeteor.GetComponent<Rigidbody>().velocity = velocity;
    }

    // Set the size of the meteor.
    public void SetSize(Vector3 size)
    {
        normalMeteor.transform.localScale = size;
    }

    // Build the meteor.
    public void Build(GameObject meteor, Vector3 location, Quaternion rotation, float direction)
    {
        normalMeteor = Instantiate(meteor, location, rotation);
        SetColor(Color.white);
        SetVelocity(new Vector3(5 * direction, 0, 0));
        SetSize(new Vector3(1f, 1f, 1f));
        normalMeteor.tag = "1"; // Set tag for score.
        Destroy(normalMeteor, 9f);
    }
}
