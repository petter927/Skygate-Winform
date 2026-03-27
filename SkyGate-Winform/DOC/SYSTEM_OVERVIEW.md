# System Overview - SkyGate WinForm

## 專案定位

SkyGate WinForm 是一套以 WinForms 實作的人資與出勤管理系統，涵蓋登入驗證、出勤打卡、請假/加班申請與審核、報表查詢、人事維護等流程。

---

## 系統分層架構 (N-Tier)

### 1) UI Layer
- 組成：`Form1`、`LoginForm`、各功能 `UserControl`
- 職責：接收使用者操作、顯示資料、觸發 Service 層
- 特點：以單視窗 + 多 UserControl 切換，降低多視窗耦合

### 2) Service Layer
- 組成：如 `EmployeeService`
- 職責：封裝商業規則（驗證、流程控制、交易協調）
- 特點：隔離 UI 與資料存取細節

### 3) Repository / DAL Layer
- 組成：如 `EmployeeRepository`、`DepartmentRepository`
- 職責：與 SQL Server 互動、執行查詢與 CRUD
- 特點：介面導向 + 參數化查詢 + 交易控制

### 4) Models / Utilities
- Models：`Entity`、`DTO`、`ViewModel`
- Utilities：`ValidationHelper`、`LayoutManager` 等

---

## 主要資料流

`UI Input` -> `Validation` -> `Service Rule` -> `Repository SQL` -> `SQL Server`

---

## 啟動與生命週期

### Application Context
- 入口：`Program` 啟動 `MainApplicationContext`
- 核心目的：管理 `LoginForm <-> Form1` 切換，不依賴單一主視窗生命週期
- 實作方式：利用 `Tag` (`LoggedIn`, `LoggingOut`) + `FormClosed` 事件驅動切換

### Session 狀態
- 使用 `UserInfo` 儲存登入者資訊（`EmpID`, `EmpName`, `RoleName`）
- 提供 `Clear()` 供登出時清理狀態

---

## 權限模型 (RBAC)

- 在 `Form1` 載入時執行 `ApplyRoleBasedPermissions`
- 依 `RoleName` 動態控制功能按鈕可見性
- 預設角色包含：員工、主管、人事、系統管理員

---

## 功能模組摘要

### Attendance
- 打卡資料寫入
- 顯示即時時間
- 具基礎例外處理

### Leave Request
- 可選請假者、假別、起訖時間與理由
- 自動計算請假時數（含工作時段/午休/週末規則）
- 支援附件上傳並寫入 `SystemAttachment`
- 送單後可寄通知給主管

### Leave Approval
- 主管審核待簽核請假單
- 核准/駁回回寫 `Status`、`ApproverID`、`Remark`
- 可查看與下載附件

### OT Request
- 單日加班申請
- 平日/假日時數規則與上限控制
- 查詢當月歷史申請

### OT Approval
- 主管審核待簽核加班單
- 回寫審核狀態與審核備註

### Attendance Report
- 區間查詢請假/加班資料
- 可依狀態篩選顯示

### HR Management
- 員工資料新增/查詢/修改/狀態管理
- 透過 Service 協調員工主檔與角色資料一致性
- 使用 `LayoutManager` 管理不同操作模式

### System Management
- 已接入導航與權限
- 目前內容尚未落地

---

## 組態與部署重點

- 連線字串來源：優先環境變數，次選 `App.config`
- Mail 設定目前偏開發用途（localhost SMTP）

---

## 回坑快速導覽

1. 先看啟動：`Program.cs` -> `MainApplicationContext.cs`
2. 再看權限：`Form1.cs` 的角色按鈕可見邏輯
3. 看流程主線：
   - 請假：`LeaveRequestUserControl.cs`、`LeaveApproveUserControl.cs`
   - 加班：`OTRequestUserControl.cs`、`OTApproveUserControl.cs`
   - 人事：`HRManagementUserControl.cs`、`EmployeeService.cs`
4. 待補區：`SystemManagementUserControl.cs`
