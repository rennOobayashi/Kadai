using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week04Homework
{
    public partial class FormManager: Form
    {
        //instance field or memeber var
        Department[] departments;
        List<Professor> professors;
        Dictionary<string, Student> students;
        Student selectedStudent = null;
        List<Grade> testGrades;
        TextBox[] tbxTestScores;

        //생성자
        //인스턴스 생성시 초기화가 필요한 코드를 넣어줌
        public FormManager()
        {
            InitializeComponent();

            departments = new Department[100];
            professors = new List<Professor>();
            students = new Dictionary<string, Student>();
            testGrades = new List<Grade>();
            tbxTestScores = new TextBox[] {
                tbxTestScore1,
                tbxTestScore2,
                tbxTestScore3, 
                tbxTestScore4, 
                tbxTestScore5, 
                tbxTestScore6, 
                tbxTestScore7, 
                tbxTestScore8, 
                tbxTestScore9
            };

            for (int i = 1; i <= 4; ++i)
            {
                cmbYear.Items.Add(i);
            }

            cmbClass.Items.AddRange(new object[] {"A", "B", "C"});

            cmbRegStatus.Items.Add("재학");
            cmbRegStatus.Items.Add("졸업");
            cmbRegStatus.Items.Add("휴학");
            cmbRegStatus.Items.Add("퇴학");
        }

        private void btnRegisterDepartment_Click(object sender, EventArgs e)
        {
            Department dept = new Department();

            dept.Code = tbxDepartmentCode.Text;
            dept.Name = tbxDepartmentName.Text;

            //학과코드랑 이름이 비어있으면 안됨(과제)
            if (dept.Code == "" || dept.Name == "")
            {
                if (dept.Code == "")
                {
                    MessageBox.Show("학과 코드가 비어있습니다.");
                    tbxDepartmentCode.Focus();
                }
                else if (dept.Name == "")
                {
                    MessageBox.Show("이름이 비어있습니다.");
                    tbxDepartmentName.Focus();
                }
                else
                {
                    MessageBox.Show("학과 코드와 이름이 비어있습니다.");
                    tbxDepartmentCode.Focus();
                }

                return;
            }

            int index = -1;

            for (int i = 0; i < departments.Length; ++i)
            {
                if (departments[i] == null && index < 0)
                {
                    index = i;
                }
                else if (departments[i] != null && departments[i].Code == tbxDepartmentCode.Text)
                {
                    MessageBox.Show("이미 등록되어있는 학과입니다.");

                    return;
                }
            }

            if (index < 0)
            {
                MessageBox.Show("학과 리스트가 가득차 있습니다.");

                return;
            }

            departments[index] = dept;

            lbxDepartment.Items.Add(dept);
            //Only use for test
            //lbxDepartment.Items.Add(dept.Code);
            //lbxDepartment.Items.Add(dept.Name);
            //lbxDepartment.Items.Add($"[{dept.Code}] {dept.Name}");
        }

        private void btnRemoveDepartment_Click(object sender, EventArgs e)
        {
            if (lbxDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("삭제하실 학과를 선택하여주세요.");
                return;
            }

            //is 연산자, 타입 확인용으로 사용
            if (lbxDepartment.SelectedItem is Department)
            {
                var target = (Department)lbxDepartment.SelectedItem;

                for (int i = 0; i < departments.Length; ++i)
                {
                    if (departments[i] != null && departments[i] == target)
                    {
                        departments[i] = null;
                        break;
                    }
                }

                lbxDepartment.Items.RemoveAt(lbxDepartment.SelectedIndex);

                //선택 해제
                lbxDepartment.SelectedIndex = -1;
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMain.SelectedIndex)
            {
                case 0: 
                    break;
                case 1:
                    cmbProfessorDepartment.Items.Clear();
                    foreach (var department in departments)
                    {
                        if (department != null)
                        {
                            cmbProfessorDepartment.Items.Add(department);
                        }
                    }

                    cmbProfessorDepartment.SelectedIndex = -1;
                    lbxProfessor.Items.Clear();
                    break;
                case 2:
                    cmbDepartment.Items.Clear();
                    cmbAdvisor.Items.Clear();

                    foreach (var department in departments)
                    {
                        if (department != null)
                        {
                            cmbDepartment.Items.Add(department);
                        }
                    }

                    ResetStudentInfo();
                    break;
                case 3:
                    tbxTestNumber.Text = "20";
                    ClearTestScoreInfo();
                    break;
                default:
                    break;
            }
        }

        private void cmbProfessorDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxProfessor.Items.Clear();

            //as 형변환 연산자
            //형변환이 정상적이지 않으면 null 반환(struct 계열은 불가)
            var department = cmbProfessorDepartment.SelectedItem as Department;

            if (department == null || cmbProfessorDepartment.SelectedIndex < 0)
            {
                return;
            }

            foreach(var professor in professors)
            {
                if (professor != null && professor.DepartmentCode == department.Code)
                {
                    lbxProfessor.Items.Add(professor);
                }
            }
        }

        private void btnRegisterProfessor_Click(object sender, EventArgs e)
        {
            Professor prof = new Professor();

            if (cmbProfessorDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("학과를 선택해주세요.");
                cmbProfessorDepartment.Focus();
                return;
            }

            prof.DepartmentCode = ((Department)cmbProfessorDepartment.SelectedItem).Code;
            prof.Number = tbxProfessorNumber.Text;
            prof.Name = tbxProfessorName.Text;

            //학과코드랑 이름이 비어있으면 안됨(과제)
            if (prof.DepartmentCode == "" || prof.Number == "" || prof.Name == "")
            {
                if (prof.DepartmentCode == "")
                {
                    MessageBox.Show("학과 코드가 비어있습니다.");
                    cmbProfessorDepartment.Focus();
                }
                else if (prof.Number == "")
                {
                    MessageBox.Show("번호가 비어있습니다.");
                    tbxProfessorNumber.Focus();
                }
                else if (prof.Name == "")
                {
                    MessageBox.Show("이름이 비어있습니다.");
                    tbxProfessorName.Focus();
                }
                else
                {
                    MessageBox.Show("학과 코드와 번호, 이름이 비어있습니다.");
                    tbxProfessorNumber.Focus();
                }

                return;

            }

            if (professors.Count <= 0)
            {
                professors.Add(prof);
                lbxProfessor.Items.Add(prof);

                return;
            }

            for (int i = 0; i < professors.Count; ++i)
            {
                if (professors[i] != null && professors[i].Number == tbxProfessorNumber.Text)
                {
                    MessageBox.Show("이미 등록되어있는 교수입니다.");

                    return;
                }
            }

            professors.Add(prof);

            lbxProfessor.Items.Add(prof);
        }

        private void btnRemoveProfessor_Click(object sender, EventArgs e)
        {
            if (lbxProfessor.SelectedIndex < 0)
            {
                MessageBox.Show("삭제하실 교수를 선택하여주세요.");
                return;
            }

            //is 연산자, 타입 확인용으로 사용
            if (lbxProfessor.SelectedItem is Professor)
            {
                var target = (Professor)lbxProfessor.SelectedItem;

                for (int i = 0; i < professors.Count; ++i)
                {
                    if (professors[i] == target)
                    {
                        professors.Remove(target);
                        break;
                    }
                }

                lbxProfessor.Items.Remove(target);

                //선택 해제
                lbxProfessor.SelectedIndex = -1;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAdvisor.Items.Clear();

            var department = cmbDepartment.SelectedItem as Department;

            if (department == null || cmbDepartment.SelectedIndex < 0)
            {
                return;
            }

            foreach (var professor in professors)
            {
                if (professor != null && professor.DepartmentCode == department.Code)
                {
                    cmbAdvisor.Items.Add(professor);
                }
            }

            cmbAdvisor.SelectedIndex = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetStudentInfo();
        }

        private void ResetStudentInfo()
        {
            tbxNumber.Text = "20";
            tbxBirthYear.Text = "20";

            tbxName.Text = "";
            tbxBirthMonth.Text = "";
            tbxBirthDay.Text = "";
            tbxAddress.Text = "";
            tbxContact.Text = "";

            cmbDepartment.SelectedIndex = -1;
            cmbAdvisor.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbRegStatus.SelectedIndex = -1;

            tbxNumber.ReadOnly = false;
            btnRegister.Text = "등록";
            selectedStudent = null;
            lbxDictionary.SelectedIndex = -1;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                registerStudent();
            } else
            {
                //call
                UpdateStudent();
            }
        }

        private void registerStudent()
        {
            if (tbxNumber.Text.Trim() == "" || tbxNumber.Text.Trim().Length != 8)
            {
                MessageBox.Show("학번이 잘못입력되었습니다.");
                tbxNumber.Focus();
                return;
            }
            else if (tbxName.Text.Trim() == "" || tbxName.Text.Trim().Length < 2)
            {
                MessageBox.Show("이름이 잘못입력되었습니다.");
                tbxName.Focus();
                return;
            }

            var number = tbxNumber.Text.Trim();

            //딕셔너리를 사용할 때 가장 많이 활용하는 방법
            if (students.ContainsKey(number))
            {
                MessageBox.Show("이미 등록되어 있는 학번입니다.");
                tbxNumber.Focus();
                return;
            }

            Student student = new Student();
            int birthYear, birthMonth;//, birthDay;

            if (int.TryParse(tbxBirthYear.Text, out birthYear)) {
                if (false == (1900 <= birthYear && birthYear <= 9000))
                {
                    MessageBox.Show("비정상적인 년도 값입니다.");
                    tbxBirthYear.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 년도 값입니다.");
                tbxBirthYear.Focus();
                return;
            }
            
            if (int.TryParse(tbxBirthMonth.Text, out birthMonth))
            {
                if (false == (1 <= birthMonth && birthMonth <= 12))
                {
                    MessageBox.Show("비정상적인 월 값입니다.");
                    tbxBirthMonth.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 월 값입니다.");
                tbxBirthMonth.Focus();
                return;
            }

            //2022버전 이상 만 지원
            if (int.TryParse(tbxBirthDay.Text, out int birthDay))
            {
                if (false == (1 <= birthDay && birthDay <= 31))
                {
                    MessageBox.Show("비정상적인 일 값입니다.");
                    tbxBirthDay.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 일 값입니다.");
                tbxBirthDay.Focus();
                return;
            }

            student.Number = number;
            student.Name = tbxName.Text.Trim();
            //현재 시스템 시간: DateTime.Now();
            student.BirthInfo = new DateTime(birthYear, birthMonth, birthDay);

            if (cmbDepartment.SelectedIndex < 0)
            {
                student.DepartmentCode = null;
            }
            else
            {
                //cmb의 selectedItem은 Object Type이기에 Department type으로 원복해야 함
                student.DepartmentCode = (cmbDepartment.SelectedItem as Department).Code;
            }

            if (cmbAdvisor.SelectedIndex < 0)
            {
                student.AdvisorNumber = null;
            }
            else
            {
                student.AdvisorNumber = (cmbAdvisor.SelectedItem as Professor).Number;
            }

            if (cmbYear.SelectedIndex < 0)
            {
                MessageBox.Show("학년을 선택해주세요.");
                cmbYear.Focus();
                return;
            }
            else
            {
                student.year = (int)cmbYear.SelectedItem;
            }

            if (cmbClass.SelectedIndex < 0)
            {
                MessageBox.Show("분반을 선택해주세요.");
                cmbClass.Focus();
                return;
            }
            else
            {
                student.Class = cmbClass.SelectedItem.ToString();
            }

            if (cmbRegStatus.SelectedIndex < 0)
            {
                MessageBox.Show("재적여부을 선택해주세요.");
                cmbRegStatus.Focus();
                return;
            }
            else
            {
                student.RegStatus = cmbRegStatus.SelectedItem.ToString();
            }

            //주소는 trim을 하지 않는것이 좋을 거 같아 하지 않았습니다.
            student.Address = tbxAddress.Text;
            student.Contact = tbxContact.Text.Trim();

            //기본적인 딕셔러니 데이터 삽입 방법, 중복시 덮어쓰기
            students[number] = student;
            //Add방식, 중복시 에러발생
            //students.Add(number, student);

            lbxDictionary.Items.Add(student);
        }

        private void UpdateStudent()
        {
            if (tbxNumber.Text != selectedStudent.Number)
            {
                MessageBox.Show("학번을 수정할 수 없습니다.");
                tbxNumber.Focus();
                return;
            }
            else if (tbxName.Text.Trim() == "" || tbxName.Text.Trim().Length < 2)
            {
                MessageBox.Show("이름이 잘못입력되었습니다.");
                tbxName.Focus();
                return;
            }

            var number = tbxNumber.Text.Trim();

            Student student = new Student();

            if (int.TryParse(tbxBirthYear.Text, out int birthYear))
            {
                if (false == (1900 <= birthYear && birthYear <= 9000))
                {
                    MessageBox.Show("비정상적인 년도 값입니다.");
                    tbxBirthYear.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 년도 값입니다.");
                tbxBirthYear.Focus();
                return;
            }

            if (int.TryParse(tbxBirthMonth.Text, out int birthMonth))
            {
                if (false == (1 <= birthMonth && birthMonth <= 12))
                {
                    MessageBox.Show("비정상적인 월 값입니다.");
                    tbxBirthMonth.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 월 값입니다.");
                tbxBirthMonth.Focus();
                return;
            }

            if (int.TryParse(tbxBirthDay.Text, out int birthDay))
            {
                if (false == (1 <= birthDay && birthDay <= 31))
                {
                    MessageBox.Show("비정상적인 일 값입니다.");
                    tbxBirthDay.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("비정상적인 일 값입니다.");
                tbxBirthDay.Focus();
                return;
            }

            student.Number = number;
            student.Name = tbxName.Text.Trim();
            student.BirthInfo = new DateTime(birthYear, birthMonth, birthDay);

            if (cmbDepartment.SelectedIndex < 0)
            {
                student.DepartmentCode = null;
            }
            else
            {
                //cmb의 selectedItem은 Object Type이기에 Department type으로 원복해야 함
                student.DepartmentCode = (cmbDepartment.SelectedItem as Department).Code;
            }

            if (cmbAdvisor.SelectedIndex < 0)
            {
                student.AdvisorNumber = null;
            }
            else
            {
                student.AdvisorNumber = (cmbAdvisor.SelectedItem as Professor).Number;
            }

            if (cmbYear.SelectedIndex < 0)
            {
                MessageBox.Show("학년을 선택해주세요.");
                cmbYear.Focus();
                return;
            }
            else
            {
                student.year = (int)cmbYear.SelectedItem;
            }

            if (cmbClass.SelectedIndex < 0)
            {
                MessageBox.Show("분반을 선택해주세요.");
                cmbClass.Focus();
                return;
            }
            else
            {
                student.Class = cmbClass.SelectedItem.ToString();
            }

            if (cmbRegStatus.SelectedIndex < 0)
            {
                MessageBox.Show("재적여부을 선택해주세요.");
                cmbRegStatus.Focus();
                return;
            }
            else
            {
                student.RegStatus = cmbRegStatus.SelectedItem.ToString();
            }

            student.Address = tbxAddress.Text;
            student.Contact = tbxContact.Text.Trim();

            students[number] = student;

            lbxDictionary.Items.Remove(selectedStudent);
            lbxDictionary.Items.Add(student);

            MessageBox.Show("수정완료");

            ResetStudentInfo();
        }

        private void lbxDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDictionary.SelectedIndex < 0)
            {
                lbxDictionary.Focus();
                return;
            }

            selectedStudent = (Student)lbxDictionary.SelectedItem;

            //강제 호출시
            //btnNew_Click(sender, EventArgs.Empty);

            if (selectedStudent != null)
            {
                DisplaySelectedStudent(selectedStudent);
            }
        }

        private void DisplaySelectedStudent(Student student)
        {
            tbxNumber.ReadOnly = true;
            tbxNumber.Text = student.Number;
            tbxBirthYear.Text = student.BirthInfo.Year.ToString();

            tbxName.Text = selectedStudent.Name;
            tbxBirthMonth.Text = selectedStudent.BirthInfo.Month.ToString();
            tbxBirthDay.Text = selectedStudent.BirthInfo.Day.ToString();
            tbxAddress.Text = selectedStudent.Address;
            tbxContact.Text = selectedStudent.Contact;


            for (int i = 0; i < cmbDepartment.Items.Count; ++i)
            {
                if ((cmbDepartment.Items[i] as Department).Code == student.DepartmentCode)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbAdvisor.Items.Count; ++i)
            {
                if ((cmbAdvisor.Items[i] as Professor).Number == student.AdvisorNumber)
                {
                    cmbAdvisor.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbYear.Items.Count; ++i)
            {
                if ((int)cmbYear.Items[i] == student.year)
                {
                    cmbYear.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbClass.Items.Count; ++i)
            {
                if (cmbClass.Items[i].ToString() == student.Class)
                {
                    cmbClass.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbRegStatus.Items.Count; ++i)
            {
                if (cmbRegStatus.Items[i].ToString() == student.RegStatus)
                {
                    cmbRegStatus.SelectedIndex = i;
                    break;
                }
            }

            btnRegister.Text = "수정";
        }

        private void btnTestSearchStudent_Click(object sender, EventArgs e)
        {
            ClearTestScoreInfo();

            if (tbxTestNumber.Text == "")
            {
                MessageBox.Show("학번을 입력해 주세요.");
                tbxTestNumber.Focus();
                return;
            }

            selectedStudent = searchStudentByNumber(tbxTestNumber.Text.Trim());
        
            if (selectedStudent == null)
            {
                MessageBox.Show("잘못된 학번입니다.");
                tbxTestNumber.Focus();
                return;
            }

            lblTestName.Text = selectedStudent.Name;
        }

        private Student searchStudentByNumber(string number)
        {
            if (students.ContainsKey(number))
            {
                return students[number];
            }
            else
            {
                return null;
            }
        }

        private void ClearTestScoreInfo()
        {
            lblTestName.Text = "";

            tbxTestScore1.Text = "";
            tbxTestScore2.Text = "";
            tbxTestScore3.Text = "";
            tbxTestScore4.Text = "";
            tbxTestScore5.Text = "";
            tbxTestScore6.Text = "";
            tbxTestScore7.Text = "";
            tbxTestScore8.Text = "";
            tbxTestScore9.Text = "";

            lblTestTotalCount.Text = "";
            lblTestAverage.Text = "";
        }

    }
}
