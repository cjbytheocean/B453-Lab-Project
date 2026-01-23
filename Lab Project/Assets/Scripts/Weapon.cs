using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] float bulletCount = 20;
    [SerializeField] int maxCapacity = 20;
    [SerializeField] TMP_Text countText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        countText.text = maxCapacity.ToString();
        
    }

    public virtual void Shoot()
    {
        float remaining = maxCapacity - bulletCount;
        countText.text = remaining.ToString();
        bulletCount--;
    }

    public virtual void Reload()
    {
        bulletCount = 20;
    }
}
