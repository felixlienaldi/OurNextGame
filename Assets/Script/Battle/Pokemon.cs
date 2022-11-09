using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pokemon : MonoBehaviour
{
    public PokemonData data;
    [HideInInspector] public int health;
    [HideInInspector] public int attack;
    [HideInInspector] public int defense;

    public void Init(int health, int attack, int defense) {
        this.health = health;
        this.attack = attack;
        this.defense = defense;
    }

    void Start() {
        Init(data.health, data.attack, data.defense);
    }
}
