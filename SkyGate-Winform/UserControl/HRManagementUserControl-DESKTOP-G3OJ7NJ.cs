using SkyGate_ADONET.Models.DTOs;
using SkyGate_ADONET.Models.enums;
using SkyGate_ADONET.Services;
using SkyGate_ADONET.Services.Interfaces;
using SkyGate_ADONET.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SkyGate_ADONET.Enums;
using SkyGate_ADONET.Models.enums;
using System.Xml.Linq;
using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Utilities;
using System.Drawing;
using System.Linq;

namespace SkyGate_ADONET
{
    public partial class HRManagementUserControl : UserControl
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ISysRoleService _sysRoleService;
        private readonly ISysUserRoleService _sysUserRoleService;
        private LayoutManager layoutManager;
        private string _functionName;//功能旗標
        private List<EmployeeHRViewModel> _employeeHRViewModels;//快取資料, 便於選取DGV時轉資料到控制項顯示

        public HRManagementUserControl()
        {
            InitializeComponent();

            var employeeRepo = new EmployeeRepository();
            var deptRepo = new DepartmentRepository();
            var logRepo = new SysLogRepository();
            var sysRoleRepo = new SysRoleRepository();
            var sysUserRoleRepo = new SysUserRoleRepository();

            _employeeService = new EmployeeService(employeeRepo, deptRepo, logRepo, sysRoleRepo, sysUserRoleRepo);
            _departmentService = new DepartmentService(deptRepo);
            _sysRoleService = new SysRoleService(sysRoleRepo);
            _sysUserRoleService = new SysUserRoleService(sysUserRoleRepo);

            InitializeDGV();
            InitializeControls();
            InitializeLayoutManager();            
        }


        private void InitializeDGV() 
        {
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.SelectionChanged += DataGridViewEmployees_SelectionChanged;            
            //dataGridViewEmployees.ClearSelection();
            dataGridViewEmployees.ReadOnly = true;
            dataGridViewEmployees.RowHeadersVisible = false;
            dataGridViewEmployees.Visible = false;
            dataGridViewEmployees.AllowUserToAddRows = false;
        }

        private void InitializeControls()
        {
            var departments = _departmentService.GetAllDepartments();
            departments.Insert(0, new Department { DeptID = string.Empty, DeptName = "請選擇" });
            cmbDept.DataSource = departments;
            cmbDept.DisplayMember = "DeptName";
            cmbDept.ValueMember = "DeptID";

            var supervisors = _employeeService.GetSupervisors();
            supervisors.Insert(0, new Employee { EmpID = string.Empty, EmpName = "請選擇" });
            cmbSupervisor.DataSource = supervisors;
            cmbSupervisor.DisplayMember = "EmpName";
            cmbSupervisor.ValueMember = "EmpID";

            cmbEStatus.DataSource = Enum.GetValues(typeof(EmployeeStatus));

            var sysroles = _sysRoleService.GetAllSysRoles();
            sysroles.Insert(0, new SysRole { RoleID = string.Empty, RoleName = "請選擇" });
            cmbRole.DataSource = sysroles;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleID";
            
            btnSubmit.Visible = false;

            btnAdd.BackColor = System.Drawing.Color.Green;
            btnAdd.ForeColor = System.Drawing.Color.White;

            btnEdit.BackColor = System.Drawing.Color.Green;
            btnEdit.ForeColor = System.Drawing.Color.White;

            btnFind.BackColor = System.Drawing.Color.Green;
            btnFind.ForeColor = System.Drawing.Color.White;

            btnDel.BackColor = System.Drawing.Color.Green;
            btnDel.ForeColor = System.Drawing.Color.White;
        }
        
        private void InitializeLayoutManager()
        {            
            layoutManager = new LayoutManager(new Point(120, 120), 30);//設定輸入項的座標起點, 及每次增量

            layoutManager.RegisterLayout("AddTxt", "Txt", txtEID, txtEName, cmbDept, txtETitle, cmbSupervisor, cmbEStatus, txtEHireDate, txtELeaveDate, txtEEmail, txtEphone, cmbRole);
            layoutManager.RegisterLayout("AddLbl", "Lbl", lblEID, lblEName, lblEDept, lblETitle, lblSupervisor, lblEStatus, lblEHireDate, lblELeaveDate, lblEEmail, lblEphone, lblERole);

            layoutManager.RegisterLayout("FindTxt", "Txt", txtEID, txtEName, cmbDept, txtETitle, cmbSupervisor);
            layoutManager.RegisterLayout("FindLbl", "Lbl", lblEID, lblEName, lblEDept, lblETitle, lblSupervisor);

            layoutManager.RegisterLayout("EditTxt", "Txt", txtEID, txtEName, cmbDept, txtETitle, cmbSupervisor, cmbEStatus, txtEHireDate, txtELeaveDate, txtEEmail, txtEphone, cmbRole);
            layoutManager.RegisterLayout("EditLbl", "Lbl", lblEID, lblEName, lblEDept, lblETitle, lblSupervisor, lblEStatus, lblEHireDate, lblELeaveDate, lblEEmail, lblEphone, lblERole);

            layoutManager.RegisterLayout("DeleteTxt", "Txt", txtEID, txtEName, cmbDept, txtETitle, cmbSupervisor, cmbEStatus, txtEHireDate, txtELeaveDate, txtEEmail, txtEphone, cmbRole);
            layoutManager.RegisterLayout("DeleteLbl", "Lbl", lblEID, lblEName, lblEDept, lblETitle, lblSupervisor, lblEStatus, lblEHireDate, lblELeaveDate, lblEEmail, lblEphone, lblERole);

            layoutManager.HideAll();

        }

