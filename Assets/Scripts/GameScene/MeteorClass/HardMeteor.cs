using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMeteor : Meteor
{
    public HardMeteor() : base("HM", 5)
    {
        
    }
    private void Awake()
    {
        spriteRenderer.color = Color.red;
    }
}
