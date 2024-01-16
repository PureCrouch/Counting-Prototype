using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteChicken : Chicken
{
    public override void Move() //Polymorphism
    {
        transform.Translate(Vector3.forward * 0.1f * Time.deltaTime);
    }
}