        private int GetEnumsCode()
        {
            int code = (int)(EmployeeStatus)cmbEStatus.SelectedValue;
            return code;
        }
        private EmployeeStatus GetStatusCodeByName(string statusWord)
        {
            Enum.TryParse<EmployeeStatus>(statusWord, out EmployeeStatus status);

            return status; 
        }

        private void ShowSearchedToDGV(List<EmployeeHRViewModel> results)
        {
            var sortableList = new SortableBindingList<EmployeeHRViewModel>(results);
            dataGridViewEmployees.DataSource = sortableList;
            FormatDataGridView();
        }

        private (List<EmployeeHRViewModel>, string message) LoadSearchEmployees(EmployeeSearchCriteria searchCriteria)
        {
            try
            {
                var results = _employeeService.SearchEmployees(searchCriteria);
                if (results != null && results.Count > 0)
                {
                    return (results, $"找到 {results.Count} 筆符合的員工資料");
                }
                else
                {
                    return (new List<EmployeeHRViewModel>(), "查無符合的員工資料");
                }
            }
            catch (Exception ex)
            {
                return (new List<EmployeeHRViewModel>(), $"查詢時發生錯誤: {ex.Message}");
            }
        }
        private bool SubmitEditOrDeleteEmployee()
        {
            var searchCriteria = new EmployeeSearchCriteria
            {
                EmpID = txtEID.Text.Trim(),
            };

            var (results, message) = LoadSearchEmployees(searchCriteria);
            if (results.Count > 0)
            {
                ShowSearchedToDGV(results);
                _employeeHRViewModels = results;
                if (_functionName != "Add") MessageBox.Show(message);
                return true;
            }
            else
            {
                MessageBox.Show(message);
                return false;
            }
        }

        private void FormatDataGridView()
        {
            if (dataGridViewEmployees.Columns.Count > 0)
            {
                dataGridViewEmployees.Columns["EmpID"].HeaderText = "員工編號";
                dataGridViewEmployees.Columns["EmpName"].HeaderText = "姓名";
                dataGridViewEmployees.Columns["DeptName"].HeaderText = "部門";
                dataGridViewEmployees.Columns["Title"].HeaderText = "職稱";
                dataGridViewEmployees.Columns["SupervisorName"].HeaderText = "直屬主管";
                dataGridViewEmployees.Columns["StatusText"].HeaderText = "狀態";
                dataGridViewEmployees.Columns["HireDate"].HeaderText = "到職日";
                dataGridViewEmployees.Columns["RoleName"].HeaderText = "角色";
            }
        }

        private void ClearForm()
        {
            txtEID.Clear();
            txtEName.Clear();
            txtETitle.Clear();
            txtEEmail.Clear();
            txtEphone.Clear();
            txtEHireDate.Clear();
            txtELeaveDate.Clear();

            cmbDept.SelectedIndex = 0;
            cmbSupervisor.SelectedIndex = 0;
            cmbRole.SelectedIndex = 0;
            cmbEStatus.SelectedIndex = 0;

            //UiHelpers.SetComboDefault(cmbDept);
            //UiHelpers.SetComboDefault(cmbSupervisor);
            //UiHelpers.SetComboDefault(cmbRole);
            //UiHelpers.SetComboDefault(cmbEStatus);
        }

