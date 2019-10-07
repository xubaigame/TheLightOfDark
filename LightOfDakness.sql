-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 39.96.5.207    Database: darklight
-- ------------------------------------------------------
-- Server version	5.5.62

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bag_item_information`
--

DROP TABLE IF EXISTS `bag_item_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bag_item_information` (
  `user_id` int(11) NOT NULL,
  `slot_id` int(11) NOT NULL,
  `item_id` int(11) DEFAULT NULL,
  `slot_item_count` int(11) DEFAULT NULL,
  PRIMARY KEY (`user_id`,`slot_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bag_item_information`
--

LOCK TABLES `bag_item_information` WRITE;
/*!40000 ALTER TABLE `bag_item_information` DISABLE KEYS */;
INSERT INTO `bag_item_information` VALUES (2,0,NULL,0),(2,1,NULL,0),(2,2,NULL,0),(2,3,NULL,0),(2,4,NULL,0),(2,5,NULL,0),(2,6,NULL,0),(2,7,NULL,0),(2,8,NULL,0),(2,9,NULL,0),(2,10,NULL,0),(2,11,NULL,0),(2,12,NULL,0),(2,13,NULL,0),(2,14,NULL,0),(2,15,NULL,0),(2,16,NULL,0),(2,17,NULL,0),(2,18,NULL,0),(2,19,NULL,0),(2,20,NULL,0),(2,21,NULL,0),(2,22,NULL,0),(2,23,NULL,0),(2,24,NULL,0),(3,0,NULL,0),(3,1,NULL,0),(3,2,NULL,0),(3,3,NULL,0),(3,4,NULL,0),(3,5,NULL,0),(3,6,NULL,0),(3,7,NULL,0),(3,8,NULL,0),(3,9,NULL,0),(3,10,NULL,0),(3,11,NULL,0),(3,12,NULL,0),(3,13,NULL,0),(3,14,NULL,0),(3,15,NULL,0),(3,16,NULL,0),(3,17,NULL,0),(3,18,NULL,0),(3,19,NULL,0),(3,20,NULL,0),(3,21,NULL,0),(3,22,NULL,0),(3,23,NULL,0),(3,24,NULL,0),(4,0,NULL,0),(4,1,NULL,0),(4,2,NULL,0),(4,3,NULL,0),(4,4,NULL,0),(4,5,NULL,0),(4,6,NULL,0),(4,7,NULL,0),(4,8,NULL,0),(4,9,NULL,0),(4,10,NULL,0),(4,11,NULL,0),(4,12,NULL,0),(4,13,NULL,0),(4,14,NULL,0),(4,15,NULL,0),(4,16,NULL,0),(4,17,NULL,0),(4,18,NULL,0),(4,19,NULL,0),(4,20,NULL,0),(4,21,NULL,0),(4,22,NULL,0),(4,23,NULL,0),(4,24,NULL,0);
/*!40000 ALTER TABLE `bag_item_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enemy_birth_information`
--

DROP TABLE IF EXISTS `enemy_birth_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enemy_birth_information` (
  `enemy_id` int(11) NOT NULL,
  `enemy_count` int(11) DEFAULT NULL,
  `enemy_type` int(11) DEFAULT NULL,
  `enemy_spawn_poziton` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `enemy_prefab_path` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`enemy_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enemy_birth_information`
--

LOCK TABLES `enemy_birth_information` WRITE;
/*!40000 ALTER TABLE `enemy_birth_information` DISABLE KEYS */;
INSERT INTO `enemy_birth_information` VALUES (0,5,0,'85,50,60','Enemy/Prefabs/WolfBaby'),(1,3,1,'85,50,60','Enemy/Prefabs/WolfNormal'),(2,1,2,'85,50,60','Enemy/Prefabs/WolfBoss');
/*!40000 ALTER TABLE `enemy_birth_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enemy_information`
--

DROP TABLE IF EXISTS `enemy_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enemy_information` (
  `enemy_id` int(11) NOT NULL,
  `enemy_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `enemy_type` int(11) DEFAULT NULL,
  `enemy_hp` int(11) DEFAULT NULL,
  `enemy_exp` int(11) DEFAULT NULL,
  `enemy_damage` int(11) DEFAULT NULL,
  `enemy_leave_distance` int(11) DEFAULT NULL,
  `enemy_miss_precent` float DEFAULT NULL,
  `enemy_move_speed` int(11) DEFAULT NULL,
  `enemy_attack_speed` int(11) DEFAULT NULL,
  `enemy_min_attack_distance` int(11) DEFAULT NULL,
  `enemy_attack_animation_time` float DEFAULT NULL,
  PRIMARY KEY (`enemy_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enemy_information`
--

LOCK TABLES `enemy_information` WRITE;
/*!40000 ALTER TABLE `enemy_information` DISABLE KEYS */;
INSERT INTO `enemy_information` VALUES (0,'小狼',0,100,101,50,3,0.2,1,1,2,0.7),(1,'中狼',1,200,500,100,5,0.3,1,1,2,0.7),(2,'狼王',2,500,1000,200,8,0.4,2,2,3,0.5);
/*!40000 ALTER TABLE `enemy_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment_item_information`
--

DROP TABLE IF EXISTS `equipment_item_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipment_item_information` (
  `user_id` int(11) NOT NULL,
  `equipment_slot_id` int(11) NOT NULL,
  `item_id` int(11) DEFAULT NULL,
  `equipment_type` int(11) DEFAULT NULL,
  PRIMARY KEY (`user_id`,`equipment_slot_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment_item_information`
--

LOCK TABLES `equipment_item_information` WRITE;
/*!40000 ALTER TABLE `equipment_item_information` DISABLE KEYS */;
INSERT INTO `equipment_item_information` VALUES (2,0,NULL,0),(2,1,NULL,1),(2,2,NULL,2),(2,3,NULL,3),(2,4,NULL,4),(2,5,NULL,5),(3,0,NULL,0),(3,1,NULL,1),(3,2,NULL,2),(3,3,NULL,3),(3,4,NULL,4),(3,5,NULL,5),(4,0,NULL,0),(4,1,NULL,1),(4,2,NULL,2),(4,3,NULL,3),(4,4,NULL,4),(4,5,NULL,5);
/*!40000 ALTER TABLE `equipment_item_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_information`
--

DROP TABLE IF EXISTS `item_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item_information` (
  `item_id` int(11) NOT NULL,
  `item_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_quality` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `player_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_description` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_capacity` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_buyPrice` int(11) DEFAULT NULL,
  `item_sellPrice` int(11) DEFAULT NULL,
  `item_sprite` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_hp` int(11) DEFAULT NULL,
  `item_mp` int(11) DEFAULT NULL,
  `equipment_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `item_attack` int(11) DEFAULT NULL,
  `item_defence` int(11) DEFAULT NULL,
  `item_speed` int(11) DEFAULT NULL,
  PRIMARY KEY (`item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_information`
--

LOCK TABLES `item_information` WRITE;
/*!40000 ALTER TABLE `item_information` DISABLE KEYS */;
INSERT INTO `item_information` VALUES (1001,'小瓶血药','Consumable','Commom','Commom','小瓶血药','99',50,20,'ui://ResGame/icon-potion1',100,0,NULL,NULL,NULL,NULL),(1002,'大瓶血药','Consumable','Commom','Commom','大瓶血药','99',100,40,'ui://ResGame/icon-potion2',500,0,NULL,NULL,NULL,NULL),(1003,'蓝药','Consumable','Commom','Commom','蓝药','99',50,20,'ui://ResGame/icon-potion3',0,100,NULL,NULL,NULL,NULL),(2001,'黄金甲','Equipment','Commom','Swordman','铠甲','1',100,20,'ui://ResGame/armor0-icon',NULL,NULL,'Armor',0,10,0),(2002,'铜甲','Equipment','Commom','Swordman','铠甲','1',100,40,'ui://ResGame/armor1-icon',NULL,NULL,'Armor',0,5,0),(2003,'神迹魔法衣','Equipment','Commom','Magician','铠甲','1',100,20,'ui://ResGame/armor2-icon',NULL,NULL,'Armor',0,10,0),(2004,'破旧魔法衣','Equipment','Commom','Magician','铠甲','1',100,40,'ui://ResGame/armor3-icon',NULL,NULL,'Armor',0,5,0),(2005,'铜鞋','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-boot0',NULL,NULL,'Shoe',0,0,20),(2006,'神级红鞋','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-boot0-01',NULL,NULL,'Shoe',0,0,10),(2007,'帽子','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/icon-helm',NULL,NULL,'Headgear',0,10,0),(2008,'神帽','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/icon-helm-01',NULL,NULL,'Headgear',0,5,0),(2009,'神迹魔法帽','Equipment','Commom','Magician','帽子','1',100,40,'ui://ResGame/icon-helm-02',NULL,NULL,'Headgear',0,10,0),(2010,'破旧魔法帽','Equipment','Commom','Magician','帽子','1',100,40,'ui://ResGame/icon-helm-03',NULL,NULL,'Headgear',0,5,0),(2011,'黄金戒指','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-ring',NULL,NULL,'Accessory',10,0,20),(2012,'铜绿戒指','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-ring-01',NULL,NULL,'Accessory',5,0,10),(2013,'盾牌','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-shield',NULL,NULL,'Left',0,10,20),(2014,'神盾','Equipment','Commom','Commom','鞋子','1',100,40,'ui://ResGame/icon-shield1',NULL,NULL,'Left',0,5,10),(2015,'皇族项链','Equipment','Commom','Commom','帽子','1',100,40,'ui://ResGame/icon-tailman',NULL,NULL,'Accessory',10,0,0),(2016,'火柴棍','Equipment','Commom','Magician','帽子','1',100,40,'ui://ResGame/rod-icon',NULL,NULL,'Right',5,0,0),(2017,'金属棍','Equipment','Commom','Magician','帽子','1',100,40,'ui://ResGame/rod-icon02',NULL,NULL,'Right',10,0,0),(2018,'神级魔法棒','Equipment','Commom','Magician','帽子','1',100,40,'ui://ResGame/rod-icon03',NULL,NULL,'Right',15,0,0),(2019,'木剑','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/sword0-icon',NULL,NULL,'Right',5,0,0),(2020,'双剑','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/sword0-icon00',NULL,NULL,'Right',10,0,0),(2021,'黄金剑','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/sword1-icon',NULL,NULL,'Right',15,0,0),(2022,'神级圣剑','Equipment','Commom','Swordman','帽子','1',100,40,'ui://ResGame/sword2-icon',NULL,NULL,'Right',20,0,0);
/*!40000 ALTER TABLE `item_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mouse_cursor_information`
--

DROP TABLE IF EXISTS `mouse_cursor_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mouse_cursor_information` (
  `mc_name` varchar(45) COLLATE utf8_bin NOT NULL,
  `mc_type` int(11) NOT NULL,
  `mc_sprite` varchar(45) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`mc_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mouse_cursor_information`
--

LOCK TABLES `mouse_cursor_information` WRITE;
/*!40000 ALTER TABLE `mouse_cursor_information` DISABLE KEYS */;
INSERT INTO `mouse_cursor_information` VALUES ('Attack',2,'MouseCursor/Textures/Cursor-Attack'),('LockTarget',3,'MouseCursor/Textures/Cursor-LockTarget'),('Normal',0,'MouseCursor/Textures/Cursor-Normal'),('NpcTalk',1,'MouseCursor/Textures/Cursor-Npc Talk'),('Pick',4,'MouseCursor/Textures/Cursor-Pick');
/*!40000 ALTER TABLE `mouse_cursor_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `play_development_information`
--

DROP TABLE IF EXISTS `play_development_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `play_development_information` (
  `player_id` int(11) NOT NULL,
  `player_add_hp` int(11) DEFAULT NULL,
  `player_add_mp` int(11) DEFAULT NULL,
  `player_add_exp` int(11) DEFAULT NULL,
  `player_add_attack` int(11) DEFAULT NULL,
  `player_add_defence` int(11) DEFAULT NULL,
  `player_add_speed` int(11) DEFAULT NULL,
  `player_add_point` int(11) DEFAULT NULL,
  PRIMARY KEY (`player_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `play_development_information`
--

LOCK TABLES `play_development_information` WRITE;
/*!40000 ALTER TABLE `play_development_information` DISABLE KEYS */;
INSERT INTO `play_development_information` VALUES (0,100,100,100,10,10,3,5),(1,100,100,100,10,10,3,5);
/*!40000 ALTER TABLE `play_development_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `player_status_information`
--

DROP TABLE IF EXISTS `player_status_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `player_status_information` (
  `player_type` varchar(45) COLLATE utf8_bin NOT NULL,
  `player_hp` int(11) DEFAULT NULL,
  `player_mp` int(11) DEFAULT NULL,
  `player_exp` int(11) DEFAULT NULL,
  `player_attack` int(11) DEFAULT NULL,
  `player_defence` int(11) DEFAULT NULL,
  `player_speed` int(11) DEFAULT NULL,
  `player_attack_speed` int(11) DEFAULT NULL,
  `player_attack_distance` int(11) DEFAULT NULL,
  `player_miss_precent` int(11) DEFAULT NULL,
  PRIMARY KEY (`player_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `player_status_information`
--

LOCK TABLES `player_status_information` WRITE;
/*!40000 ALTER TABLE `player_status_information` DISABLE KEYS */;
INSERT INTO `player_status_information` VALUES ('Magician',1000,500,100,20,20,10,2,2,0),('Swordman',1200,300,100,20,20,10,2,2,0);
/*!40000 ALTER TABLE `player_status_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shop_item_information`
--

DROP TABLE IF EXISTS `shop_item_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shop_item_information` (
  `shop_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `item_id` int(11) DEFAULT NULL,
  `shop_item_count` int(11) DEFAULT NULL,
  PRIMARY KEY (`shop_item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shop_item_information`
--

LOCK TABLES `shop_item_information` WRITE;
/*!40000 ALTER TABLE `shop_item_information` DISABLE KEYS */;
INSERT INTO `shop_item_information` VALUES (1,1001,0),(2,1002,0),(3,1003,0),(4,2001,0),(5,2002,0),(6,2003,0),(7,2004,0),(8,2005,0),(9,2006,0),(10,2007,0),(11,2008,0),(12,2009,0),(13,2010,0),(14,2011,0),(15,2012,0),(16,2013,0),(17,2014,0),(18,2015,0),(19,2016,0),(20,2017,0),(21,2018,0),(22,2019,0),(23,2020,0),(24,2021,0),(25,2022,2);
/*!40000 ALTER TABLE `shop_item_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shortcut_information`
--

DROP TABLE IF EXISTS `shortcut_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shortcut_information` (
  `user_id` int(11) NOT NULL,
  `shortcut_id` int(11) NOT NULL,
  `skill_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`user_id`,`shortcut_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shortcut_information`
--

LOCK TABLES `shortcut_information` WRITE;
/*!40000 ALTER TABLE `shortcut_information` DISABLE KEYS */;
INSERT INTO `shortcut_information` VALUES (2,0,NULL),(2,1,NULL),(2,2,NULL),(2,3,NULL),(2,4,NULL),(2,5,NULL),(3,0,5001),(3,1,NULL),(3,2,NULL),(3,3,NULL),(3,4,NULL),(3,5,NULL),(4,0,NULL),(4,1,NULL),(4,2,NULL),(4,3,NULL),(4,4,NULL),(4,5,NULL);
/*!40000 ALTER TABLE `shortcut_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill_information`
--

DROP TABLE IF EXISTS `skill_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill_information` (
  `skill_id` int(11) NOT NULL,
  `skill_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_spirit` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_description` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_mp` int(11) DEFAULT NULL,
  `skill_cd` int(11) DEFAULT NULL,
  `player_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `player_level` int(11) DEFAULT NULL,
  `skill_time` int(11) DEFAULT NULL,
  `skill_effect_path` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_effect_attribute` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_effect_value` int(11) DEFAULT NULL,
  `skill_annimation_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `skill_annimation_time` double DEFAULT NULL,
  `skill_damage` int(11) DEFAULT NULL,
  `skill_distance` int(11) DEFAULT NULL,
  PRIMARY KEY (`skill_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill_information`
--

LOCK TABLES `skill_information` WRITE;
/*!40000 ALTER TABLE `skill_information` DISABLE KEYS */;
INSERT INTO `skill_information` VALUES (5001,'魔法弹','ui://ResGame/skill-09','伤害 350%','SingleSkill',60,5,'Magician',1,NULL,'Skill/Effects/Efx_CriticalStrike','Attack',NULL,'Skill-MagicBall',1.1,350,5),(5002,'治疗','ui://ResGame/skill-13','治愈30HP','PassiveSkill',30,5,'Magician',2,NULL,'Skill/Effects/Heal_Effect','HP',30,'Attack1',0.83,NULL,NULL),(5003,'恢复魔法','ui://ResGame/skill-10','魔法恢复50','PassiveSkill',20,5,'Magician',3,NULL,'Skill/Effects/Effect_BlueHeal','MP',50,'Attack1',0.83,NULL,NULL),(5004,'魔法爆炸','ui://ResGame/skill-05','攻击力为200%持续15秒','BuffSkill',20,5,'Magician',4,15,'Skill/Effects/RangeMagic_Effect','Attack',30,'Skill-GroundImpact',1.1,NULL,NULL),(5005,'加速魔法','ui://ResGame/skill-12','攻击力速度为200%持续30秒','BuffSkill',20,5,'Magician',5,30,'Skill/Effects/Efx_One-handQuicken','AttackSpeed',1,'Skill-GroundImpact',1.1,NULL,NULL),(5006,'究极风暴','ui://ResGame/skill-11','攻击力400% 所有敌人','MultiSkill',60,5,'Magician',6,60,'Skill/Effects/MagicSphere_effect',NULL,NULL,'AttackCritical',0.8,200,350);
/*!40000 ALTER TABLE `skill_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task_information`
--

DROP TABLE IF EXISTS `task_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `task_information` (
  `task_id` int(11) NOT NULL,
  `task_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `task_description` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `task_finish_condition` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `task_award` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `task_EffectEnemyType` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `task_next_task` int(11) DEFAULT NULL,
  `task_plan` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task_information`
--

LOCK TABLES `task_information` WRITE;
/*!40000 ALTER TABLE `task_information` DISABLE KEYS */;
INSERT INTO `task_information` VALUES (0,'收集牙齿','收集10颗狼牙','0/10','金币:50','0',1,'0/10');
/*!40000 ALTER TABLE `task_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_information`
--

DROP TABLE IF EXISTS `user_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_information` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(45) COLLATE utf8_bin NOT NULL,
  `user_password` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_last_login_time` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_information`
--

LOCK TABLES `user_information` WRITE;
/*!40000 ALTER TABLE `user_information` DISABLE KEYS */;
INSERT INTO `user_information` VALUES (1,'vili','vili',NULL),(4,'123','123','2019-10-07 21:57:40');
/*!40000 ALTER TABLE `user_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_player_status_information`
--

DROP TABLE IF EXISTS `user_player_status_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_player_status_information` (
  `user_id` int(11) NOT NULL,
  `user_player_id` int(11) NOT NULL,
  `user_player_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_player_hp` int(11) DEFAULT NULL,
  `user_player_remain_hp` double DEFAULT NULL,
  `user_player_mp` int(11) DEFAULT NULL,
  `user_player_remain_mp` double DEFAULT NULL,
  `user_player_exp` int(11) DEFAULT NULL,
  `user_player_now_exp` int(11) DEFAULT NULL,
  `user_player_level` int(11) DEFAULT NULL,
  `user_player_coin` int(11) DEFAULT NULL,
  `user_player_attack` int(11) DEFAULT NULL,
  `user_player_add_attack` int(11) DEFAULT NULL,
  `user_player_defence` int(11) DEFAULT NULL,
  `user_player_add_defence` int(11) DEFAULT NULL,
  `user_player_speed` int(11) DEFAULT NULL,
  `user_player_add_speed` int(11) DEFAULT NULL,
  `user_player_attack_speed` double DEFAULT NULL,
  `user_player_attack_distance` int(11) DEFAULT NULL,
  `user_player_miss_precent` double DEFAULT NULL,
  `user_player_type` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_player_point` int(11) DEFAULT '0',
  PRIMARY KEY (`user_id`,`user_player_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_player_status_information`
--

LOCK TABLES `user_player_status_information` WRITE;
/*!40000 ALTER TABLE `user_player_status_information` DISABLE KEYS */;
INSERT INTO `user_player_status_information` VALUES (4,1,'vili',1000,1000,500,500,100,0,1,1000,20,0,20,0,10,0,2,2,0,'Magician',0);
/*!40000 ALTER TABLE `user_player_status_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_task_information`
--

DROP TABLE IF EXISTS `user_task_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_task_information` (
  `user_id` int(11) NOT NULL,
  `task_id` int(11) NOT NULL,
  `task_state` int(11) DEFAULT NULL,
  `task_plan` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`user_id`,`task_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_task_information`
--

LOCK TABLES `user_task_information` WRITE;
/*!40000 ALTER TABLE `user_task_information` DISABLE KEYS */;
INSERT INTO `user_task_information` VALUES (4,0,1,'0/10');
/*!40000 ALTER TABLE `user_task_information` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-07 21:59:28
