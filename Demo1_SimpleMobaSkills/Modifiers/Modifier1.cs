using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class Modifier1 : Modifier<Character>
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
