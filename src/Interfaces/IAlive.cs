namespace DH.ModifierSystem
{
	public interface IAlive
	{
		float Lifetime { get; }

        void Born();
        void Live();
		void Die();
        void Reset();

        void OnDead ();
	}
}