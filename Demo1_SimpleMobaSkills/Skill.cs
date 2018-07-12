using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class Skill
    {
        private Modifier<Character>[] modifiers;

        public Skill()
        {
            modifiers = new Modifier<Character>[] { new Modifier1(), 
                new AliveModifier<Character> (new Modifier2(), 2)};
        }

        public void Activate(Character character)
        {
            foreach(var modifier  in modifiers)
            {
                modifier.Modify(character);
            }
        }
    }
}
