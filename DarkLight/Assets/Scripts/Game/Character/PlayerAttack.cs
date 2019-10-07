using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour {

    #region 数据成员
    private bool isLockTarget = false;
    private bool isLockPosition = false;
    private BaseSkill Skillinfo = null;
    public Camera UICamera;
    public float Speed = 3;
    public GameObject Efc_Click_Prefab;
    private Vector3 targetPos;
    public bool isEnemy = false;
    private double AttackTimer = 0;
    private double attackTimer;
    private bool isIdel = false;
    private AnimationStates playerState = AnimationStates.Idle;
    private NavMeshAgent agent;
    public AnimationStates PlayerState
    {
        get
        {
            return playerState;
        }

        set
        {
            playerState = value;
            if(UpdateAnim!=null)
                UpdateAnim();
        }
    }
    public Action UpdateAnim;
    public RaycastHit hitInfo;
    private ShowAttack AttackShow;
    public new Animation animation;
    #endregion

    /// <summary>
    /// 初始化信息
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isLockTarget = false;
        isLockPosition = false;
        targetPos = transform.position;
        AttackTimer = PlayerStatusManager.Instance.GetAttackSpeed();
        AttackShow = GetComponent<ShowAttack>();
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// 鼠标点击控制移动的检测
    /// </summary>
    void Update ()
    {
        if (playerState == AnimationStates.Death|| playerState == AnimationStates.SkillAttack)
            return;
        AttackTimer = PlayerStatusManager.Instance.GetAttackSpeed();
        if (isLockTarget && Input.GetMouseButtonDown(0))
        {
            TakeEnemy();
        }
        else if (isLockPosition && Input.GetMouseButtonDown(0))
        {
            MulTakeEnemy();
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !Stage.isTouchOnUI)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool isCollider = Physics.Raycast(ray, out hitInfo);
                if (isCollider)
                {
                    if (hitInfo.collider.tag == Tags.ground)
                    {
                        ShowClickEffect(hitInfo.point);
                        isEnemy = false;
                        targetPos = hitInfo.point;
                        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
                        transform.LookAt(targetPos);
                    }
                    else if (hitInfo.collider.tag == Tags.enemy)
                    {
                        isEnemy = true;
                        targetPos = hitInfo.point;
                        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
                        transform.LookAt(targetPos);
                    }
                }
            }
            if (isEnemy)
            {
                if (hitInfo.collider == null)
                {
                    isEnemy = false;
                    targetPos = this.transform.position;
                }
                if (Vector3.Distance(transform.position, targetPos) > PlayerStatusManager.Instance.GetAttackDistance())
                {
                    transform.LookAt(targetPos);
                    //characterController.SimpleMove(transform.forward * Speed);
                    agent.SetDestination(targetPos);
                    if (agent.hasPath)
                        return;
                    targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
                    PlayerState = AnimationStates.Move;
                    PlayAnim("Run");
                }
                else
                {
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= AttackTimer && isIdel == false)
                    {
                        attackTimer = 0;
                        isIdel = true;
                        PlayerState = AnimationStates.Attack;
                        PlayAnim("Attack1");
                        transform.LookAt(hitInfo.transform);
                        agent.SetDestination(transform.position);
                    }
                    if (isIdel == true)
                    {
                        if (attackTimer >= 0.833f)
                        {
                            if (hitInfo.collider.tag == Tags.enemy)
                            {
                                hitInfo.collider.SendMessage("GetAttack", PlayerStatusManager.Instance.GetAttack());
                            }
                            attackTimer = 0;
                            isIdel = false;
                            PlayerState = AnimationStates.Idle;

                            PlayAnim("Idle");
                        }
                    }
                }
            }
            else
            {
                attackTimer = AttackTimer;
                if (Vector3.Distance(transform.position, targetPos) > 0.2f)
                {
                    //transform.LookAt(targetPos);
                    //characterController.SimpleMove(transform.forward * Speed);
                    agent.SetDestination(targetPos);
                    if (!agent.hasPath)
                    {
                        PlayerState = AnimationStates.Idle;
                        PlayAnim("Idle");
                        return;
                    } 
                    targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
                    PlayerState = AnimationStates.Move;
                    PlayAnim("Run");

                }
                else
                {
                    PlayerState = AnimationStates.Idle;
                    PlayAnim("Idle");
                }
            }
        }
    }
    public void GetAttack(int hp)
    {
        if (playerState == AnimationStates.Death)
            return;
        playerState = AnimationStates.Attack;
        if (UnityEngine.Random.Range(1, 11) / (double)10 <= PlayerStatusManager.Instance.playerInfo.MissPrecent)
        {
            AttackShow.ShowAttackMsg("Miss", Color.green);
        }
        else
        {
            PlayAnim("TakeDamage1");
            AttackShow.ShowAttackMsg(" - " + hp, Color.red);
            bool death=PlayerStatusManager.Instance.TakeDamage(hp);
            if(!death)
            {
                PlayAnim("Death");
                playerState = AnimationStates.Death;
            }
        }
    }
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint += new Vector3(0, 0.1f, 0);
        GameObject.Instantiate(Efc_Click_Prefab, hitPoint, Quaternion.identity);
    }
    public void PlayAnim(string animName, double seconds = 0, Action callBack = null)
    {
        animation.CrossFade(animName);
        if(seconds!=0)
        {
            StartCoroutine(PlayCallBack(seconds, callBack));
        }
    }
    public void TakeEnemy()
    {
        if (Skillinfo != null)
        {
            SingleSkill ss = Skillinfo as SingleSkill;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider)
            {
                if (hitInfo.collider.tag == Tags.enemy)
                {
                    if (Vector3.Distance(transform.position, hitInfo.transform.position) < ss.SkillDis)
                    {
                        PlayerStatusManager.Instance.CutMP(Skillinfo.SkillMP);
                        agent.SetDestination(transform.position);
                        PlayerState = AnimationStates.SkillAttack;
                        PlayAnim(ss.AnimName, ss.AnimTime, () => { PlayerState = AnimationStates.Attack; });
                        isEnemy = true;
                        transform.LookAt(hitInfo.transform);
                        GameObject effect = Resources.Load<GameObject>(ss.EffectPath);
                        GameObject.Instantiate(effect, hitInfo.transform.position, Quaternion.identity);
                        hitInfo.collider.SendMessage("GetAttack", ss.SkillDamage);
                    }
                }
            }
        }
        isLockTarget = false;
        Skillinfo = null;
        MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.Normal);
    }
    public void SetState(BaseSkill bs)
    {
        isLockTarget = true;
        Skillinfo = bs;
    }
    public void SetMulState(BaseSkill bs)
    {
        isLockPosition = true;
        Skillinfo = bs;
    }
    public void MulTakeEnemy()
    {
        if (Skillinfo != null)
        {
            MultiSkill ss = Skillinfo as MultiSkill;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider)
            {
                if (hitInfo.collider.tag == Tags.ground)
                {
                    if (Vector3.Distance(transform.position, hitInfo.point) < ss.SkillDis)
                    {
                        PlayerStatusManager.Instance.CutMP(Skillinfo.SkillMP);
                        Vector3 vector3 = new Vector3(hitInfo.point.x, hitInfo.point.y+1, hitInfo.point.z);
                        GameObject effect = Resources.Load<GameObject>(Skillinfo.EffectPath);
                        effect=Instantiate(effect, vector3, hitInfo.transform.rotation);
                        effect.GetComponent<MulSkillEffect>().Init(Skillinfo);
                        transform.LookAt(hitInfo.point);
                        PlayerState = AnimationStates.SkillAttack;
                        PlayAnim(ss.AnimName, ss.AnimTime, () => { PlayerState = AnimationStates.Attack; });
                        
                    }
                }
            }
        }
        isLockPosition = false;
        Skillinfo = null;
        MouseCursorManager.Instance.SetMouseCorsor(MouseCursorTypes.Normal);
    }
    private IEnumerator PlayCallBack(double seconds, Action callBack)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds((float)seconds);
        if(callBack!=null)
        {
            callBack();
            agent.isStopped = false;
        }
    }
}
