using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class Modifier2 : Modifier<Character>
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
