using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePointAttractor : MonoBehaviour {

    public float force;
    public ParticleSystem ps;

    private ParticleSystem.Particle[] parray = new ParticleSystem.Particle[0];

    private void Update()
    {
        if(parray.Length < ps.particleCount)
        {
            parray = new ParticleSystem.Particle[ps.particleCount];
        }
        int num = ps.GetParticles(parray);

        for(int i = 0; i < num; ++i)
        {
            parray[i].velocity += (transform.position - parray[i].position).normalized * force
                * Time.deltaTime;
        }

        ps.SetParticles(parray, num);
    }

}
