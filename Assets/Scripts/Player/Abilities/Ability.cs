using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    
    public string abilityName;
    public ParticleSystem particleEffect; // Aqu� se mostrar� el efecto de part�culas
    public PlayerStats playerStats;

    // M�todo abstracto que deben implementar las habilidades
    public abstract void ActivateAbility(Vector3 position);

    //public void SetPlayerStats(PlayerStats stats)
    //{
    //    playerStats = stats;
    //}

    protected void ActivateEffects(Vector3 position)
    {
        // Crear las part�culas en la posici�n dada
        ParticleSystem particle = Instantiate(particleEffect, position, Quaternion.identity);
        particle.Play();

    }
    

}
