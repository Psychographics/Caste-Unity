using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeBase : MonoBehaviour
{

    public int totalHp;

    private int currentHp;

    // Start is called before the first frame update
    protected void Start()
    {
        currentHp = totalHp;
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public void ApplyDamage(int damagePoints)
    {
        currentHp -= damagePoints;
        OnDamage();
        
        if (currentHp <= 0) {
            OnDie();
        }
    }

    public void ApplyHeal(int healPoints)
    {
        currentHp += healPoints;
        OnHeal();
        
        if (currentHp <= 0) {
            OnDie();
        }
    }
    
    public abstract void OnDamage();
    public abstract void OnDie();
    public abstract void OnHeal();
}
