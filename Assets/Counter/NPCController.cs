using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float timeToChangeDirection;
    [SerializeField] private bool isCollidedWall;
    [SerializeField] private float angleOnCollision;
    public Counter counterClass;
    // Use this for initialization
    public void Start()
    {
        counterClass = GameObject.Find("Counter").GetComponent<Counter>();
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (isCollidedWall)
        {
            Debug.Log(isCollidedWall);
            isCollidedWall = false;
        }

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }


        transform.Translate(Vector3.forward * Time.deltaTime);

        Debug.Log(isCollidedWall);
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
}
