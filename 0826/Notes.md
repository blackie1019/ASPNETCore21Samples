# 筆記 #

https://github.com/doggy8088/AspNetCore21MvcSample

## app.use 與 middleware ##

- 以後需要 new object 的部分都需要移動至 startup.cs 內的 ConfigureServices 做宣告，從Ｃontroller調用
- app.run 一定需要有且只能放最後一行. app.use 可以放置在任意位置，但註冊順序會影響pipeline先後
- 自訂的 "路由" 來設定獨立的 Pipeline, 可以用在實際環境上的debug 與 logging ，根據特定條件印出內容

## 依性注入(DI) ##

- 如果reverse proxy 已經有設定安全與壓縮等效能處理與標頭，可以減少 middleware 的註冊

## User Secrets 與 環境變數 ##

- 開發使用 User Secrets
- 正式環境使用 環境變數

## Logging ##

- 設定為none 可以關閉
- 可設定 namespace 為劃分依據
- IncludeScopes 可以把 RequestId 與 ConnectionId 印出來, 更多可參考[How to include scopes when logging exceptions in ASP.NET Core](https://andrewlock.net/how-to-include-scopes-when-logging-exceptions-in-asp-net-core/)
    -  需要開啟 Microsoft 的 Namespace