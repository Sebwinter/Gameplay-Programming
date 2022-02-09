using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armour;
    public Stat attackSpeed;
    public Stat spellDamage;
    public Stat range;

    private void Awake()
    {
        
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {

        damage -= armour.GetValue();   //would heal if armour makes the damage negative.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);  //stops negative values.
        
        currentHealth -= damage;
        Debug.Log(transform.name + " Takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();

        }
    }

    public void Heal(int damage)
    {
        if(currentHealth !=maxHealth)
        {
            damage = Mathf.Clamp(damage, 0, int.MaxValue);  //stops negative values.

            currentHealth += damage;
            Debug.Log(transform.name + " Heals for " + damage);


        }



    }

    public virtual void Die()
    {
        //death animation
        //drops loot?
        Debug.Log(transform.name +" Died.");

    }

    
}
