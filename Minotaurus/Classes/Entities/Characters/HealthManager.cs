using Minotaurus.Classes.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities.Characters
{
    public class HealthManager
    {
        public bool isDead { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public bool invurnerable { get; set; }
        private float _invulnerabilityTimer = 0;

        private const float _invulnerabilityDuration = 2;

        public HealthManager(int maxHealth)
        {
            isDead = false;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void Update(float deltaTime)
        {
            if (invurnerable)
            {
                _invulnerabilityTimer -= deltaTime;

                if (_invulnerabilityTimer <= 0)
                {
                    invurnerable = false;
                    _invulnerabilityTimer = 0;
                }
            }
        }
        public void InflictDamage(int damageAmount)
        {
            if(!invurnerable)
            {
                CurrentHealth -= damageAmount;

                if (CurrentHealth <= 0)
                {
                    MinoMaze.SoundEffects["Dead"].Play();
                    isDead = true;
                }
                else
                {
                    MinoMaze.SoundEffects["Damage"].Play();
                    invurnerable = true;
                    _invulnerabilityTimer = _invulnerabilityDuration;
                }
            }
            
        }

        public void AddHealth(int healthAmount)
        {
            MinoMaze.SoundEffects["PickUpHP"].Play();
            CurrentHealth++;
        }

        public void ResetHealth()
        {
            CurrentHealth = MaxHealth;
        }
    }

}