        private void SubmitAddEmployee()
        {
            try
            {
                var createdto = new EmployeeCreateDto
                {
                    //EmpID = txtEID.Text.Trim(),
                    EmpName = txtEName.Text.Trim(),
                    DeptID = cmbDept.SelectedValue.ToString(),
                    Title = txtETitle.Text.Trim(),
                    SupervisorID = cmbSupervisor.Text,
                    //Status = txtEStatus.Text.Trim(),
                    //HireDate = txtEHireDate.Text.Trim(),
                    //LeaveDate = txtELeaveDate.Text.Trim(),  
                    Email = txtEEmail.Text.Trim(),
                    Phone = txtEphone.Text.Trim(),
                    RoleID = cmbRole.Text,
                };
                (bool success, string message, string newID) = _employeeService.CreateEmployee(createdto);
                if (success)
                {
                    txtEID.Text = newID;
                    SubmitEditOrDeleteEmployee();
                    ShowEmployeeDetailFromCache(newID);
                    MessageBox.Show(message);
                }
                else { MessageBox.Show($"錯誤訊息:{message}"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TryCatch失敗啦");
            }
        }
        private bool SubmitEditEmployee()
        {
            try
            {
                var editdto = new EmployeeEditDto
                {
                    EmpID = txtEID.Text.Trim(),
                    EmpName = txtEName.Text.Trim(),
                    DeptID = cmbDept.SelectedValue.ToString(),
                    Title = txtETitle.Text.Trim(),
                    SupervisorID = cmbSupervisor.SelectedValue.ToString(),
                    Status = GetEnumsCode().ToString(),
                    HireDate = txtEHireDate.Text.Trim(),
                    LeaveDate = txtELeaveDate.Text.Trim(),  
                    Email = txtEEmail.Text.Trim(),
                    Phone = txtEphone.Text.Trim(),
                    RoleID = cmbRole.SelectedValue.ToString(),
                };                
                (bool success, string message) = _employeeService.UpdateEmployeeForEdit(editdto);
                if (success)
                {
                    MessageBox.Show(message);
                    return true;
                }
                else 
                {
                    MessageBox.Show($"錯誤訊息:{message}"); 
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SubmitEditEmployee的TryCatch失敗啦");
                return false;
            }
        }

        private bool SubmitFindEmployee()
        {
            var searchCriteria = new EmployeeSearchCriteria
            {
                EmpID = txtEID.Text.Trim(),
                EmpName = txtEName.Text.Trim(),
                DeptID = cmbDept.SelectedValue?.ToString(),
                Title = txtETitle.Text.Trim(),
                SupervisorID = cmbSupervisor.SelectedValue?.ToString()
            };
            // 如果沒有任何搜尋條件
            if (!searchCriteria.HasCriteria())
            {
                MessageBox.Show("請輸入至少一個搜尋條件");
                return false;
            }
            var (results, message) = LoadSearchEmployees(searchCriteria);
            if (results.Count > 0)
            {
                _employeeHRViewModels = results;
                ShowSearchedToDGV(results);   
                MessageBox.Show(message);
                return true;
            }
            else
            {
                MessageBox.Show(message);
                return false;
            }            
        }

        

        private bool SubmitDeleteEmployee()
        {
            try
            {
                string empid = txtEID.Text.Trim();

                var (success, message) = _employeeService.ChangeEmployeeStatus(empid, (int)EmployeeStatus.離職);                
                if (success)
                {
                    MessageBox.Show(message);
                    return true;
                }
                else 
                { 
                    MessageBox.Show($"錯誤訊息:{message}"); 
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SubmitDeleteEmployee失敗啦");
                return false;
            }

        }
        private void ShowDataGridView()
        {
            dataGridViewEmployees.Visible = true;
        }
        private void ShowSubmitButton()
        {
            btnSubmit.Visible = true;
        }
        private void ClearDGV()
        {
            dataGridViewEmployees.DataSource = null;
        }
        private void ResetAll()
        {
            ClearForm();
            ClearDGV();
            layoutManager.EnableAllInput(true);            
            _employeeHRViewModels = null;
            ShowDataGridView();
            ShowSubmitButton();
        }
        /// <summary>
        /// 僅根據功能修改UI介面
        /// </summary>
        /// <param name="functionName"></param>
        private void ChangeFunction(string functionName)
        {
            ResetAll();
            _functionName = functionName;
            switch (functionName)
            {
                case "Add":
                    layoutManager.Show2Layout("AddTxt", "AddLbl");                    
                    layoutManager.SetTextBoxReadonly(new string[] { "txtEID", "txtEHireDate", "txtELeaveDate" });
                    cmbEStatus.SelectedItem = EmployeeStatus.在職;
                    ChangeBtnText(btnSubmit, "送出新增資料");
                    ChangeHRMessage("新增員工資料");
                    break;

                case "Find":
                    layoutManager.Show2Layout("FindTxt", "FindLbl");
                    ChangeBtnText(btnSubmit, "送出查詢資料");
                    ChangeHRMessage("查詢員工資料");
                    break;

                case "BeforeDelete":
                    layoutManager.Show2Layout("FindTxt", "FindLbl");
                    ChangeBtnText(btnSubmit, "送出查詢資料");
                    ChangeHRMessage("刪除員工資料-請先輸入查詢資料");
                    break;

                case "BeforeEdit":
                    layoutManager.Show2Layout("FindTxt", "FindLbl");
                    ChangeBtnText(btnSubmit, "送出查詢資料");
                    ChangeHRMessage("修改員工資料-請先輸入查詢資料");
                    break;
            }
        }

        private void ChangeBtnText(Button btn, string name)
        {
            btn.Text = name;
        }
        private void ChangeHRMessage(string message)
        {
            lblHRMessage.Text = message;
        }
        /// <summary>
        /// 依功能完成CRUD動作
        /// </summary>
        private void SubmitByType()
        {
            switch (_functionName)
            {
                case "Add":
                    SubmitAddEmployee();
                    break;

                case "Find":
                    if (SubmitFindEmployee())
                    {
                        layoutManager.Show2Layout("AddTxt", "AddLbl");                        
                        layoutManager.EnableAllInput(false);
                    }                    
                    break;

                case "Delete":

                    if (MessageBox.Show($"確定刪除員工編號: {txtEID.Text}-{txtEName.Text} 的員工資料嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes && cmbEStatus.Text!="離職")
                    {
                        if (SubmitDeleteEmployee())
                        {
                            SubmitEditOrDeleteEmployee();
                            ChangeBtnText(btnSubmit, "已完成刪除資料");
                            _functionName = "";
                        }                        
                    }
                    else if (cmbEStatus.Text == "離職")
                    {
                        MessageBox.Show("該員工已為離職狀態，無法重複刪除");
                    }


                    break;

                case "Edit":
                    if (MessageBox.Show($"確定修改員工編號: {txtEID.Text}-{txtEName.Text} 的員工資料嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (SubmitEditEmployee())
                        {
                            SubmitEditOrDeleteEmployee();
                            ChangeBtnText(btnSubmit, "已完成修改資料");
                            _functionName = "";
                        }                        
                    }

                        break;
                case "BeforeDelete":
                    if (SubmitFindEmployee())
                    {
                        _functionName = "Delete";
                        layoutManager.Show2Layout("DeleteTxt", "DeleteLbl");
                        layoutManager.EnableAllInput(false);                          
                        ChangeBtnText(btnSubmit, "送出刪除資料");
                        ChangeHRMessage("刪除員工資料-選擇要刪除的員工資料");                        
                    }
                    
                    break;

                case "BeforeEdit":
                    if (SubmitFindEmployee())
                    {
                        _functionName = "Edit";
                        layoutManager.Show2Layout("EditTxt", "EditLbl");                        
                        string[] controlNmae = { "txtEID", "txtEHireDate", "txtELeaveDate" };
                        layoutManager.SetTextBoxReadonly(controlNmae);
                        ChangeBtnText(btnSubmit, "送出修改資料");
                        ChangeHRMessage("修改員工資料-選擇要修改的員工資料");
                    }                        
                    break;

                default:

                    break;
            }
        }

        private void DataGridViewEmployees_SelectionChanged(object sender, EventArgs e)
        {            
            var n = dataGridViewEmployees.SelectedRows.Count;            
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {                
                DataGridViewRow selectedRow = dataGridViewEmployees.SelectedRows[0];
                var empid = selectedRow.Cells["EmpID"]?.Value?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(empid))
                {                    
                    ShowEmployeeDetailFromCache(empid);
                }
            }
        }

        private void ShowEmployeeDetailFromCache(string empID)
        {            
            if (_employeeHRViewModels != null)
            {                
                var emp = _employeeHRViewModels.FirstOrDefault(e => e.EmpID == empID);                          

                txtEID.Text = emp.EmpID;
                txtEName.Text = emp.EmpName;                
                cmbDept.SelectedValue = GetCmbValueByName(cmbDept, emp.DeptName);                
                txtETitle.Text = emp.Title;                
                cmbSupervisor.SelectedValue = GetCmbValueByName(cmbSupervisor, emp.SupervisorName);                
                cmbEStatus.SelectedItem = GetStatusCodeByName(emp.StatusText);
                txtEHireDate.Text = emp.HireDate;                
                txtELeaveDate.Text = emp.LeaveDate;                
                txtEEmail.Text = emp.Email;
                txtEphone.Text = emp.Phone;
                cmbRole.SelectedValue = GetCmbValueByName(cmbRole, emp.RoleName);
            }
        }

        public string GetCmbValueByName(ComboBox cmb, string Name)
        {            
            int index = cmb.FindString(Name);

            if (index >= 0)
            {                
                cmb.SelectedIndex = index;
                string value = cmb.SelectedValue?.ToString() ?? string.Empty;
                return (value);
            }
            return (string.Empty);
        }

        private void HRManagementUserControl_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChangeFunction("Add");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeFunction("BeforeEdit");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ChangeFunction("Find");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ChangeFunction("BeforeDelete");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitByType();
        }
    }
}