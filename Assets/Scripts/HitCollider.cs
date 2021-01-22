using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour{

    public string punchName;
    public float damage;
    public Fighter owner;

    void OnTriggerEnter(Collider other){
        Fighter somebody = other.gameObject.GetComponent<Fighter>();
        if (owner.attacking){
            if (somebody != null && somebody != owner){
                somebody.hurt(damage);
            }
        }
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
}