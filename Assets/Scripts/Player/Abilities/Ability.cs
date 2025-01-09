using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    
    public string abilityName;
    public ParticleSystem particleEffect; // Aquí se mostrará el efecto de partículas
    public PlayerStats playerStats;

    // Método abstracto que deben implementar las habilidades
    public abstract void ActivateAbility(Vector3 position);

    public void SetPlayerStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    protected void ActivateEffects(Vector3 position)
    {
        // Crear las partículas en la posición dada
        ParticleSystem particle = Instantiate(particleEffect, position, Quaternion.identity);
        particle.Play();

    }
    

}
