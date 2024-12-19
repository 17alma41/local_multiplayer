using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] List<Ability> abilitiesList;
    [SerializeField] AllocatorSkills[] players;    // Referencia a los jugadores que tienen habilidades

    private List<Ability> commonSkills = new List<Ability>();

    void Start()
    {
        AssignRandomSkill();
    }

    void Update()
    {
        
    }

    // Asignar habilidad aleatoria
    private void AssignRandomSkill()
    {
        List<Ability> availableSkills = new List<Ability>(abilitiesList);

        for (int i = 0; i < players.Length; i++)
        {
            AllocatorSkills player = players[i];

            // Asignar una habilidad aleatoria
            int abilityIndex = Random.Range(0, abilitiesList.Count);
            Ability chosenSkill = abilitiesList[abilityIndex];

            player.currentAbility = chosenSkill;

            // Eliminar la habilidad de la lista para no repetirla
            abilitiesList.RemoveAt(abilityIndex);
        }
    }

    public void OnPlayerUseAbility(AllocatorSkills player)
    {
        commonSkills.Add(player.currentAbility); // La habilidad usada pasa al fondo común

        player.currentAbility = null; // Elimina la habilidad usada

        if(commonSkills.Count > 0)
        {
            int randomIndex = Random.Range(0, commonSkills.Count);
            Ability newSkill = commonSkills[randomIndex];

            player.currentAbility = newSkill;

            commonSkills.RemoveAt(randomIndex);
        }
    }

}
