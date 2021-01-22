using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public Slider healthSlider;

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Health;
    }

    public void GetDamage(float amount)
    {
        Health -= amount;
     
    }
}
