using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour {
    public GameObject Death_Pre;
	private EnemyInfo enemyInfo;
	public new Animation animation;
	private CharacterController cc;
	private Transform player;
	private ShowAttack enemyShow;
	private AnimationStates emenyState = AnimationStates.Idle;
	public AnimationStates EnemyState
	{
		get
		{
			return emenyState;
		}

		set
		{
			emenyState = value;
		}
	}
	private bool isIdel = false;
	//计时器
	private float PatrolTimer = 0;
	private float patrolTimer = 0;
	private float attackTimer = 0;

	void Start () {
		cc = GetComponent<CharacterController>();
		enemyShow =GetComponent<ShowAttack>();
		animation = GetComponent<Animation>();
		player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Transform>();
		PatrolTimer = 2f;
		patrolTimer = PatrolTimer;
	}
	private void Update()
	{
        if (EnemyState == AnimationStates.Death)
            return;
        else if (EnemyState == AnimationStates.Attack)
        {
            if(player.GetComponent<PlayerAttack>().PlayerState==AnimationStates.Death)
            {
                EnemyState = AnimationStates.Idle;
            }
            if (Vector3.Distance(transform.position, player.position) < enemyInfo.MinAttackDistance)
            {
                attackTimer += Time.deltaTime;
                if(attackTimer < enemyInfo.AttackSpeed && isIdel == false)
                {
                    PlayAnim("Idle");
                }
                else if (attackTimer >= enemyInfo.AttackSpeed&& isIdel==false)
                {
                    attackTimer = 0;
                    isIdel = true;
                    PlayAnim("Attack1");
                }
                else if (isIdel == true)
                {
                    if (attackTimer >= enemyInfo.AttackAnimTime)
                    {
                        player.SendMessage("GetAttack", enemyInfo.Damage);
                        attackTimer = 0;
                        isIdel = false;
                        PlayAnim("Idle");
                    }
                }
            }
            else if (Vector3.Distance(transform.position, player.position) > enemyInfo.LeaveDistance)
            {
                PlayAnim("Idle");
                EnemyState = AnimationStates.Idle;
            }
            else
            {
                PlayAnim("Walk");
                transform.LookAt(player);
                cc.SimpleMove((player.position - transform.position).normalized * enemyInfo.MoveSpeed);
            }
        }
        else
        {
            if (EnemyState == AnimationStates.Move)
            {
                cc.SimpleMove(transform.forward * enemyInfo.MoveSpeed);
            }
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= PatrolTimer)
            {
                patrolTimer = 0;
                int x = UnityEngine.Random.Range(0, 2);
                if (x == 0)
                {
                    PlayAnim("Idle");
                    EnemyState = AnimationStates.Idle;
                }
                else
                {
                    PlayAnim("Walk");
                    transform.Rotate(transform.up * UnityEngine.Random.Range(0, 360));
                    EnemyState = AnimationStates.Move;
                }
            }
        }
	}
	private void GetAttack(int hp)
	{
		if (EnemyState == AnimationStates.Death)
			return;
		emenyState = AnimationStates.Attack;
        transform.LookAt(player);
		if (UnityEngine.Random.Range(1, 11) / (double)10 <= enemyInfo.MissPrecent)
		{
			enemyShow.ShowAttackMsg("Miss", Color.green);
		}
		else
		{
            PlayAnim("TakeDamage1");
            enemyInfo.Hp -= hp;
			enemyShow.ShowAttackMsg(" - " + hp, Color.red);
		}
		if (enemyInfo.Hp <= 0)
		{
            PlayAnim("Death");
            EnemyState = AnimationStates.Death;
			PlayerStatusManager.Instance.AddExp(enemyInfo.Exp);
            GameObject go= GameObject.Instantiate(Death_Pre, transform.position, transform.rotation);
            go.GetComponent<EnemyDeath>().Death(enemyInfo.EnemyType);
			Destroy(this.gameObject);
		}
	}
	private void PlayAnim(string animName)
	{
		animation.CrossFade(animName);
	}
	public void SetEnemyInfo(EnemyInfo enemyInfo)
	{
        this.enemyInfo = new EnemyInfo();
        this.enemyInfo.EnemyID = enemyInfo.EnemyID;
        this.enemyInfo.EnemyName = enemyInfo.EnemyName;
        this.enemyInfo.EnemyType = enemyInfo.EnemyType;
        this.enemyInfo.Hp = enemyInfo.Hp;
        this.enemyInfo.Exp = enemyInfo.Exp;
        this.enemyInfo.Damage = enemyInfo.Damage;
        this.enemyInfo.LeaveDistance = enemyInfo.LeaveDistance;
        this.enemyInfo.MissPrecent = enemyInfo.MissPrecent;
        this.enemyInfo.MoveSpeed = enemyInfo.MoveSpeed;
        this.enemyInfo.AttackSpeed = enemyInfo.AttackSpeed;
        this.enemyInfo.MinAttackDistance = enemyInfo.MinAttackDistance;
        this.enemyInfo.AttackAnimTime = enemyInfo.AttackAnimTime;
    }
    private void OnMouseEnter()
    {
        if (Vector3.Distance(this.transform.position, player.position) < 10)
        {
            if (MouseCursorManager.Instance.mouseCursorType != MouseCursorTypes.LockTarget)
            {
                MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.Attack);
                
            }
        }

    }
    private void OnMouseExit()
    {
        if (Vector3.Distance(this.transform.position, player.position) < 10)
        {
            if (MouseCursorManager.Instance.mouseCursorType != MouseCursorTypes.LockTarget)
            {
                MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.Normal);
            }
        }
            
    }
}
