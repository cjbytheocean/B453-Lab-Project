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
    [SerializeField] PlayerController pc;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    { 
        pc = GetComponentInParent<PlayerController>();
        UIManager.Instance.UpdateAmmoText(bulletCount, pc.spareRounds);  
    }

    public virtual void Shoot()
    {
        if (bulletCount < 0)
        {
            return;
        }
         UIManager.Instance.UpdateAmmoText(bulletCount, pc.spareRounds);
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
