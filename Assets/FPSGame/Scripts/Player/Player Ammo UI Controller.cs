using TMPro;
using UnityEngine;

namespace FPSGame
{
    public class PlayerAmmoUIController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI ammoText;

        public void OnAmmoChanged(int currentAmmo, int maxAmmo)
        {
            ammoText.text = $"<color=red>{currentAmmo}</color>/{maxAmmo}";
        }
    }
}
