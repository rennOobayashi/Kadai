using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Week09Homework
{
    public partial class FormManager : Form
    {
        public string PATH
        {
            get
            {
                var path = "c:\\class_c";
                if (false == Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }
        public string GradePATH
        {
            get
            {
                var path = "c:\\class_c\\scores";
                if (false == Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        //static도 문제 없음
        public string DepartmentFullFileName
        {
            get
            {
                return Path.Combine(PATH, "department.txt");
            }
        }

        public string ProfessorFullFileName
        {
            get
            {
                return Path.Combine(PATH, "professor.txt");
            }
        }

        public string StudentFullFileName
        {
            get
            {
                return Path.Combine(PATH, "student.txt");
            }
        }

        TextBox[] tbxTestScores;

        public FormManager()
        {
            InitializeComponent();

            for (int i = 0; i < (int)YEAR.END; i++)
            {
                cmbYear.Items.Add(Student.YearName[(YEAR)i]);
            }

            cmbClass.Items
                .AddRange(new object[] { CLASS.A, CLASS.B, CLASS.C });

            for (int i = 0; i < (int)REG_STATUS.END; i++)
            {
                cmbRegStatus.Items.Add(Student.RegStatusName[(REG_STATUS)i]);
            }

            tbxTestScores = new TextBox[] {
                tbxTestScore1,
                tbxTestScore2,
                tbxTestScore3,
                tbxTestScore4,
                tbxTestScore5,
                tbxTestScore6,
                tbxTestScore7,
                tbxTestScore8,
                tbxTestScore9,
            };

            OpenInfo(ref Department.departments, DepartmentFullFileName);
            OpenInfo(ref Professor.professors, ProfessorFullFileName);
            OpenInfo(ref Student.students, StudentFullFileName);

            try
            {
                foreach (Student stu in Student.students)
                {
                    try
                    {
                        OpenInfo(ref Grade.grades, Path.Combine(GradePATH, $"{stu.Number}.txt"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenInfo(ref List<IFile> files, string fileName)
        {
            if (files == null)
            {
                files = new List<IFile>();
            }
            else
            {
                files.Clear();
            }

            if (true == File.Exists(fileName))
            {
                //참고
                try
                {
                    using (var fs = new FileStream(fileName, FileMode.Open))
                    {
                        using (var sr = new StreamReader(fs))
                        {
                            while (false == sr.EndOfStream)
                            {

                                var data = sr.ReadLine();
                                if (data.Trim().Split('|').Length == 2)
                                {
                                    var dept = Department.Restore(data);

                                    if (dept != null)
                                    {
                                        files.Add(dept);
                                        lbxDepartment.Items.Add(dept);
                                    }
                                }
                                else if (data.Trim().Split('|').Length == 3)
                                {
                                    var prof = Professor.Restore(data, Department.departments);

                                    if (prof != null)
                                    {
                                        files.Add(prof);
                                    }
                                }
                                else if (data.Trim().Split('|').Length == 11)
                                {
                                    var stu = Grade.Restore(data, Student.students);

                                    if (stu != null)
                                    {
                                        files.Add(stu);
                                    }
                                }
                                else if (data.Trim().Split('|').Length == 10)
                                {
                                    var stu = Student.Restore(data, Department.departments, Professor.professors);

                                    if (stu != null)
                                    {
                                        files.Add(stu);
                                        lbxDictionary.Items.Add(stu);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("파일 형식 오류: " + fileName);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnRegisterDepartment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxDepartmentCode.Text))
            {
                MessageBox.Show("학과코드 입력");
                tbxDepartmentCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxDepartmentName.Text))
            {
                MessageBox.Show("학과이름 입력");
                tbxDepartmentName.Focus();
                return;
            }
            for (int i = 0; i < Department.departments.Count; i++)
            {
                if (((Department)Department.departments[i]).GetCode() == tbxDepartmentCode.Text)
                {
                    MessageBox.Show("중복 학과코드");
                    tbxDepartmentCode.Focus();
                    return;
                }
            }

            if (Department.departments.Count >= 100)
            {
                MessageBox.Show("신규 학과를 개설할 수 없습니다.");
                return;
            }



            try
            {
                Department dept = new Department(tbxDepartmentCode.Text, tbxDepartmentName.Text);

                Department.departments.Add(dept);

                lbxDepartment.Items.Add(dept);

                SaveInfo(dept, DepartmentFullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveDepartment_Click(object sender, EventArgs e)
        {
            if (lbxDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("삭제할 학과를 선택");
                return;
            }
            if (Department.departments.Count == 0)
            {
                MessageBox.Show("학과가 비었습니다.");
                return;
            }

            if (lbxDepartment.SelectedItem is Department)
            {
                var target = (Department)lbxDepartment.SelectedItem;

                foreach (Professor prof in Professor.professors)
                {
                    if (prof.Dept.Code == target.Code)
                    {
                        MessageBox.Show("사용중인 학과입니다.");
                        return;
                    }
                }
                foreach (Student stu in (Student.students))
                {
                    if (stu.Dept.Code == target.Code)
                    {
                        MessageBox.Show("사용중인 학과입니다.");
                        return;
                    }
                }

                //var stuList = Student.students.Select(m => m.Value.Dept.Code).Where(m => m == target.Code).ToList();

                for (int i = 0; i < Department.departments.Count; i++)
                {
                    if (Department.departments[i] != null && Department.departments[i] == target)
                    {
                        Department.departments[i] = null;
                        break;
                    }
                }

                lbxDepartment.Items.RemoveAt(lbxDepartment.SelectedIndex);
                lbxDepartment.SelectedIndex = -1;

                DeleteInfo(Department.departments, DepartmentFullFileName);
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
                    foreach (var department in Department.departments)
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
                    foreach (var department in Department.departments)
                    {
                        if (department != null)
                        {
                            cmbDepartment.Items.Add(department);
                        }
                    }

                    ClearStudentInfo();
                    break;
                case 3:
                    ClearTestScoreInfo();
                    break;
                default:
                    break;
            }
        }

        private void ClearTestScoreInfo()
        {
            lblTestName.Text = string.Empty;

            foreach (var textbox in tbxTestScores)
            {
                textbox.Text = string.Empty;
            }
        }

        private void cmbProfessorDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfessorDepartment.SelectedIndex < 0)
            {
                return;
            }

            lbxProfessor.Items.Clear();

            var department = cmbProfessorDepartment.SelectedItem as Department;

            if (department != null)
            {
                foreach (Professor professor in Professor.professors)
                {
                    if (professor != null && professor.Dept.Code == department.Code)
                    {
                        lbxProfessor.Items.Add(professor);
                    }
                }
            }
        }

        private void btnRegisterProfessor_Click(object sender, EventArgs e)
        {
            if (cmbProfessorDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("학과를 선택");
                cmbProfessorDepartment.Focus();
                return;
            }

            if (false == cmbProfessorDepartment.SelectedItem is Department dept)
            {
                MessageBox.Show("학과정보에 이상 발생");
                cmbProfessorDepartment.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxProfessorNumber.Text))
            {
                MessageBox.Show("교수번호 입력");
                tbxProfessorNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxProfessorName.Text))
            {
                MessageBox.Show("교수이름 입력");
                tbxProfessorName.Focus();
                return;
            }

            for (int i = 0; i < Professor.professors.Count; i++)
            {
                if (((Professor)Professor.professors[i]).Number == tbxProfessorNumber.Text)
                {
                    MessageBox.Show("중복 교수코드");
                    tbxProfessorNumber.Focus();
                    return;
                }
            }

            Professor professor = new Professor(tbxProfessorNumber.Text, tbxProfessorName.Text, dept);

            Professor.professors.Add(professor);
            lbxProfessor.Items.Add(professor);

            SaveInfo(professor, ProfessorFullFileName);
        }

        private void SaveInfo(IFile file, string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Append))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(file.Record);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveProfessor_Click(object sender, EventArgs e)
        {
            if (lbxProfessor.SelectedIndex < 0)
            {
                MessageBox.Show("삭제할 교수를 선택");
                return;
            }

            if (lbxProfessor.SelectedItem is Professor)
            {
                var target = (Professor)lbxProfessor.SelectedItem;

                foreach (Student stu in Student.students)
                {
                    if (stu.Advisor == target)
                    {
                        MessageBox.Show("누군가의 지도 교수입니다.");
                        return;
                    }
                }

                for (int i = 0; i < Professor.professors.Count; i++)
                {
                    if (Professor.professors[i] != null && Professor.professors[i] == target)
                    {
                        Professor.professors.RemoveAt(i);
                        break;
                    }
                }

                lbxProfessor.Items.Remove(target);
                lbxProfessor.SelectedIndex = -1;

                DeleteInfo(Professor.professors, ProfessorFullFileName);
            }
        }

        private void DeleteInfo(List<IFile> files, string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var file in files)
                    {
                        sw.WriteLine(file.Record);
                    }
                }
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAdvisor.Items.Clear();

            if (cmbDepartment.SelectedIndex < 0)
            {
                return;
            }

            if (false == cmbDepartment.SelectedItem is Department dept)
            {
                return;
            }

            foreach (Professor professor in Professor.professors)
            {
                if (professor != null && professor.Dept.Code == dept.Code)
                {
                    cmbAdvisor.Items.Add(professor);
                }
            }

            cmbAdvisor.SelectedIndex = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearStudentInfo();
            lbxDictionary.SelectedIndex = -1;
        }

        private void ClearStudentInfo()
        {
            tbxNumber.Text = "20";
            tbxName.Text = string.Empty;
            tbxBirthYear.Text = "20";
            tbxBirthMonth.Text = "";
            tbxBirthDay.Text = "";
            cmbDepartment.SelectedIndex = -1;
            cmbAdvisor.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbRegStatus.SelectedIndex = -1;
            tbxAddress.Text = string.Empty;
            tbxContact.Text = string.Empty;

            tbxNumber.ReadOnly = false;
            selectedStudent = null;
            btnRegister.Text = "등록";
        }

        Student selectedStudent = null;
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                RegisterStudent();
            }
            else
            {
                UpdateStudent();          //call
            }
        }

        private void RegisterStudent()
        {
            var number = tbxNumber.Text.Trim();

            if (string.IsNullOrEmpty(number) || number.Length != 8)
            {
                tbxNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxName.Text) || tbxName.Text.Trim().Length < 2)
            {
                tbxName.Focus();
                return;
            }

            //for, 성능 떨어짐
            for (int i = 0; i < Student.students.Count; i++)
            {
                var pair = (Student.students.ElementAt(i) as Student);
                if (pair.Number == number)
                {
                    tbxNumber.Focus();
                    return;
                }
            }

            //foreach
            foreach (Student pair in Student.students)
            {
                if (pair.Number == number)
                {
                    tbxNumber.Focus();
                    return;
                }
            }

            Student student = new Student(number, tbxName.Text.Trim());

            int birthYear, birthMonth;// birthDay;
            if (true == int.TryParse(tbxBirthYear.Text, out birthYear))
            {
                if (birthYear < 1900 || 9000 < birthYear)
                {
                    tbxBirthYear.Focus();
                    return;
                }
            }
            else
            {
                tbxBirthYear.Focus();
                return;
            }

            if (true == int.TryParse(tbxBirthMonth.Text, out birthMonth))
            {
                if (birthMonth < 1 || 12 < birthMonth)
                {
                    tbxBirthMonth.Focus();
                    return;
                }
            }
            else
            {
                tbxBirthMonth.Focus();
                return;
            }

            if (true == int.TryParse(tbxBirthDay.Text, out int birthDay))
            {
                //2월, 달 처리등은 추후 해볼것
                if (birthDay < 0 || 31 < birthDay)
                {
                    tbxBirthDay.Focus();
                    return;
                }
            }
            else
            {
                tbxBirthDay.Focus();
                return;
            }

            student.SetBirthInfo(birthYear, birthMonth, birthDay);

            if (cmbDepartment.SelectedIndex < 0)
            {
                student.Dept = null;
            }
            else
            {
                student.Dept = (cmbDepartment.SelectedItem as Department);
            }

            if (cmbAdvisor.SelectedIndex < 0)
            {
                student.Advisor = null;
            }
            else
            {
                student.Advisor = (cmbAdvisor.SelectedItem as Professor);
            }

            if (cmbYear.SelectedIndex < (int)YEAR.END)
            {
                student.Year = (YEAR)cmbYear.SelectedIndex;
            }

            if (cmbClass.SelectedIndex < 0)
            {
                cmbClass.Focus();
                return;
            }
            student.Class = (CLASS)cmbClass.SelectedIndex;

            if (cmbRegStatus.SelectedIndex < 0)
            {
                cmbRegStatus.Focus();
                return;
            }
            student.RegStatus = (REG_STATUS)cmbRegStatus.SelectedIndex;

            student.Address = tbxAddress.Text.Trim();
            student.Contact = tbxContact.Text.Trim();

            Student.students.Add(student);
            lbxDictionary.Items.Add(student);

            SaveInfo(student, StudentFullFileName);
        }

        private void UpdateStudent()
        {
            if (string.IsNullOrEmpty(tbxName.Text) || tbxName.Text.Trim().Length < 2)
            {
                MessageBox.Show("이름 불가");
                tbxName.Focus();
                return;
            }

            if (true == int.TryParse(tbxBirthYear.Text, out int birthYear))
            {
                if (birthYear < 1900 || 9000 < birthYear)
                {
                    MessageBox.Show("생일 불가");
                    tbxBirthYear.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("생일 불가");
                tbxBirthYear.Focus();
                return;
            }


            if (true == int.TryParse(tbxBirthMonth.Text, out int birthMonth))
            {
                if (birthMonth < 1 || 12 < birthMonth)
                {
                    MessageBox.Show("생일 불가");
                    tbxBirthMonth.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("생일 불가");
                tbxBirthMonth.Focus();
                return;
            }

            if (true == int.TryParse(tbxBirthDay.Text, out int birthDay))
            {
                //2월, 달 처리등은 추후 해볼것
                if (birthDay < 0 || 31 < birthDay)
                {
                    MessageBox.Show("생일 불가");
                    tbxBirthDay.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("생일 불가");
                tbxBirthDay.Focus();
                return;
            }

            if (cmbDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("학과 불가");
                //cmbDepartment.Focus();
                return;
            }

            if (cmbYear.SelectedIndex < 0)
            {
                MessageBox.Show("학년 불가");
                cmbYear.Focus();
                return;
            }

            if (cmbClass.SelectedIndex < 0)
            {
                MessageBox.Show("반 불가");
                cmbClass.Focus();
                return;
            }

            if (cmbRegStatus.SelectedIndex < 0)
            {
                MessageBox.Show("상태 불가");
                cmbRegStatus.Focus();
                return;
            }

            selectedStudent.SetBirthInfo(birthYear, birthMonth, birthDay);

            if (cmbDepartment.SelectedIndex < 0)
            {
                selectedStudent.Dept = null;
            }
            else
            {
                selectedStudent.Dept = (cmbDepartment.SelectedItem as Department);
            }

            if (cmbAdvisor.SelectedIndex < 0)
            {
                selectedStudent.Advisor = null;
            }
            else
            {
                selectedStudent.Advisor = (cmbAdvisor.SelectedItem as Professor);
            }

            selectedStudent.SetName(tbxName.Text.Trim());
            selectedStudent.Year = (YEAR)cmbYear.SelectedIndex;
            selectedStudent.Class = (CLASS)cmbClass.SelectedIndex;
            selectedStudent.RegStatus = (REG_STATUS)cmbRegStatus.SelectedIndex;
            selectedStudent.Address = tbxAddress.Text.Trim();
            selectedStudent.Contact = tbxContact.Text.Trim();

            DeleteInfo(Student.students, StudentFullFileName);
            int ind = lbxDictionary.SelectedIndex;
            lbxDictionary.Items.Add(selectedStudent);

            lbxDictionary.Items.RemoveAt(ind);

            MessageBox.Show("수정완료");
            ClearStudentInfo();
        }


        private void lbxDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDictionary.SelectedIndex < 0)
            {
                return;
            }

            var student = (lbxDictionary.SelectedItem as Student);

            ClearStudentInfo();

            if (student != null)
            {
                DisplaySelectedStudent(student);
            }
        }

        private void DisplaySelectedStudent(Student student)
        {
            selectedStudent = student;
            tbxNumber.ReadOnly = true;

            tbxNumber.Text = student.Number;
            tbxName.Text = student.Name;
            tbxBirthYear.Text = student.BirthInfo.Year.ToString();
            tbxBirthMonth.Text = student.BirthInfo.Month.ToString();
            tbxBirthDay.Text = student.BirthInfo.Day.ToString();

            for (int i = 0; i < cmbDepartment.Items.Count; i++)
            {
                if ((cmbDepartment.Items[i] as Department).Code == student.Dept.Code)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbAdvisor.Items.Count; i++)
            {
                if ((cmbAdvisor.Items[i] as Professor) == student.Advisor)
                {
                    cmbAdvisor.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < (int)YEAR.END; i++)
            {
                if (i == (int)student.Year)
                {
                    cmbYear.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbClass.Items.Count; i++)
            {
                if (i == (int)student.Class)
                {
                    cmbClass.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cmbRegStatus.Items.Count; i++)
            {
                if (i == (int)student.RegStatus)
                {
                    cmbRegStatus.SelectedIndex = i;
                    break;
                }
            }

            tbxAddress.Text = selectedStudent.Address;
            tbxContact.Text = selectedStudent.Contact;

            btnRegister.Text = "수정";
        }

        private void btnTestSearchStudent_Click(object sender, EventArgs e)
        {
            ClearTestScoreInfo();

            var number = tbxTestNumber.Text.Trim();
            if (string.IsNullOrEmpty(number) || number.Length != 8)
            {
                tbxNumber.Focus();
                return;
            }

            selectedStudent = SearchStudentByNumber(tbxTestNumber.Text);

            if (selectedStudent == null)
            {
                MessageBox.Show($"{number}학번의 학생 정보가 없음");
                tbxTestNumber.Focus();
                return;
            }

            lblTestName.Text = selectedStudent.Name;

            Grade grade = SearchGradeByNumber(selectedStudent.Number);

            if (grade != null)
            {
                for (int i = 0; i < grade.Count() && i < tbxTestScores.Length; i++)
                {
                    tbxTestScores[i].Text = grade.Get(i).ToString("0.0");
                }
            }
        }

        Grade SearchGradeByNumber(string number)
        {
            foreach (Grade grade in Grade.grades)
            {
                if (grade.Student.Number == number)
                {
                    return grade;
                }
            }

            return null;
        }

        private Student SearchStudentByNumber(string number)
        {
            foreach (Student pair in Student.students)
            {
                if (pair.Number == number)
                {
                    tbxNumber.Focus();
                    return pair;
                }

            }

            return null;
        }

        private void btnTestRegScore_Click(object sender, EventArgs e)
        {
            //추가코드
            lblTestTotalCount.Text = "";
            lblTestAverage.Text = "";

            if (selectedStudent == null)
            {
                tbxTestNumber.Focus();
                return;
            }

            for (int i = 1; i < tbxTestScores.Length; i++)
            {
                if (true == string.IsNullOrEmpty(tbxTestScores[i - 1].Text) && false == string.IsNullOrEmpty(tbxTestScores[i].Text))
                {
                    tbxTestScores[i - 1].Focus();
                    return;
                }
            }

            var grade = SearchGradeByNumber(selectedStudent.Number);

            if (grade == null)
            {
                grade = new Grade(selectedStudent);
            }

            grade.Clear();

            double temp;
            for (int i = 0; i < tbxTestScores.Length; i++)
            {
                if (string.IsNullOrEmpty(tbxTestScores[i].Text))
                {
                    break;
                }

                if (false == double.TryParse(
                    tbxTestScores[i].Text, out temp))
                {
                    tbxTestScores[i].Focus();
                    return;
                }
                grade.Add(temp);
            }

            Grade.grades.Add(grade);

            lblTestTotalCount.Text = grade.Count().ToString();

            double average = grade.Average();
            lblTestAverage.Text = average.ToString("F1");

            UpdateInfo(grade, Path.Combine(GradePATH, $"{grade.Student.Number}.txt"));
        }

        private void UpdateInfo(IFile file, string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(file.Record);
                }
            }
        }
    }
}
