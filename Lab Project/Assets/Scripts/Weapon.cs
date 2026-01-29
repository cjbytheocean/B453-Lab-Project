using TMPro;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    public int bulletCount = 20;
    public int maxCapacity = 20;
    [SerializeField] TMP_Text countText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    { 
        
    }

    public virtual void Shoot()
    {
        float remaining = maxCapacity - bulletCount;
        countText.text = remaining.ToString();
        bulletCount--;
    }

    public virtual int Reload(int spareRounds)
    {
        if (spareRounds + bulletCount >= maxCapacity)
        {
            spareRounds -= maxCapacity - bulletCount;
            bulletCount = maxCapacity;
            return spareRounds;
        }
        else
        {
            bulletCount += spareRounds;
            return 0; 
        }
    }
}
