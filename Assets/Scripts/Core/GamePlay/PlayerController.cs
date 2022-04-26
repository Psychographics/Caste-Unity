using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LifeBase
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void OnDamage() {
        // throw new System.NotImplementedException();
    }

    public override void OnHeal() {
        // throw new System.NotImplementedException();
    }

    public override void OnDie() {
        
    }
}
