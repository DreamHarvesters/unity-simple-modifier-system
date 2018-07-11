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

            timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Die();
        }

        void KillTimer()
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();
            timer.Dispose();
        }

        public override void Modify(ModifiableType modifiable)
        {
            originalModifier.Modify(modifiable);

            SetupTimer();

            this.modifiable = modifiable;
            
            modifiable.OnModificationApplied(this);
        }

        public float Lifetime { get { return lifetime; } }

        public void Born(){}
        public void Live(){}
        public void Die()
        {
            KillTimer();

            OnDead();
        }

        public void Reset()
        {
            KillTimer();

            SetupTimer();
        }

        public void OnDead()
        {
            Revert(modifiable);
        }
    }
}
