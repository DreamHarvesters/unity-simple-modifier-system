using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    public class RotationSpeedModifier : Modifier<Character>
    {
        public override void Modify(Character modifiable)
        {
            modifiable.SetRotationSpeed(10);
        }

        public override void Revert(Character modifiable)
        {
            modifiable.SetRotationSpeed(5);
        }
    }
}
