# 黑暗之光

**作者：vili &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;联系方式：vili_wzl@126.com**

*黑暗之光是一款单机ARPG游戏，不过在运行时需要连接数据库(因为开发时正好赶上数据库课程，就顺手当做大作业了)。*

*也就是说如果数据库在服务器上就需要有网(别问为啥没用那种类似sqlite的本地数据库，问就是不知道)。*

[TOC]


## 一、项目介绍

1. 该项目采用Unity+FairyGUI+MySQL开发。

   1. FairyGUI用来开发所有的UI界面，他是继NGUI与UGUI之后的新的UI解决方案。[官方网址](http://www.fairygui.com/)
   2. Unity用来开发游戏的主体逻辑。
   3. Mysql用来存储数据。

2. 工程文件为：DarkLight+DarkLight_FairyGUI+素材+LightOfDakness.sql

   1. DarkLight是Unity工程目录，请使用Unity打开。
   2. DarkLight_FairyGUI是FairyGUI工程目录，请使用FairyGUI打卡。
   3. 素材是FairyGUI中制作UI界面需要的素材，已按照各个界面分好。
   4. LightOfDakness.sql是数据库恢复文件，请将数据恢复至Mysql数据库。

   

## 二、功能介绍

### 1. 登录

- 登录系统默认数据库没有账户就注册。

### 2.模式选择

- 新游戏，开始一场新的游戏。

- 继续游戏，继续这个账户的上一场游戏（新建账户点这个会有bug）。

### 3.角色选择

- 游戏提供两个角色，法师和战士（数据库中两者的数据差不多，需要的可自行更具细节调整）。

### 4.背包系统

- 商店买的物品会显示在这里。

### 5.装备系统

- 背包中的装备物品点击会自动装备到该面板。

- 该面板的装备点击会自动回到背包，如果已满就脱不下去。

- 装备或卸下装备会更新角色属性(属性面板显示)。

### 6.属性系统

- 显示各种属性。

- 提供加点功能，升级以后获得点数。

### 7. 技能系统

- 显示该角色所有技能(战士角色由于特效原因没有技能，需要请自行添加)。

- 到达等级以后解锁新技能，可以将技能放置到快捷键栏上。

- 单体技能需点击攻击目标。

- 增益和增强技能作用于自身，不需要目标。

- 群体技能需要点击地面。

### 8.快捷键栏

- 将技能放置在快捷键栏上，可以通过快捷键释放技能。

- 快捷键栏显示为0-5，实际对应按键为1-6(数字键)。

- 可随时替换技能。

### 9.商店系统

- 商店有装备商店和药品商店。

- 商店中可选择购买商品数量，数量超出当前拥有金币时无法再继续增加。

### 10.任务系统

提供任务供玩家完成。

### 11.系统设置

- 提供静音选项。

- 提供退出游戏按钮。

## 三、部署设置

1. 将数据库备份文件还原至数据库中。
2. 使用Unity打开项目。
3. 修改"DarkLight/Assets/Scripts/FrameWork/Config.cs"文件，将conStr中的值改为你自己的数据库连接字符串。
5. 运行程序即可。

## 四、项目存在的问题

### 1.商店系统BUG

- 初始有1000金币，可以选择10大血瓶或20个小血瓶。将两个数量都调到最大，然后买其中一个，这时另一个物品就没法买当前选择的数量了(因为一部分金币已经买另一个了)。但是这时选择的数量没变，点击购买会购买失败，并且数量不会归零(正常买完物品，商店中该显示的要购买的数量应为0)。

### 2.角色系统的Bug

- 战士角色技能系统未添加。

### 3.游戏存档的Bug

- 对于新建的角色，继续游戏按钮同样会出现。此时因为没有游戏存档，点击继续游戏按钮界面会跳转，但是会报错。

### 4.登录与注册的方式

- 在登录时，如果检测到当前登录账号不存在，就会以当前的账号和密码去注册。当账号已被注册时，则需匹配密码。

## 五、项目截图

1. 登录

	![mark](http://image.vilicode.com/blog/20191007/Pzh3hwIBi1P3.png?imageslim)
2. 选择模式

	![mark](http://image.vilicode.com/blog/20191007/DBETX1IUMaIG.png?imageslim)
3. 人物选择

	![mark](http://image.vilicode.com/blog/20191007/tNXXyeRj8460.png?imageslim)
4. 游戏地图

	![mark](http://image.vilicode.com/blog/20191007/gMuQ5W63iivK.png?imageslim)
5. 基础功能界面

	![mark](http://image.vilicode.com/blog/20191007/xSFly2unseqC.png?imageslim)
6. 装备商店

	![mark](http://image.vilicode.com/blog/20191007/ElYaSaRLqKtM.png?imageslim)
7. 药品商店

	![mark](http://image.vilicode.com/blog/20191007/G8kdkj55yCaU.png?imageslim)
8. 任务界面

	![mark](http://image.vilicode.com/blog/20191007/mNEWrReUDd50.png?imageslim)
9. 敌人

	![mark](http://image.vilicode.com/blog/20191007/77xqIgte16Bn.png?imageslim)
10. 攻击

	![mark](http://image.vilicode.com/blog/20191007/7nm0aJcIe0CS.png?imageslim)
11. 死亡

	![mark](http://image.vilicode.com/blog/20191007/mm7ajDzLbcOU.png?imageslim)
