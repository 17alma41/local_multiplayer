using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SnowPhantom", menuName = "Abilities/SnowPhantom")]
public class SnowPhantom : Ability
{
    public override void ActivateAbility(Vector3 position)
    {
        // Activar un efecto de partículas
        // ActivateEffects(position);
    }
}
