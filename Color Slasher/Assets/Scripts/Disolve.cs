using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    //4096
    ParticleSystem ps;
    ParticleSystem.Particle[] particles;

    void awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
        
    }

    void Start()
    {
        ps.GetParticles(particles);
        int numParticlesAlive = ps.GetParticles(particles);
        for (int i = 0; i< numParticlesAlive; i++)
        {
            particles[i].position = new Vector3(i, 0, 0);
        }

        
        ps.SetParticles(particles, numParticlesAlive);
    }

    
    void Update()
    {
        
    }
}
