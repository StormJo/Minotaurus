using Minotaurus.Classes.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaurus.Classes.Entities
{
    public class HealthManager
    {
        public bool isDead { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public HealthManager(int maxHealth)
        {
            isDead = false;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void InflictDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                isDead = true;
            }
        }

        public void ResetHealth()
        {
            CurrentHealth = MaxHealth;
        }
    }

}
