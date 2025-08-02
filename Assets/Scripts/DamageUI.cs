using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI damageText;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;

    private float currentTime;

    public void SetText(string damage)
    {
        damageText.text = damage;
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        currentTime += Time.deltaTime;
        if(currentTime > time)
        {
            Destroy(gameObject);
        }
    }
}