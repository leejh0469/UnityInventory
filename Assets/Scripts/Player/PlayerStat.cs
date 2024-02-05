using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public string Name {  get; set; }

    public int Gold { get; set; }

    public int Exp {  get; set; }

    public int RequireForLevelUp {  get; set; }

    public int Level { get; set; }

    public float Attack {  get; set; }

    public float Defence { get; set; }

    public int Health { get; set; }


    [SerializeField] private PlayerStatUI _playerStatUI;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Name = "Chad";
        Gold = 1000000;
        Exp = 0;
        RequireForLevelUp = 10;
        Level = 1;
        Attack = 10;
        Defence = 10;
        Health = 100;

        _playerStatUI.UpdateAllUI(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAttackValue(float value)
    {
        Attack += value;
        _playerStatUI.SetPlayerStat(Attack, Defence, Health);
    }

    public void SubtractAttackValue(float value)
    {
        Attack -= value;
        _playerStatUI.SetPlayerStat(Attack, Defence, Health);
    }

    public void AddDefenceValue(float value)
    {
        Defence += value;
        _playerStatUI.SetPlayerStat(Attack, Defence, Health);
    }

    public void SubtractDefenceValue(float value)
    {
        Defence -= value;
        _playerStatUI.SetPlayerStat(Attack, Defence, Health);
    }
}
