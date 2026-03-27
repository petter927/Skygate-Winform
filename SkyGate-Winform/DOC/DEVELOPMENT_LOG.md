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

### 請假申請模組 (Leave Request Module)

* **功能定位**：支援員工本人或代理他人提出請假，並保留完整申請軌跡。
* **技術實現重點**：
    1. **工時規則計算**：`CalculateDurationHours` 依工作時段（08:00~17:00）、午休（12:00~13:00）與週末排除規則計算請假時數。
    2. **附件機制**：可多檔上傳，寫入 `SystemAttachment`，並以 GUID 重新命名避免檔名衝突。
    3. **通知流程**：申請成功後透過 SMTP (`localhost:25`) 發送通知信給主管。
* **資料設計**：
    * 主要寫入表：`LeaveRequest`（狀態預設 `申請中`）。
    * 附件表：`SystemAttachment`，`ReferenceType='LeaveRequest'`，以 `ReferenceID` 關聯請假單。
* **UI 互動補充**：
    * 歷史資料以 DataGridView 顯示，並以顏色區分狀態（核准/駁回/申請中）。
    * 支援雙擊單筆記錄查看完整請假細節。

### 請假審核模組 (Leave Approval Module)

* **功能定位**：主管審核其所屬員工的待簽核請假單。
* **技術實現重點**：
    1. **主管視角過濾**：僅載入 `Status='申請中'` 且員工主管為目前登入者 (`UserInfo.EmpID`) 的資料。
    2. **審核備註追記**：在 `Remark` 欄位串接主管審核意見與時間戳，保留歷程。
    3. **附件調閱**：可載入附件清單並下載到本機指定路徑。
* **業務規則**：
    * 駁回必填主管備註。
    * 核准/駁回皆回寫 `ApproverID` 與 `Status`。

### 加班申請模組 (OT Request Module)

* **功能定位**：員工送出單日加班申請並查詢當月申請紀錄。
* **技術實現重點**：
    1. **加班時數驗證與計算**：`CalculateOvertimeHours` 實作平日/假日規則，限制單次申請上限（平日 4 小時、假日 12 小時）。
    2. **邏輯約束**：禁止跨日申請；平日不得覆蓋正常上班時段（08:00~17:00）。
    3. **歷史資料查詢**：預設載入當月紀錄，並顯示加班單號、時段、時數與狀態。
* **資料設計**：
    * 主要寫入表：`OverTimeRequest`（狀態預設 `申請中`，初始 `ApproverID` 為空）。
    * `Remark` 內文以標記片段（如 `#理由-...-理由#`）儲存申請理由，供畫面解析使用。

### 加班審核模組 (OT Approval Module)

* **功能定位**：主管審核部屬加班申請，並回寫核決結果。
* **技術實現重點**：
    1. **待審清單**：以主管身分載入 `申請中` 的加班單。
    2. **審核結果封裝**：將主管回覆寫入 `Remark` 的特定標記區塊（`#審核結果-...-審核結果#`）。
    3. **流程一致性**：核准/駁回皆同步更新 `Status` 與 `ApproverID`。
* **UI 互動補充**：
    * 選取清單列時自動帶入單據詳細欄位。
    * 送出後即時刷新清單，避免重複審核。

### 紀錄查詢模組 (Attendance/Leave/OT Report Module)

* **功能定位**：提供員工在指定日期區間查詢請假與加班記錄。
* **技術實現重點**：
    1. **報表類型切換**：同一頁面用 `cmbReportType` 切換請假與加班 SQL。
    2. **條件查詢**：透過開始/結束日期與 `EmpID` 參數化過濾資料。
    3. **前端篩選**：DataTable 搭配 `DataView.RowFilter` 實作狀態快速過濾（全部/申請中/核准/駁回）。
* **現況說明**：
    * `btnSubmit` 已串接查詢。
    * `btnRefreshHistory` 目前保留為空事件（尚未綁定行為）。

### 人事管理模組 (HR Management Module)

* **功能定位**：提供人事人員進行員工資料的新增、查詢、修改、狀態管理。
* **技術實現重點**：
    1. **分層呼叫**：UI 透過 `IEmployeeService / IDepartmentService / ISysRoleService` 操作，避免直接寫 SQL。
    2. **版面狀態管理**：利用 `LayoutManager` 管理 Add/Find/Edit/Delete 模式下欄位顯示與位置。
    3. **資料快取回填**：搜尋結果快取於 `_employeeHRViewModels`，點選 DGV 即可快速帶入詳細欄位。
* **交易一致性**：
    * `EmployeeService.CreateEmployee` 與 `UpdateEmployeeForEdit` 內含交易流程，確保員工主檔與角色資料一致。
    * 成功異動時寫入系統日誌 (`SysLog`) 追蹤操作人與目標資料。

### 系統管理模組 (System Management Module)

* **現況**：
    * `SystemManagementUserControl` 已建立並接入主導航與 RBAC，但目前內容尚未實作。
* **規劃建議**：
    1. 角色/權限維護（Role 與功能對照）。
    2. 帳號啟用停用與密碼重設。
    3. 系統參數維護（Mail、附件路徑、工作時段規則）。

---

## 🧩 目前未完成 / 技術債清單 (TODO & Tech Debt)

### P0 - 回頭維護時先看
1. **SystemManagement 功能未落地**：目前只有空白 UserControl。
2. **報表 Refresh 按鈕未綁定**：`AttendanceReportUserControl.btnRefreshHistory_Click` 尚未實作。
3. **註解與命名不一致**：部分方法名大小寫/拼字不一（如 `Initialze*`, `loadOTRequstList`），後續可統一。

### P1 - 穩定性與可維運性
1. **SMTP 目前為本機測試設定**：`sender@test.local` + `localhost:25` 適合開發環境，部署時需切換正式設定。
2. **Remark 字串標記解析耦合高**：請假/加班理由與審核意見目前以字串標記封裝，未來建議拆欄位或改 JSON 結構儲存。
3. **部分 Repository 仍有未完成 stub**：例如 `GetEmployeesByDept`、`UpdateEmployee` 目前是占位實作。

### P2 - 中長期優化
1. **補齊單元測試**：先從 Service 層（工時/審核規則）開始。
2. **資料存取一致化**：目前 ADO.NET 為主，若持續擴充可逐步統一查詢封裝風格。
3. **錯誤訊息集中化**：將 UI 文字與例外處理策略集中管理，降低重複程式碼。

---

## 🗺 回坑快速導覽 (When I Come Back)

1. **先看啟動流程**：`Program.cs` -> `MainApplicationContext.cs`（掌握登入/登出生命週期）。
2. **再看權限入口**：`Form1.cs` 的 `ApplyRoleBasedPermissions()` 與 `HasPermission()`。
3. **看當前重點功能**：
    * 請假：`LeaveRequestUserControl.cs`、`LeaveApproveUserControl.cs`
    * 加班：`OTRequestUserControl.cs`、`OTApproveUserControl.cs`
    * 人事：`HRManagementUserControl.cs` + `EmployeeService.cs`
4. **最後補系統管理模組**：`SystemManagementUserControl.cs`（目前待開發）。