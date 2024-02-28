using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth{
    public int CurrentHealth { get; set; }
}
public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int currentHealth;
    public int CurrentHealth { get{return currentHealth;} set{currentHealth = value;}}

}
