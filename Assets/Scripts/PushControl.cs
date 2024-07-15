using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PushControl : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;
    public float speed;
    public float force;

    private Vector3 _destination;
    
    void Start()
    {
        _destination = endPoint.transform.position;
    }

    void Update()
    {
        if (transform.position != _destination)
            transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * speed);
        else
        {
            if (_destination == startPoint.transform.position)
                _destination = endPoint.transform.position;
            else
                _destination = startPoint.transform.position;            
        }
    }

    public void Push(GameObject ball)
    {
        Vector3 destinationCenter = ball.GetComponent<SphereCollider>().bounds.center;
        Vector3 objectCenter = GetComponent<CapsuleCollider>().bounds.center;        
        Vector3 dirrection =  destinationCenter - objectCenter;
        ball.GetComponent<Rigidbody>().AddForce(dirrection * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SphereCollider>() != null)
            Push(collision.gameObject);
    }
}
