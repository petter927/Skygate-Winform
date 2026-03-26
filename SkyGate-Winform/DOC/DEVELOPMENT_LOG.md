# 🚀 開發筆記 (Development Log) - SkyGate WinForm

## 📂 系統分層架構設計 (System Architecture)

為了實現 **「高內聚、低耦合」** 的開發目標，本專案捨棄了將邏輯全部擠在 UI 層的傳統做法，改採 **N-Tier (多層次) 架構** 設計。這確保了程式碼的可維護性，並為日後遷移至 Web 平台奠定了紮實基礎。

### 1. UI Layer (展示層)
* **組成**：`MainForm`、各種功能的 `UserControl`（如 `HRManagementUserControl`）。
* **職責**：專注於使用者互動與資料呈現。
* **技術決策**：
    * 透過 **事件驅動** 呼叫 Service 層。
    * 導入 `LayoutManager` 實作 **宣告式佈局**，統一管理控制項的顯示狀態與座標。

### 2. Service Layer (商業邏輯層)
* **組成**：`EmployeeService.cs` 等。
* **職責**：系統的「大腦」，負責處理核心業務規則。
* **技術決策**：
    * 封裝複雜邏輯（如：工時計算、多階層審核狀態流轉）。
    * 作為 UI 與 DAL 之間的橋樑，確保 UI 層不直接接觸資料庫實作。

### 3. DAL / Repository Layer (資料存取層)
* **組成**：`SqlHelper.cs`、`EmployeeRepository.cs` 等。
* **職責**：專門負責與 SQL Server 溝通，執行 CRUD 操作。
* **技術決策**：
    * **介面導向開發 (Interface-Based)**：定義 `IRepository` 介面，降低系統對特定資料庫的依賴。
    * **參數化查詢**：全面使用 `SqlParameter` 杜絕 SQL Injection 風險。
    * **事務管理**：利用 `SqlTransaction` 確保跨表操作的 **原子性 (Atomicity)**。

### 4. Models & Utilities (模型與工具)
* **Models**：定義 `Entity` (DB對應) 與 `DTO` (傳輸用)，確保層級間資料傳遞的嚴謹性。
* **Utilities**：
    * `ValidationHelper`：利用 **正規表示法 (Regex)** 進行門神級的資料預檢。
    * `LayoutManager`：解決 WinForm 佈局難以維護的痛點。

---

## 🔄 資料流向示意 (Data Flow)
`使用者輸入 (UI)` ➔ `格式驗證 (Utility)` ➔ `業務邏輯處理 (Service)` ➔ `資料庫操作 (Repository/DAL)` ➔ `SQL Server`

### 啟動與生命週期管理 (Application Lifecycle)

* **技術決策：採用 ApplicationContext**
    * **問題**：一般 WinForm 直接綁定單一 Form 作為進入點，難以處理「登入 -> 主畫面 -> 登出 -> 重新登入」的流轉。
    * **解法**：實作 `MainApplicationContext` 類別，統一管理視窗的開啟與關閉。
    * **好處**：
        1. 實現了 **「視窗解耦」**，LoginForm 與 MainForm 之間不互相依賴。
        2. 提供了更穩健的 **登出邏輯**，確保程式資源在切換視窗時能正確釋放。

### 系統啟動與視窗狀態切換 (MainApplicationContext)

* **設計動機**：
    解決傳統 WinForm 在切換「登入」與「主介面」時，容易造成視窗強耦合或資源釋放不完全的問題。
* **技術實現細節**：
    1. **事件驅動管理**：訂閱 `FormClosed` 事件，透過視窗關閉時傳遞的 `Tag` (例如 "LoggedIn", "LoggingOut") 決定下一個動作。
    2. **無縫登出機制**：實作 `LoggingOut` 狀態攔截，允許程式在不關閉進程的情況下，安全地銷毀主畫面並重新初始化登入畫面。
    3. **執行緒安全機制**：在切換視窗邏輯中加入 `InvokeRequired` 判斷，確保 UI 操作的穩定性，防止跨執行緒存取異常。

