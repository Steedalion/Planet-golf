using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float gravityStrength = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 10, transform.forward, 0);
        if(hits.Length < 1) return;
        ;
        foreach (RaycastHit raycastHit in hits)
        {
            if(raycastHit.collider.name.Equals(name)) continue;

            
            Rigidbody rb = raycastHit.rigidbody;
            Vector3 towardMe = (transform.position - raycastHit.transform.position);
            float distance = Mathf.Pow(towardMe.magnitude,2);
            float force = Mathf.Clamp(1/distance, 0.01f, 10);
            rb.AddForce(towardMe.normalized * gravityStrength *force);
            // Debug.Log(force);
        }
    }
}