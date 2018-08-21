using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamagable : MonoBehaviour {
    
    public ParticleSystem ps;

    private List<ParticleSystem.Particle> plist = new List<ParticleSystem.Particle>();


    private void OnParticleTrigger()
    {
        int num = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, plist);
        
        for(int i = 0; i < num; ++i)
        {
            ParticleSystem.Particle p = plist[i];
            p.remainingLifetime = 0;
            plist[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, plist);
    }

}
