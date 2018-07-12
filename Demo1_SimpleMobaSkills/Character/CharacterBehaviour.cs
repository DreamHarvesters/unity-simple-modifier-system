using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Renderer renderer;

        private CharacterData data;
        private Character character;

        private Skill skill;

        void Start()
        {
            data = new CharacterData();
            data.RotationSpeed = 5;
            data.CharacterColor = Color.white;

            //AliveModifier uses System.Timer which creates a different thread
            //Unity functions can only be accessed/modified in main thread
            //This is why a dispatcher must be used in observable approach
            //data.OnColorChanged += (Color obj) => renderer.material.color = obj;

            skill = new Skill();
            character = new Character(data);
        }

        void Update()
        {
            transform.Rotate(Vector3.up * data.RotationSpeed, Space.World);
            renderer.material.color = data.CharacterColor;
        }

        public void ActivateSkill()
        {
            skill.Activate(character);
        }
    }
}
