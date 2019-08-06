using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveForce : MonoBehaviour
{
    public float explosionForce = 20;

    private IEnumerator Start()
    {
        yield return null;



        float r = 5;
        var cols = Physics.OverlapSphere(transform.position, r);
        var rigidbodies = new List<Rigidbody>();
        foreach (var col in cols)
        {
            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
            {
                rigidbodies.Add(col.attachedRigidbody);
            }
            else if (col.transform.tag == "Player")
            {
                rigidbodies.Add(col.GetComponent<Rigidbody>());
            }
        }
        foreach (var rb in rigidbodies)
        {
            if (rb.transform.tag == "Player")
            {
                PlayerImpact impactReceiver = rb.transform.GetComponent<PlayerImpact>();
                Vector3 dir = rb.transform.position - transform.position;
                float force = Mathf.Clamp((explosionForce) / 3, 0, 15);

                impactReceiver.AddImpact(dir, force);
            }
            else
            {
                rb.AddExplosionForce(explosionForce, transform.position, r, 1, ForceMode.Impulse);
            }
        }
    }
}
