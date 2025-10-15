using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeteorBuilder
{
    public void SetSize(Vector3 size); // Set the size of the meteor
    public void SetVelocity(Vector3 velocity); // Set the velocity of the meteor
    public void SetColor(Color color); // Set the color of the meteor

    public void Build(GameObject meteor, Vector3 location, Quaternion rotation, float direction); // Build the meteor with specified parameters
}
