# Changelog

## [0.1.0] - 2022-02-21

### 新增

- 完成WebSocketClient
- 适配PrivateMessageEvent
- 适配SendMessageAPI
- 基于cqhttp基本的接收回复功能

### 更改
- 基础重构

## [0.1.1] - 2022-02-21

### 新增

- 添加README

## [0.2.0] - 2022-02-21

### 更改

- 大幅度重构关于NotionAPI和cqhttp相关的库结构

## [0.3.0] - 2022-02-22

### 新增

- 适配GroupMessageEvent

### 修复

- 重构导致的测试用例报错

## [0.4.0] - 2022-02-22

### 新增

- 适配FriendRequestEvent
- 添加ChangeLog

### 更改

- 移除测试用例中的个人信息

### 修复
- WebSocketClient 捕获异常类型过于宽泛

## [0.5.0] - 2022-02-22

### 新增

- 适配OtherClientStatusChanged、OfflineFile、GroupNotify、FriendNotify、GroupRequestEvent
- 适配DeleteMessage、SetFriendAddRequest、SetGroupAddRequest、GetVersionInfo、SetRestart、GetStatus、GetOnlineClientsAPI

### 更改

- 接着重构Event、API、Response、Request部分的结构

## [0.6.0] - 2022-02-26

### 新增

- Notion API增加/查询Page测试
- Http操作测试