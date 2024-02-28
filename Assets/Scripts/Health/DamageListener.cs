using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageListener{
    public void Damage();
}
public class DamageListener : MonoBehaviour, IDamageListener
{
    [SerializeField] private UnityEvent onDamage;
    
    public void Damage(){
        onDamage?.Invoke();
    }

}
