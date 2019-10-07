using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 声音管理类
/// 针对于只需要播放简单音效的游戏
/// 可以播放背景音乐与音效
/// </summary>
public class SoundManager : MonoSingleton<SoundManager>
{

    #region 数据成员
    //音效文件加载路径
    public string ResourceDir = "Sounds";
    //背景音乐播放组件
    private AudioSource m_bgSound;
    //音效播放组件
    private AudioSource m_effectSound;
    //静音管理
    private bool mute = false;
    public bool Mute
    {
        get
        {
            return mute;
        }

        set
        {
            m_bgSound.mute = value;
            m_effectSound.mute = value;
            mute = value;
        }
    }
    //音乐大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }
    //音效大小
    public float EffectVolume
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    
    #endregion

    /// <summary>
    /// 在SoundsManager上添加两个音频播放器并初始化
    /// </summary>
    public void Init()
    {
        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;

        m_effectSound = this.gameObject.AddComponent<AudioSource>();
        m_effectSound.playOnAwake = false;
    }
    /// <summary>
    /// 播放BGM
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayBg(string audioName)
    {
        if (Mute)
            return;
        //当前正在播放的音乐文件
        string oldName;
        if (m_bgSound.clip == null)
            oldName = "";
        else
            oldName = m_bgSound.clip.name;

        if (oldName != audioName)
        {
            //音乐文件路径
            string path;
            if (string.IsNullOrEmpty(ResourceDir))
                path = audioName;
            else
                path = ResourceDir + "/" + audioName;

            //加载音乐
            AudioClip clip = Resources.Load<AudioClip>(path);

            //播放
            if (clip != null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }

    /// <summary>
    /// 停止BGM
    /// </summary>
    public void StopBg()
    {
        if (m_bgSound.clip != null)
        {
            m_bgSound.Stop();
            m_bgSound.clip = null;
        }
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayEffect(string audioName)
    {
        if (Mute)
            return;
        //路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
            path = audioName;
        else
            path = ResourceDir + "/" + audioName;

        //音频
        AudioClip clip = Resources.Load<AudioClip>(path);

        //播放
        m_effectSound.PlayOneShot(clip);
    }
}