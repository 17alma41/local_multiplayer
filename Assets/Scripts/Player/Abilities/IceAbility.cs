using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceAbility", menuName = "Abilities/IceAbility")]
public class IceAbility : Ability
{
    public override void ActivateAbility(Vector3 position)
    {
        // Activar un efecto de part�culas
        // ActivateEffects(position);
    }
}
