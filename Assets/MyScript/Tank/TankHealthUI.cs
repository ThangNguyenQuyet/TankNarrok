using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider m_HealthSlider;
    [SerializeField]
    private Image m_FillImage;
    [SerializeField]
    private Color m_FullHealthColor = Color.green;
    [SerializeField]
    private Color m_ZeroHealthColor = Color.red; 

    // Start is called before the first frame update
    public void SetHealUI(float m_MaxHealth,float m_CurrentHealth)
    {
        Debug.Log("Call fix health");
        m_HealthSlider.value= (m_CurrentHealth / m_MaxHealth)*100;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_MaxHealth);
    }
}
