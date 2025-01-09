using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllocatorSkills : MonoBehaviour
{
    public PlayerStats playerStats;
    public Ability currentAbility;  // Habilidad asignada al jugador

    [SerializeField] KeyCode keyActivationSkill;  
    private SkillManager skillManager; 

    private void Start()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyActivationSkill) && currentAbility != null)
        {
            ActivateAbility();  
        }
    }

    private void ActivateAbility()
    {
        if (currentAbility != null)
        {
            currentAbility.ActivateAbility(transform.position);

            // Notificar al SkillManager que el jugador ha usado una habilidad
            skillManager.OnPlayerUseAbility(this);
        }
    }
}
