using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControl : MonoBehaviour
{

    public float forceAmount;    
    
    public void Hit(GameObject ball)
    {
        Vector3 destinationCenter = ball.GetComponent<SphereCollider>().bounds.center;
        Vector3 objectCenter = GetComponent<Collider>().bounds.center;
        Debug.Log(destinationCenter);
        Debug.Log(objectCenter);
        Vector3 dirrection = objectCenter - destinationCenter;
        Debug.Log(dirrection);
        GetComponent<Rigidbody>().AddForce(dirrection * forceAmount, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SphereCollider>() != null)
            Hit(collision.gameObject);
    }

}
