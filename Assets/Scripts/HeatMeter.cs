using UnityEngine;
using UnityEngine.UI;

public class HeatMeter : MonoBehaviour
{
    private bool m_burnOutTriggered = false;
    public float m_totalHeat = 0;
    public RectTransform m_meterRect;
    public Image m_meterImage;
    public GameObject m_highHeatWarning;
    public GameObject m_burnOutText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_highHeatWarning.SetActive(false);
        m_burnOutText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if burn out needs to be triggered
        CheckForBurnOut();
        if (Input.GetKey(KeyCode.LeftShift) && m_burnOutTriggered == false)//leftshift will be changed to whatever the boost button is
        {
            //increases heat over timewhile both the boost button is held and burnout isnt triggered
            m_totalHeat += Time.deltaTime *50;
        }
        else if(Input.GetKey(KeyCode.LeftShift)== false || m_burnOutTriggered == true) 
        {
            //decreases heat whenever the boost key is not being held or whenever a burn out is triggered
            m_totalHeat -= Time.deltaTime*25;
        }

        UpdateMeter();
        if (m_totalHeat < 0)
        {
            m_totalHeat = 0;
        }
        if(m_totalHeat > 100)
        {
            m_totalHeat = 100;
        }
    }
    public void CheckForBurnOut()
    {
        if(m_totalHeat >= 100)
        {
            m_totalHeat = 100;
            m_burnOutTriggered=true;
            m_burnOutText.SetActive(true);
            //add the function to disable boosting here
        }

        if(m_totalHeat <= 0 && m_burnOutTriggered == true)
        {
            m_burnOutTriggered = false;
            m_burnOutText.SetActive(false);
            m_totalHeat = 0;
            //add the function to reenable boosting here
        }
    }
    public void UpdateMeter()
    {
        m_meterRect.sizeDelta = new Vector2(20,Mathf.Lerp(0, 160, m_totalHeat/100));
        m_meterImage.color = Color.Lerp(Color.white, Color.red, m_totalHeat/100);   
        if (m_totalHeat >= 80)
        {
            m_highHeatWarning.SetActive(true);
        }
        if(m_totalHeat < 80)
        {
            m_highHeatWarning.SetActive(false);
        }
    }

}
