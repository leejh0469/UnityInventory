using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
    [Header("Player Stat UI Component")]
    [SerializeField] private TextMeshProUGUI playerGoldText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private GameObject playerStatUIWindow;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenceText;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Player Level UI")]
    [SerializeField] private Image expBar;

    // Start is called before the first frame update
    void Start()
    {
        playerStatUIWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAllUI(PlayerStat playerStat)
    {
        SetPlayerName(playerStat.Name);
        SetPlayerLevel(playerStat.Level);
        SetPlayerGold(playerStat.Gold);
        SetPlayerStat(playerStat.Attack, playerStat.Defence, playerStat.Health);
        SetExpBar(playerStat.Exp, playerStat.RequireForLevelUp);
    }

    public void SetPlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void SetPlayerLevel(int level)
    {
        playerLevelText.text = level.ToString();
    }

    public void SetPlayerGold(int playerGold)
    {
        playerGoldText.text = playerGold.ToString();
    }

    public void SetPlayerStat(float attack, float defence, int health)
    {
        attackText.text = attack.ToString();
        defenceText.text = defence.ToString();
        healthText.text = health.ToString();
    }

    public void SetExpBar(int curExp, int levelUpValue)
    {
        expBar.fillAmount = curExp / levelUpValue;
    }
}
