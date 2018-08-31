/*
Navicat MySQL Data Transfer

Source Server         : lyp
Source Server Version : 50713
Source Host           : localhost:3306
Source Database       : commodity

Target Server Type    : MYSQL
Target Server Version : 50713
File Encoding         : 65001

Date: 2018-08-31 17:05:06
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for goods
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '商品id',
  `number` varchar(100) NOT NULL COMMENT '商品编号',
  `name` varchar(100) NOT NULL COMMENT '商品名称',
  `pinyin` varchar(500) NOT NULL COMMENT '商品拼音',
  `price` decimal(10,2) NOT NULL COMMENT '商品价格，保留两位小数',
  `describe` varchar(2000) DEFAULT NULL COMMENT '商品描述',
  `state` int(11) NOT NULL DEFAULT '1' COMMENT '1待上架，2已上架，3已下架',
  `createtime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `updatetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of goods
-- ----------------------------
INSERT INTO `goods` VALUES ('3', '0002', '大水桶', 'dashuitong', '15.00', '手动阀v打算', '2', '2018-08-14 11:15:26', '2018-08-31 15:29:12');
INSERT INTO `goods` VALUES ('4', '0003', '香蕉', 'xiangjiao', '12.54', '', '1', '2018-08-14 13:51:06', '2018-08-22 14:33:45');
INSERT INTO `goods` VALUES ('5', '0004', '苹果', 'pingguo', '23.23', '', '2', '2018-08-14 13:56:48', '2018-08-31 15:29:12');
INSERT INTO `goods` VALUES ('6', '0005', '铅笔', 'qianbi', '2.08', '工具', '3', '2018-08-14 15:14:09', '2018-08-22 14:33:52');
INSERT INTO `goods` VALUES ('7', '0006', '橡皮', 'xiangpi', '234.51', '皮皮虾', '3', '2018-08-14 15:15:27', '2018-08-22 14:33:55');
INSERT INTO `goods` VALUES ('8', '0007', '水杯', 'shuibei', '2.01', '巴拉巴拉', '2', '2018-08-15 16:31:10', '2018-08-22 14:33:59');
INSERT INTO `goods` VALUES ('10', '0010', '插座', 'chazuo', '12.00', 'ww', '2', '2018-08-15 17:10:36', '2018-08-22 14:34:04');
INSERT INTO `goods` VALUES ('11', '0011', '龙虾', 'longxia', '34.99', '按上次发的', '1', '2018-08-16 15:09:07', '2018-08-22 14:34:10');
INSERT INTO `goods` VALUES ('12', '0012', '1111111111', '1111111111', '213.00', '', '1', '2018-08-22 11:24:00', '2018-08-22 14:34:13');
INSERT INTO `goods` VALUES ('13', '0013', '11111111', '11111111', '2132.00', '', '1', '2018-08-22 11:38:21', '2018-08-22 14:34:16');
INSERT INTO `goods` VALUES ('15', '0015', '商品哈哈哈', 'shangpinhahaha', '12.00', '阿斯顿发出', '2', '2018-08-22 14:11:39', '2018-08-23 14:25:39');

-- ----------------------------
-- Table structure for label
-- ----------------------------
DROP TABLE IF EXISTS `label`;
CREATE TABLE `label` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '商品标签id',
  `name` varchar(100) NOT NULL COMMENT '商品名称',
  `isDeleted` tinyint(1) NOT NULL DEFAULT '0' COMMENT '判断该标签是否被删除，默认为0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of label
-- ----------------------------
INSERT INTO `label` VALUES ('1', '建筑', '0');
INSERT INTO `label` VALUES ('2', '游戏', '0');
INSERT INTO `label` VALUES ('3', '外语', '1');
INSERT INTO `label` VALUES ('4', '电子', '0');
INSERT INTO `label` VALUES ('5', '化工', '0');
INSERT INTO `label` VALUES ('6', '机械', '1');
INSERT INTO `label` VALUES ('7', '土木', '0');
INSERT INTO `label` VALUES ('8', '生物', '0');
INSERT INTO `label` VALUES ('9', '巴拉', '1');
INSERT INTO `label` VALUES ('10', '无敌', '0');
INSERT INTO `label` VALUES ('11', '卡数据包', '1');

-- ----------------------------
-- Table structure for label_goods
-- ----------------------------
DROP TABLE IF EXISTS `label_goods`;
CREATE TABLE `label_goods` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '商品与商品标签关联表id',
  `goods_id` int(11) NOT NULL COMMENT '商品id',
  `label_id` int(11) NOT NULL COMMENT '商品标签id',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of label_goods
-- ----------------------------
INSERT INTO `label_goods` VALUES ('4', '6', '7');
INSERT INTO `label_goods` VALUES ('8', '7', '4');
INSERT INTO `label_goods` VALUES ('9', '7', '7');
INSERT INTO `label_goods` VALUES ('10', '8', '5');
INSERT INTO `label_goods` VALUES ('13', '10', '4');
INSERT INTO `label_goods` VALUES ('30', '11', '2');
INSERT INTO `label_goods` VALUES ('31', '11', '5');
INSERT INTO `label_goods` VALUES ('32', '11', '7');
INSERT INTO `label_goods` VALUES ('33', '15', '1');
INSERT INTO `label_goods` VALUES ('34', '15', '2');
INSERT INTO `label_goods` VALUES ('52', '3', '1');
INSERT INTO `label_goods` VALUES ('53', '3', '2');
