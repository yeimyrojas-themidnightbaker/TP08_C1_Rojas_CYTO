using UnityEngine;
using UnityEngine.UI;

public class UIPowerUpTimers : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps playerPowerUps;
    [SerializeField] private Image damageBoostIcon;
    [SerializeField] private Image shieldIcon;
    [SerializeField] private Image extraJumpIcon;

    private void Update()
    {
        UpdateIcon(damageBoostIcon, playerPowerUps.DamageBoost);
        UpdateIcon(shieldIcon, playerPowerUps.Shield);
        UpdateIcon(extraJumpIcon, playerPowerUps.ExtraJump);
    }
    private void UpdateIcon(Image icon, TimedEffect effect)
    {
        // Suggestion: Hace SetActive y recalcula los tres íconos cada frame por polling. Podés exponer un evento en PlayerPowerUps al activar/terminar un efecto y solo actualizar fillAmount mientras esté activo.
        icon.gameObject.SetActive(effect.IsActive);
            if (!effect.IsActive)
            return;
            icon.fillAmount = effect.TimeRemain / effect.Duration;
    }
}
