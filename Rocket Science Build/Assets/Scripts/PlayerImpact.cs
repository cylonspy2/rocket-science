using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : MonoBehaviour
{
    float mass = 0.09f;
    Vector3 impact = Vector3.zero;
    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
       
        if (impact.magnitude > 0.2f)
        {
            character.Move(impact * Time.deltaTime);
        }

        
        impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime * 5);
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();

        
        if (dir.y < 0)
        {
            dir.y = -dir.y;
        }

        impact += dir.normalized * force / mass;
    }
}
