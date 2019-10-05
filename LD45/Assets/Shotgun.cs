using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "skills/shotgun")]
public class Shotgun : Skill
{
    public int Damage = 1;
    public int shotCount = 3;
    public int recoil = 10;



    public override void Initialize(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerAbility()
    {
        throw new System.NotImplementedException();
    }

}
