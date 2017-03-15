using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using UnityEngine;
public abstract class AbstractEnemy : MonoBehaviour, IPoolObj
{
    [HideInInspector]
    public EnemyBase dataPeople;

    public Animation mainAnim;
    [SerializeField]
    protected EnemyComponents[] arrEnemyComponents;
    [SerializeField]
    protected string nameAnimRun;
    [SerializeField]
    protected string nameAnimAttack;
    [SerializeField]
    protected string nameAnimTakeDown;
    [SerializeField]
    protected string nameAnimDeath;
    [SerializeField]
    protected string nameAnimIdle;
    protected GameManager gameManager;

    protected float timeWait;
    [HideInInspector]
    public ENEMY_PHAZE phaze;
    [SerializeField]
    protected string parTakeDamage;
    [SerializeField]
    protected string parDeath;

    protected bool isFullHp;
    protected bool isFirstAttack;
    void Start()
    {

    }

    protected virtual void Setup(GameManager gameManager, EnemyBase data)
    {
        this.gameManager = gameManager;
        this.dataPeople = data.Clone();
        isFirstAttack = true;
        isFullHp = true;
        timeWait = UnityEngine.Random.Range(0, 5f);
    }

    public void GetHit(EnemyComponents component, int damage, Vector3 hitPoint, bool isGrenade)
    {

        if (component.typeComponent == TYPE_COMPONENT_ENEMY.HEADER)
        {
            GetHit(damage * 2, hitPoint, isGrenade);
            Debug.Log("get hit: head: " + dataPeople.hp);
        }
        else if (component.typeComponent == TYPE_COMPONENT_ENEMY.BODY)
        {
            GetHit(damage, hitPoint, isGrenade);
            Debug.Log("get hit: body: " + dataPeople.hp);

        }



    }

    public void GetHit(int damage, bool isGrenade)
    {
        GetHit(damage, transform.position, isGrenade);
    }

    public virtual void GetHit(int damage, Vector3 hitPoint, bool isGrenade)
    {
        if (phaze == ENEMY_PHAZE.PLAY)
        {
            Debug.Log("Enemy: " + gameObject.name + " take damge: " + hitPoint);
            dataPeople.hp -= damage;
            isFullHp = false;
            if (dataPeople.hp <= 0)
            {
                SoundManager.Instance.Play("enemyPain1");
                ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("BigBlood")).GetComponent<ParticleSystem>();
                ps.transform.position = hitPoint;
                ps.Play();


                AutoPool.AttackPool(ps.gameObject, ps.duration);

                Dying();
            }
            else
            {
                SoundManager.Instance.Play("enemyPain1");
                ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("SmallBlood")).GetComponent<ParticleSystem>();
                ps.transform.position = hitPoint;
                ps.Play();
                AutoPool.AttackPool(ps.gameObject, ps.duration);
                StartCoroutine(IETakeDamage());
            }
        }
        else if (isGrenade)
        {
            dataPeople.hp -= damage;
            isFullHp = false;
            if (dataPeople.hp < 0)
            {
                ParticleSystem ps = PoolManager.SpawnObject(PoolPrefabLookupManager.LookPrefab("BigBlood")).GetComponent<ParticleSystem>();
                ps.transform.position = hitPoint;
                ps.Play();


                AutoPool.AttackPool(ps.gameObject, ps.duration);

                Dying();
            }
        }

    }

    IEnumerator IETakeDamage()
    {
        {
            AnimationClip clip = mainAnim.GetClip(nameAnimTakeDown);
            mainAnim.clip = clip;
            mainAnim.CrossFade(nameAnimTakeDown);

            yield return new WaitForSeconds(clip.length);
        }

        {
            AnimationClip clip = mainAnim.GetClip(nameAnimIdle);
            clip.wrapMode = WrapMode.Loop;
            mainAnim.clip = clip;
            mainAnim.CrossFade(nameAnimIdle);
            
            yield return new WaitForSeconds(clip.length);
        }
    }

    public abstract void Dying();

    public virtual void Reset()
    {

    }
}

