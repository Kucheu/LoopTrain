using UnityEngine;

public class DamageUIManager : MonoBehaviourSingleton<DamageUIManager>
{
    [SerializeField]
    private DamageUI damageUIPrefab;

    public void ShowDamage(Vector3 position, int damage)
    {
        var damageUi = Instantiate(damageUIPrefab, Camera.main.WorldToScreenPoint(position), Quaternion.identity, transform);
        damageUi.SetText(damage.ToString());
    }
}
