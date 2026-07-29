using System.Collections.Generic;
using UnityEngine;


public class Explosion  : MonoBehaviour
{
    [SerializeField] private float _forc = 0;
    [SerializeField] float _radius = 0;
    [SerializeField] float _upwardsModifier = 0f; 

    public void Explode(Transform pointExplosion)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        Explode(pointExplosion, colliders);
    }

    public void Explode(Transform pointExplosion, IEnumerable<Collider> colliders)
    {
        foreach (Collider collider in colliders)
        {
            Explode(pointExplosion, collider);
        }
    }

    public void Explode(Transform pointExplosion, Collider collider)
    {
        Rigidbody rigidbody = collider.attachedRigidbody;

        if (rigidbody != null)
        {
            rigidbody.AddExplosionForce(_forc, pointExplosion.position, _radius, _upwardsModifier);
        }
    }
}
