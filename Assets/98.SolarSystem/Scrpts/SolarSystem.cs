﻿using UnityEngine;

public class Orbit : MonoBehaviour
{
    readonly float G = 1000f;
    GameObject[] celestials;

    [SerializeField]
    bool IsElipticalOrbit = false;

    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");

        SetInitialVelocity();
    }


    void FixedUpdate()
    {
        Gravity();
    }

    void SetInitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);

                    if (IsElipticalOrbit)
                    {
                        a.GetComponent<Rigidbody>().linearVelocity += a.transform.right * Mathf.Sqrt((G * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        
                        a.GetComponent<Rigidbody>().linearVelocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                    }
                }
            }
        }
    }

    void Gravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }
}