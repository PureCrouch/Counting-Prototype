using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowChicken : Chicken // INHERITANCE
{
    
    public override void Move() //Polymorphism
    {
        chickenSpeed = 2.0f;
        transform.Translate(Vector3.forward * chickenSpeed * Time.deltaTime);
    }
}
