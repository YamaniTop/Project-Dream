using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Behaviors { Idle, Battle, Flee, Guard }; // добавил Guard

public class AI_Main : MonoBehaviour
{
    public Behaviors aiBehaviors = Behaviors.Idle;
    public bool IsSus = false;
    public bool isInRange = false;
    public bool FightsRanged = false;
    public List<KeyValuePair<string, int>> Stats = new
    List<KeyValuePair<string, int>>();
    public GameObject Projectile;
    void ExecBehaviors()
    {
        switch (aiBehaviors)
        {
            case Behaviors.Idle:
                ExecIdleNode();
                break;
            case Behaviors.Battle:
                ExecBattleNode();
                break;
            case Behaviors.Flee:
                ExecFleeNode();
                break;
        }
    }
    void ChangeBehaviors(Behaviors newBehavior)
    {
        aiBehaviors = newBehavior;
    }
    void ExecIdleNode()
    {
        Idle();
    }
    void ExecBattleNode()
    {
        if (FightsRanged)
        {
            RangedAttack();
        }
        else
        {
            MeleeAttack();  //Исправлено название функции
        }
    }
    void ExecFleeNode()
    {
        Flee();
    }
    void Idle()
    {

    }
    void Battle() // у вас не вызывается функция Battle, потому что она не вызывается в цикле ExecBehaviors, исправьте это в другом скрипте
    {
        if (isInRange)
        {
            if (FightsRanged)
            {
                RangedAttack();
            }
            else
            {
                SearchForTarget(); // Исправлено название функции
            }
        }
        else
        {
            SearchForTarget();
        }
    }
    void Flee()
    {

    }
    void RangedAttack()
    {
        GameObject newProjectile;
        newProjectile = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject; //Исправлено название класса + убрал as GameObject (не нужно в новых версиях Unity)
    }
    void MeleeAttack()
    {

    }
    void SearchForTarget()
    {

    }
    void ChangeHealth(int Amount) //Исправлена опечатка в названии параметра
    {
        if (Amount < 0)
        {
            if (!IsSus)
            {
                IsSus = true;
                ChangeBehaviors(Behaviors.Guard); //Нужно Guard
            }
        }
        for (int i = 0; i < Stats.Capacity; i++)
        {
            if (Stats[i].Key == "Health")
            {
                int tempValue = Stats[i].Value;
                Stats[i] = new KeyValuePair<string, int>(Stats[i].Key, tempValue + Amount); //Исправлен оператор +=
                if (Stats[i].Value <= 0)
                {   //Заменен isInRange на if
                    Destroy(gameObject);

                }
                else if (Stats[i].Value < 25)
                {
                    IsSus = false;
                    ChangeBehaviors(Behaviors.Flee);
                }
                break;
            }
        }
    }
    void ModifyStat(string Stat, int Amount) //Исправлена опечатка в названии параметра
    {
        for (int i = 0; i < Stats.Capacity; i++)
        {
            if (Stats[i].Key == Stat)
            {
                int tempValue = Stats[i].Value;
                Stats[i] = new KeyValuePair<string, int>(Stat, tempValue + Amount); //Исправлен оператор +=
                break;
            }
        }
        if (Amount < 0)
        {
            if (!IsSus)
            {
                IsSus = true;
                ChangeBehaviors(Behaviors.Idle);
            }
        }
    }

}