using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _forc = 0;
    [SerializeField] float _radius = 0;
    [SerializeField] float _upwardsModifier = 0f; 

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_forc, transform.position, _radius, _upwardsModifier);
            }
        }
    }
}
