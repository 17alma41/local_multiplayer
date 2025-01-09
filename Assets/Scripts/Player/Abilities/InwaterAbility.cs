using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InwaterAbility", menuName = "Abilities/InwaterAbility")]
public class InwaterAbility : Ability
{

    public override void ActivateAbility(Vector3 position)
    {
        // Activar un efecto de partículas
        ActivateEffects(position);
    }
}
