
using UnityEngine;

public interface IDamagable
{
    string name { get; }
    float damageAmount { get; }
    bool isDestructible { get; }
    
    
}
