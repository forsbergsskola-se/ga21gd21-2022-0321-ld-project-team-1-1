using UnityEngine;
using UnityEngine.VFX;

public class LaserVFXController : MonoBehaviour
{
    [SerializeField] private LineRenderer laserBeamLine;
    [SerializeField] private VisualEffect laserSparksVFX;

    // [SerializeField] private VisualEffect laserBeamVFX;
    // [SerializeField] private float laserParticleSpeed = 100f;
    [SerializeField] private float maxLaserDistance = 100f;

    // private void OnEnable()
    // {
    //     laserBeamVFX.SetFloat("ParticleSpeed", laserParticleSpeed);
    // }

    private void Update()
    {
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        // laserBeamVFX.SetFloat("ParticleSpeed", laserParticleSpeed); //Could be moved to OnEnable/Start for performance improvement.

        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, maxLaserDistance)) //Do we hit something?
        {
            // laserBeamVFX.SetFloat("ParticleLifetime", hitInfo.distance / laserParticleSpeed);

            //Set the end position in the LineRenderer.
            SetLaserDistance(hitInfo.distance);

            SetLaserSparksVFXData(hitInfo.point, hitInfo.normal);
            laserSparksVFX.Play();
        }
        else //Here we're not hitting anything.
        {
            // laserBeamVFX.SetFloat("ParticleLifetime", maxLaserDistance / laserParticleSpeed);
            SetLaserDistance(maxLaserDistance);
            laserSparksVFX.Stop();
        }
    }

    private void SetLaserDistance(float distance)
    {
        laserBeamLine.SetPosition(1, Vector3.forward * distance);
    }

    private void SetLaserSparksVFXData(Vector3 position, Vector3 normal)
    {
        //Change position and rotation of sparks gameObject to use for local calculations in the VFX graph.
        laserSparksVFX.transform.position = position;
        laserSparksVFX.transform.forward = normal;

        //Set VFX graph values for the sparks.
        laserSparksVFX.SetVector3("SpawnPosition", position);
        laserSparksVFX.SetVector3("SpawnNormal", normal);
    }
}