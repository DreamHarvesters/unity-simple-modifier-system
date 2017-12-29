using UnityEngine;
using System.Collections;
using System.Timers;

namespace DH.ModifierSystem
{
    public class AliveModifier<ModifiableType> : DecoratedModifier<ModifiableType>, IAlive where ModifiableType : IModifiable
    {
        private ModifiableType modifiable;
        private float lifetime;
        private Timer timer;

        public AliveModifier(Modifier<ModifiableType> originalModifier, float lifetime) : base(originalModifier)
        {
            this.lifetime = lifetime;
        }

        void SetupTimer()
        {
            timer = new Timer(lifetime * 1000);
			
            timer.Start();

            timer.Elapsed += (sender, e) => Die();
        }

        void KillTimer()
        {
            timer.Stop();
        }

        public override void Modify(ModifiableType modifiable)
        {
            originalModifier.Modify(modifiable);

            SetupTimer();

            this.modifiable = modifiable;
        }

        public override void Revert(ModifiableType modifiable)
        {
            base.Revert(modifiable);
        }

        public float Lifetime { get { return lifetime; } }

        public void Born(){}
        public void Live(){}
        public void Die()
        {
            KillTimer();

            OnDead();
        }

        public void OnDead()
        {
            Revert(modifiable);
        }
    }
}
