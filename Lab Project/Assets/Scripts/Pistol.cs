using UnityEngine;

public class Pistol : Weapon
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        firePoint = transform.Find("FirePoint").transform;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //GetMouseButtonDown(0) GetButtonDown("Fire 1")
        {
            Shoot();
        }
        
    }

    public override void Shoot()
    {
        Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * range;
        Vector3 shootDirection = (targetPosition - firePoint.position).normalized;

        Debug.DrawRay(firePoint.position, shootDirection * range, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, shootDirection, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
