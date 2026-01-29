using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI ammoText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateAmmoText(int currentAmmo, int spareRounds)
    {
        ammoText.text = $"Bullets: {currentAmmo} / {spareRounds}";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
