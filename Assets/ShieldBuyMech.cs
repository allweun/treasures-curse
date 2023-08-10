using UnityEngine;
using UnityEngine.UI;

public class ShieldBuyMech : MonoBehaviour
{
    public Button[] ShieldLevel;
    public Image[] Solded;
    public int[] ShieldLevelValues;
    private int MoneyAmount;
    private int ExShield = 0;
    public Text ctext;
    public Image[] Lock;
    public bool[] sold;
    private string prefAttack = "prefShield";
    public Text[] valueText;
    void Start()
    {
        ExShield = PlayerPrefs.GetInt("exShield");
        MoneyAmount = PlayerPrefs.GetInt("coins");
        if (!PlayerPrefs.HasKey(TreasureCurseConst.ShieldLevelConstant))
            PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 0);
        for (int i = 0; i < sold.Length; i++)
        {
            bool a = false;
            string TempPrefAttack = prefAttack + i.ToString();
            if (PlayerPrefs.GetInt(TempPrefAttack) == 1)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            sold[i] = a;
        }
        for (int i = 0; i < ShieldLevelValues.Length; i++)
        {
            valueText[i].text = ShieldLevelValues[i].ToString();
        }
        ctext.text = PlayerPrefs.GetInt("coins").ToString();

    }
    void Update()
    {
        for (int i = 0; i < sold.Length; i++)
        {
            int a = 0;
            string TempPrefAttack = prefAttack + i.ToString();
            if (sold[i] == true)
            {
                a = 1;
            }
            else { a = 0; }
            PlayerPrefs.SetInt(TempPrefAttack, a);
        }
        for (int i = 0; i < ShieldLevel.Length; i++)
        {
            if (sold[i] == true)
            {
                Solded[i].gameObject.SetActive(true);
                Lock[i].gameObject.SetActive(false);
            }
            else
            {
                Lock[i].gameObject.SetActive(true);
                Solded[i].gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 0)
        {
            if (MoneyAmount >= ShieldLevelValues[0])
            {
                ShieldLevel[0].interactable = true;
                Lock[0].gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 1)
        {
            if (MoneyAmount >= ShieldLevelValues[1])
            {
                ShieldLevel[1].interactable = true;
                Lock[1].gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 2)
        {
            if (MoneyAmount >= ShieldLevelValues[2])
            {
                ShieldLevel[2].interactable = true;
                Lock[2].gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 3)
        {
            if (MoneyAmount >= ShieldLevelValues[3])
            {
                ShieldLevel[3].interactable = true;
                Lock[3].gameObject.SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 4)
        {
            if (MoneyAmount >= ShieldLevelValues[4])
            {
                ShieldLevel[4].interactable = true;
                Lock[4].gameObject.SetActive(false);
            }
        }

        PlayerPrefs.SetInt("coins", MoneyAmount);
        PlayerPrefs.SetInt("exShield", ExShield);
        ctext.text = PlayerPrefs.GetInt("coins").ToString();
    }
    public void SoldLevel(int levelNum)
    {
        if (levelNum == 1)
        {
            if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 0)
            {
                ShieldLevel[0].interactable = false;
                Lock[0].gameObject.SetActive(false);
                Solded[0].gameObject.SetActive(true);
                MoneyAmount -= ShieldLevelValues[0];
                ExShield += 10;
                PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 1);
                sold[0] = true;
            }
        }
        if (levelNum == 2)
        {
            if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 1)
            {
                ShieldLevel[1].interactable = false;
                Lock[1].gameObject.SetActive(false);
                Solded[1].gameObject.SetActive(true);
                MoneyAmount -= ShieldLevelValues[1];
                ExShield += 10;
                PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 2);
                sold[1] = true;
            }
        }
        if (levelNum == 3)
        {
            if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 2)
            {
                ShieldLevel[2].interactable = false;
                Lock[2].gameObject.SetActive(false);
                Solded[2].gameObject.SetActive(true);
                MoneyAmount -= ShieldLevelValues[2];
                ExShield += 10;
                PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 3);
                sold[2] = true;
            }
        }
        if (levelNum == 4)
        {
            if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 3)
            {
                ShieldLevel[3].interactable = false;
                Lock[3].gameObject.SetActive(false);
                Solded[3].gameObject.SetActive(true);
                MoneyAmount -= ShieldLevelValues[3];
                ExShield += 10;
                PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 4);
                sold[3] = true;
            }
        }
        if (levelNum == 5)
        {
            if (PlayerPrefs.GetInt(TreasureCurseConst.ShieldLevelConstant) == 4)
            {
                ShieldLevel[4].interactable = false;
                Lock[4].gameObject.SetActive(false);
                Solded[4].gameObject.SetActive(true);
                MoneyAmount -= ShieldLevelValues[4];
                ExShield += 10;
                PlayerPrefs.SetInt(TreasureCurseConst.ShieldLevelConstant, 5);
                sold[4] = true;
            }
        }
    }

}