### 登入安全性與身分驗證 (LoginForm)

* **技術亮點：身分驗證流程**
    * **密碼防護**：捨棄明碼儲存，實作 **SHA-256 雜湊演算法**，確保資料庫遭洩漏時密碼安全性。
    * **預防 SQL 注入**：嚴格執行 **參數化查詢 (Parameterized Query)**，杜絕字串拼接帶來的資安風險。
* **業務邏輯設計**：
    * **多重驗證**：包含帳號存在性、密碼正確性及 `IsActive` (帳號啟用狀態) 的三段式檢核。
    * **軌跡紀錄**：登入成功自動觸發 `UpdateLastLogin` 紀錄使用者登入時間。
    * **狀態保持**：利用全域靜態類別 `UserInfo` 儲存登入者資訊，供全系統進行權限判斷 (RBAC) 使用。

### 全域狀態管理 (Session Management)

* **技術實現：UserInfo 靜態類別**
    * **目的**：實作類似 Web Session 的功能，在多個視窗 (Form) 與控制項 (UserControl) 之間共享當前登入者的身分資訊。
    * **安全性考量**：
        1. **集中管理**：統一存放 `EmpID` 與 `RoleName`，作為後續權限判斷 (RBAC) 的唯一來源。
        2. **顯式清理**：實作 `Clear()` 方法，配合 `MainApplicationContext` 的登出流程，確保使用者切換時舊有憑據會被完整銷毀，防止身分冒用。

### 組態配置管理 (Configuration Management)

* **技術實現：ConnectionStringHelper**
    * **動機**：避免連線字串 (Connection String) 硬編碼於程式碼中，提升部署的彈性與安全性。
    * **雙層取得邏輯 (Fallback Strategy)**：
        1. **生產環境優先**：優先嘗試讀取系統「環境變數」，符合現代化雲端部署與資安（不將敏感資訊存於檔案）的要求。
        2. **開發環境回退**：若無環境變數，則回歸讀取 `App.config`，確保開發團隊在本地端能快速啟動測試。
    * **異常防禦**：實作顯式的錯誤檢查機制，若設定缺失會主動告知正確的設定方式，降低系統維運的排錯成本。

### 主介面導覽與權限管理 (Main Navigation & RBAC)

* **設計觀點：單一視窗架構 (Single-Window Architecture)**
    * 採用 `UserControl` 切換機制，取代多視窗開啟，減少系統資源消耗並統一視覺風格。
* **技術決策：**
    1. **動態權限過濾**：實作 `ApplyRoleBasedPermissions`，在 `Form_Load` 時根據 `UserInfo` 角色自動決定功能按鈕的存取權（Visibility）。
    2. **UI 控制項快取**：利用 `Dictionary` 儲存已實例化的 `UserControl`，解決介面頻繁切換時產生的閃爍感，並提升反應速度。
    3. **自定義 UI 互動**：透過事件訂閱（如 `LogoutClicked`）與 `MainApplicationContext` 協作，實現完整的登出流程。

### 出勤登記模組 (Attendance Module)

* **技術實現：即時狀態與資源維護**
    * **實時介面更新**：利用 `System.Windows.Forms.Timer` 實作秒級時鐘顯示，提供精確的打卡時間參考。
    * **資源生命週期優化**：覆寫 `Dispose` 方法，確保在介面切換時主動停止並釋放 Timer 資源，防止記憶體洩漏與背景執行緒衝突。
* **資料一致性設計**：
    * **唯一識別碼生成**：設計 `GenerateLogID` 結合時間戳與隨機數，降低在高併發情境下 LogID 重複的風險。
    * **嚴謹的異常處理**：在 `Clock` 核心方法中加入 `try-catch` 塊，確保資料庫連線異常時能正確捕捉並透過 UI 回饋使用者。