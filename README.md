# Asp.Net Core Demo

本 Demo 用于演示 Asp.Net Core 框架的使用。

本 Demo 的测试部分基于测试金字塔理论，目的是探求 Asp.Net Core 框架下对测试金字塔思想的表达，以及一些优秀工具的演示：

- [Practical Test Pyramid](https://martinfowler.com/articles/practical-test-pyramid.html)

## 运行环境

- .Net Core 2.1

## 运行程序

使用 `Docker Compose` 启动已经过配置的 `SQL Server` 容器（默认端口号为 1433）：

```bash
docker-compose up -d
```

运行以下命令初始化（迁移）数据库结构：
```bash
dotnet ef --project AspNetCoreDemo.WebApi database update
```

运行以下命令启动程序：

```bash
dotnet run --project AspNetCoreDemo.WebApi
```

然后用浏览器访问（二者区别仅在于是否使用了 `HTTPS` 协议）：

- https://localhost:5001
- http://localhost:5000

## 运行测试

使用以下命令运行 Controller 的端到端测试：

```bash
dotnet test AspNetCoreDemo.E2ETests
```

使用以下命令运行 Controller 的集成测试：

```bash
dotnet test AspNetCoreDemo.IntegrationTests
```

使用以下命令运行 Controller 的单元测试：

```bash
dotnet test AspNetCoreDemo.UnitTests
```

## 备忘

### Shadow Copy

在运行测试的时候复制代码并另行构建和运行测试，而不破坏原有的构建结果，这个功能叫做 Shadow Copy。它的好处是可以使得构建和测试并行。

但是带来的问题是在早期的 Rider 版本中无法对测试代码的 SUT 断点进行单步调试（可能是因为测试在另一个构建后的进程中运行），最新版本中这个问题好像不存在了（有待观察），如果相关问题依旧发生，可以通过添加并在 xUnit 的配置文件 `xunit.runner.json` 中配置如下参数关闭 Shadow Copy：

```json
{
  "shadowCopy": false
}
```

### 可以利用本 Demo 进行的演示

#### 演示符合测试金字塔的测试运行速度差异

1. 在 IDE 中运行全部测试。
2. 对比 UserController 的全部测试，会发运行速度有符合测试金字塔的明显差异。

#### 演示测试驱动开发的过程

1. 先写一个新的 Controller 的单元测试，Mock 掉 Repository，会发现驱动出不依赖 Asp.Net Core 路由相关特性（Attribute）的 Controller 代码。
2. 再写一个针对上述 Controller 的集成测试，Mock 掉 Repository，会驱动引入 Asp.Net Core 针对 Controller 的必要特性。
3. 再写一个针对上述 Controller 所依赖的 Repository 的集成测试，会驱动 Repository 的实现。
4. 再写一个针对上述 Controller 的端到端测试，弥补了之前两种集成测试的测试间隙，实现最终完成。