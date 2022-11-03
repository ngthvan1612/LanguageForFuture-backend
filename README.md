# **Language for future** backend

[![.NET Foundation](https://img.shields.io/badge/.NET%20Foundation-blueviolet.svg)](https://www.dotnetfoundation.org/)

<img src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg" width="48px"/>
<img src="./images/aspnetcore.png" width="48px"/>
<img src="./images/swagger.256x256.png" width="48px"/>

![](header.png)

## Yêu cầu phần mềm

1. Runtime:
    - Dotnet CLI
    - Microsoft Visual Studio (>= 2015), visual studio code (optimal)

2. Testing:
    - Postman (desktop version)

3. Deloy:
    - File-zila Client
    - Plesk

## Chạy project

1. Chạy cứng

```sh
cd LFF.API
dotnet run
```

2. Tự động refresh lại project khi có thay đổi
```sh
cd LFF.API
dotnet watch run
```

## Deloy

1. Deploy vào BKHOST

> Tài khoản vào host đã có gửi trên zalo

1.1. Note
  - Sử dụng OutOfProcess để deploy
  - Grant toàn quyền của Application Pool vào thư mục deloy
