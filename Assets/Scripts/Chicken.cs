using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chicken : MonoBehaviour
{
    [SerializeField] private float timeToChangeDirection;
    [SerializeField] private bool isCollidedWall;
    [SerializeField] private float angleOnCollision;
    public Counter counterClass;

    private float testChickenSpeed = 1;
    public float chickenSpeed //Encapsulation
    {
        get { return testChickenSpeed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative chicken speed!");
            }
            else
            {
                testChickenSpeed = value;
            }
        }
    }
    // Use this for initialization
    public void Start()
    {
        counterClass = GameObject.Find("Counter").GetComponent<Counter>();
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update() //Abstraction
    {
        timeToChangeDirection -= Time.deltaTime;
        TimeIsUp();
        WallCollision();
        Move();
    }



    private void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        transform.Rotate(0, angle, 0);
        timeToChangeDirection = 1.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Chick"))
        {
            angleOnCollision = transform.rotation.y;
            transform.Rotate(0, Random.Range(150f, 210f) + angleOnCollision, 0);
            timeToChangeDirection = 1.5f;
            isCollidedWall = true;
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
        counterClass.ChickenCounter();
    }

    void TimeIsUp()
    {
        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }
    }
    void WallCollision()
    {
        if (isCollidedWall)
        {
            Debug.Log(isCollidedWall);
            isCollidedWall = false;
        }
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * chickenSpeed * Time.deltaTime);
    }
}
