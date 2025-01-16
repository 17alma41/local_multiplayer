using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AllocatorSkills allocatorSkills; 
    [SerializeField] private SkillManager skillManager;

    void Start()
    {
        //if (allocatorSkills != null && skillManager != null)
        //{
        //    allocatorSkills.currentAbility.SetPlayerStats(allocatorSkills.playerStats);
        //}
    }

    void Update()
    {
        // Verificar la entrada del jugador para activar la habilidad
        if (allocatorSkills.currentAbility != null && Input.GetKeyDown(KeyCode.Space))
        {
            UseAbility();
        }
    }

    void UseAbility()
    {
        // Notificar al SkillManager que el jugador ha usado su habilidad
        skillManager.OnPlayerUseAbility(allocatorSkills);

        if (allocatorSkills.currentAbility != null)
        {
            allocatorSkills.currentAbility.ActivateAbility(transform.position);
        }
    }
}
