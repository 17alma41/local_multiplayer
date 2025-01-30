using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankAbility", menuName = "Abilities/TankAbility")]
public class TankAbility : Ability
{
    public override void ActivateAbility(Vector3 position)
    {
        // Activar un efecto de partículas
        // ActivateEffects(position);
    }
}
