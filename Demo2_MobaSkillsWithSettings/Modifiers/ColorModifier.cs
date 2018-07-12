using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    public class ColorModifier : Modifier<Character>
    {
        public override void Modify(Character modifiable)
        {
            modifiable.SetColor(Color.red);
        }

        public override void Revert(Character modifiable)
        {
            modifiable.SetColor(Color.white);
        }
    }
}
