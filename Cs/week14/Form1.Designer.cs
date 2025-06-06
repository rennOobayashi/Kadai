namespace Proj_FinacialLedger_202444086
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIncome = new System.Windows.Forms.Button();
            this.lblIncome = new System.Windows.Forms.Label();
            this.tbxIncomeContent = new System.Windows.Forms.TextBox();
            this.lblExpenditure = new System.Windows.Forms.Label();
            this.btnExoenditure = new System.Windows.Forms.Button();
            this.tbxExpenditureMoney = new System.Windows.Forms.TextBox();
            this.tbxExpenditureContent = new System.Windows.Forms.TextBox();
            this.tbxIncomeMoney = new System.Windows.Forms.TextBox();
            this.tctrlFinacialedger = new System.Windows.Forms.TabControl();
            this.tpgIncome = new System.Windows.Forms.TabPage();
            this.lbxIncomes = new System.Windows.Forms.ListBox();
            this.tpgExpenditure = new System.Windows.Forms.TabPage();
            this.lbxExpenditures = new System.Windows.Forms.ListBox();
            this.tpgAll = new System.Windows.Forms.TabPage();
            this.lbxAll = new System.Windows.Forms.ListBox();
            this.lblTargetAmount = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.tbxTargetAmount = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tbxYear = new System.Windows.Forms.TextBox();
            this.lblPrintTotalIncome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblPrintBlack = new System.Windows.Forms.Label();
            this.lblPrintTotalExpenditure = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpenditure = new System.Windows.Forms.Label();
            this.tbxExpenditureDay = new System.Windows.Forms.TextBox();
            this.tbxIncomeDay = new System.Windows.Forms.TextBox();
            this.tbxExpenditureMonth = new System.Windows.Forms.TextBox();
            this.tbxIncomeMonth = new System.Windows.Forms.TextBox();
            this.tbxExpenditureYear = new System.Windows.Forms.TextBox();
            this.tbxIncomeYear = new System.Windows.Forms.TextBox();
            this.lblWon = new System.Windows.Forms.Label();
            this.lblWon2 = new System.Windows.Forms.Label();
            this.lblExpenditureMoney = new System.Windows.Forms.Label();
            this.lblExpenditureContent = new System.Windows.Forms.Label();
            this.lblIncomeMoney = new System.Windows.Forms.Label();
            this.lblIncomeContent = new System.Windows.Forms.Label();
            this.tbxQuickContent = new System.Windows.Forms.TextBox();
            this.btnQuickIncome = new System.Windows.Forms.Button();
            this.tbxQuickMoney = new System.Windows.Forms.TextBox();
            this.lblQuickInput = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNowMoneyInput = new System.Windows.Forms.Label();
            this.lblNowContent = new System.Windows.Forms.Label();
            this.lblNowMoney = new System.Windows.Forms.Label();
            this.lblPrintNowMoney = new System.Windows.Forms.Label();
            this.btnQuickExpenditure = new System.Windows.Forms.Button();
            this.tctrlFinacialedger.SuspendLayout();
            this.tpgIncome.SuspendLayout();
            this.tpgExpenditure.SuspendLayout();
            this.tpgAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIncome
            // 
            this.btnIncome.Font = new System.Drawing.Font("굴림", 12F);
            this.btnIncome.Location = new System.Drawing.Point(268, 134);
            this.btnIncome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(66, 102);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "등록";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnwIncome_Click);
            // 
            // lblIncome
            // 
            this.lblIncome.Font = new System.Drawing.Font("굴림", 12F);
            this.lblIncome.Location = new System.Drawing.Point(12, 92);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(239, 24);
            this.lblIncome.TabIndex = 0;
            this.lblIncome.Text = "수익";
            this.lblIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxIncomeContent
            // 
            this.tbxIncomeContent.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxIncomeContent.Location = new System.Drawing.Point(70, 171);
            this.tbxIncomeContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIncomeContent.Name = "tbxIncomeContent";
            this.tbxIncomeContent.Size = new System.Drawing.Size(192, 27);
            this.tbxIncomeContent.TabIndex = 2;
            this.tbxIncomeContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblExpenditure
            // 
            this.lblExpenditure.Font = new System.Drawing.Font("굴림", 12F);
            this.lblExpenditure.Location = new System.Drawing.Point(353, 92);
            this.lblExpenditure.Name = "lblExpenditure";
            this.lblExpenditure.Size = new System.Drawing.Size(239, 24);
            this.lblExpenditure.TabIndex = 0;
            this.lblExpenditure.Text = "지출";
            this.lblExpenditure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExoenditure
            // 
            this.btnExoenditure.Font = new System.Drawing.Font("굴림", 12F);
            this.btnExoenditure.Location = new System.Drawing.Point(609, 134);
            this.btnExoenditure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExoenditure.Name = "btnExoenditure";
            this.btnExoenditure.Size = new System.Drawing.Size(66, 102);
            this.btnExoenditure.TabIndex = 1;
            this.btnExoenditure.Text = "등록";
            this.btnExoenditure.UseVisualStyleBackColor = true;
            this.btnExoenditure.Click += new System.EventHandler(this.btnExoenditure_Click);
            // 
            // tbxExpenditureMoney
            // 
            this.tbxExpenditureMoney.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxExpenditureMoney.Location = new System.Drawing.Point(410, 209);
            this.tbxExpenditureMoney.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxExpenditureMoney.Name = "tbxExpenditureMoney";
            this.tbxExpenditureMoney.Size = new System.Drawing.Size(156, 27);
            this.tbxExpenditureMoney.TabIndex = 2;
            this.tbxExpenditureMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxExpenditureContent
            // 
            this.tbxExpenditureContent.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxExpenditureContent.Location = new System.Drawing.Point(410, 171);
            this.tbxExpenditureContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxExpenditureContent.Name = "tbxExpenditureContent";
            this.tbxExpenditureContent.Size = new System.Drawing.Size(192, 27);
            this.tbxExpenditureContent.TabIndex = 2;
            this.tbxExpenditureContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxIncomeMoney
            // 
            this.tbxIncomeMoney.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxIncomeMoney.Location = new System.Drawing.Point(70, 209);
            this.tbxIncomeMoney.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIncomeMoney.Name = "tbxIncomeMoney";
            this.tbxIncomeMoney.Size = new System.Drawing.Size(156, 27);
            this.tbxIncomeMoney.TabIndex = 2;
            this.tbxIncomeMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tctrlFinacialedger
            // 
            this.tctrlFinacialedger.Controls.Add(this.tpgIncome);
            this.tctrlFinacialedger.Controls.Add(this.tpgExpenditure);
            this.tctrlFinacialedger.Controls.Add(this.tpgAll);
            this.tctrlFinacialedger.Location = new System.Drawing.Point(12, 254);
            this.tctrlFinacialedger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tctrlFinacialedger.Name = "tctrlFinacialedger";
            this.tctrlFinacialedger.SelectedIndex = 0;
            this.tctrlFinacialedger.Size = new System.Drawing.Size(1178, 291);
            this.tctrlFinacialedger.TabIndex = 4;
            // 
            // tpgIncome
            // 
            this.tpgIncome.Controls.Add(this.lbxIncomes);
            this.tpgIncome.Location = new System.Drawing.Point(4, 25);
            this.tpgIncome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpgIncome.Name = "tpgIncome";
            this.tpgIncome.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpgIncome.Size = new System.Drawing.Size(1170, 262);
            this.tpgIncome.TabIndex = 0;
            this.tpgIncome.Text = "Income";
            this.tpgIncome.UseVisualStyleBackColor = true;
            // 
            // lbxIncomes
            // 
            this.lbxIncomes.FormattingEnabled = true;
            this.lbxIncomes.ItemHeight = 15;
            this.lbxIncomes.Location = new System.Drawing.Point(6, 0);
            this.lbxIncomes.Name = "lbxIncomes";
            this.lbxIncomes.Size = new System.Drawing.Size(1161, 259);
            this.lbxIncomes.TabIndex = 3;
            // 
            // tpgExpenditure
            // 
            this.tpgExpenditure.Controls.Add(this.lbxExpenditures);
            this.tpgExpenditure.Location = new System.Drawing.Point(4, 25);
            this.tpgExpenditure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpgExpenditure.Name = "tpgExpenditure";
            this.tpgExpenditure.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpgExpenditure.Size = new System.Drawing.Size(1170, 262);
            this.tpgExpenditure.TabIndex = 1;
            this.tpgExpenditure.Text = "Expenditure";
            this.tpgExpenditure.UseVisualStyleBackColor = true;
            // 
            // lbxExpenditures
            // 
            this.lbxExpenditures.FormattingEnabled = true;
            this.lbxExpenditures.ItemHeight = 15;
            this.lbxExpenditures.Location = new System.Drawing.Point(3, 3);
            this.lbxExpenditures.Name = "lbxExpenditures";
            this.lbxExpenditures.Size = new System.Drawing.Size(1164, 259);
            this.lbxExpenditures.TabIndex = 3;
            // 
            // tpgAll
            // 
            this.tpgAll.Controls.Add(this.lbxAll);
            this.tpgAll.Location = new System.Drawing.Point(4, 25);
            this.tpgAll.Name = "tpgAll";
            this.tpgAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAll.Size = new System.Drawing.Size(1170, 262);
            this.tpgAll.TabIndex = 2;
            this.tpgAll.Text = "All";
            this.tpgAll.UseVisualStyleBackColor = true;
            // 
            // lbxAll
            // 
            this.lbxAll.FormattingEnabled = true;
            this.lbxAll.ItemHeight = 15;
            this.lbxAll.Location = new System.Drawing.Point(3, 3);
            this.lbxAll.Name = "lbxAll";
            this.lbxAll.Size = new System.Drawing.Size(1164, 259);
            this.lbxAll.TabIndex = 6;
            // 
            // lblTargetAmount
            // 
            this.lblTargetAmount.Font = new System.Drawing.Font("굴림", 11F);
            this.lblTargetAmount.Location = new System.Drawing.Point(7, 47);
            this.lblTargetAmount.Name = "lblTargetAmount";
            this.lblTargetAmount.Size = new System.Drawing.Size(139, 26);
            this.lblTargetAmount.TabIndex = 3;
            this.lblTargetAmount.Text = "목표 수익";
            this.lblTargetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYear
            // 
            this.lblYear.Font = new System.Drawing.Font("굴림", 11F);
            this.lblYear.Location = new System.Drawing.Point(7, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(139, 26);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "년도";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxTargetAmount
            // 
            this.tbxTargetAmount.Font = new System.Drawing.Font("굴림", 11F);
            this.tbxTargetAmount.Location = new System.Drawing.Point(165, 44);
            this.tbxTargetAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxTargetAmount.Name = "tbxTargetAmount";
            this.tbxTargetAmount.Size = new System.Drawing.Size(257, 29);
            this.tbxTargetAmount.TabIndex = 5;
            this.tbxTargetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("굴림", 11F);
            this.btnLoad.Location = new System.Drawing.Point(583, 41);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(133, 30);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("굴림", 11F);
            this.btnSave.Location = new System.Drawing.Point(444, 41);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "저장하기";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("굴림", 11F);
            this.btnReset.Location = new System.Drawing.Point(444, 9);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(272, 30);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "신규(초기화)";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbxYear
            // 
            this.tbxYear.Font = new System.Drawing.Font("굴림", 11F);
            this.tbxYear.Location = new System.Drawing.Point(165, 7);
            this.tbxYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxYear.Name = "tbxYear";
            this.tbxYear.Size = new System.Drawing.Size(257, 29);
            this.tbxYear.TabIndex = 5;
            this.tbxYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrintTotalIncome
            // 
            this.lblPrintTotalIncome.Font = new System.Drawing.Font("굴림", 11F);
            this.lblPrintTotalIncome.Location = new System.Drawing.Point(851, 14);
            this.lblPrintTotalIncome.Name = "lblPrintTotalIncome";
            this.lblPrintTotalIncome.Size = new System.Drawing.Size(111, 26);
            this.lblPrintTotalIncome.TabIndex = 0;
            this.lblPrintTotalIncome.Text = "0";
            this.lblPrintTotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.Location = new System.Drawing.Point(572, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "일";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD
            // 
            this.lblD.Font = new System.Drawing.Font("굴림", 10F);
            this.lblD.Location = new System.Drawing.Point(232, 136);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(30, 30);
            this.lblD.TabIndex = 0;
            this.lblD.Text = "일";
            this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(499, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "월";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblM
            // 
            this.lblM.Font = new System.Drawing.Font("굴림", 10F);
            this.lblM.Location = new System.Drawing.Point(159, 136);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(30, 30);
            this.lblM.TabIndex = 0;
            this.lblM.Text = "월";
            this.lblM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(430, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "년";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Font = new System.Drawing.Font("굴림", 10F);
            this.lblY.Location = new System.Drawing.Point(90, 136);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(30, 30);
            this.lblY.TabIndex = 0;
            this.lblY.Text = "년";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrintBlack
            // 
            this.lblPrintBlack.Font = new System.Drawing.Font("굴림", 11F);
            this.lblPrintBlack.Location = new System.Drawing.Point(1074, 53);
            this.lblPrintBlack.Name = "lblPrintBlack";
            this.lblPrintBlack.Size = new System.Drawing.Size(111, 26);
            this.lblPrintBlack.TabIndex = 0;
            this.lblPrintBlack.Text = "-";
            this.lblPrintBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrintTotalExpenditure
            // 
            this.lblPrintTotalExpenditure.Font = new System.Drawing.Font("굴림", 11F);
            this.lblPrintTotalExpenditure.Location = new System.Drawing.Point(851, 53);
            this.lblPrintTotalExpenditure.Name = "lblPrintTotalExpenditure";
            this.lblPrintTotalExpenditure.Size = new System.Drawing.Size(111, 26);
            this.lblPrintTotalExpenditure.TabIndex = 0;
            this.lblPrintTotalExpenditure.Text = "0";
            this.lblPrintTotalExpenditure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlack
            // 
            this.lblBlack.Font = new System.Drawing.Font("굴림", 11F);
            this.lblBlack.Location = new System.Drawing.Point(968, 47);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(100, 32);
            this.lblBlack.TabIndex = 0;
            this.lblBlack.Text = "흑자 여부";
            this.lblBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.Font = new System.Drawing.Font("굴림", 11F);
            this.lblTotalIncome.Location = new System.Drawing.Point(745, 8);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(100, 32);
            this.lblTotalIncome.TabIndex = 0;
            this.lblTotalIncome.Text = "총 수익";
            this.lblTotalIncome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalExpenditure
            // 
            this.lblTotalExpenditure.Font = new System.Drawing.Font("굴림", 11F);
            this.lblTotalExpenditure.Location = new System.Drawing.Point(745, 47);
            this.lblTotalExpenditure.Name = "lblTotalExpenditure";
            this.lblTotalExpenditure.Size = new System.Drawing.Size(100, 32);
            this.lblTotalExpenditure.TabIndex = 0;
            this.lblTotalExpenditure.Text = "총 소비";
            this.lblTotalExpenditure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxExpenditureDay
            // 
            this.tbxExpenditureDay.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxExpenditureDay.Location = new System.Drawing.Point(527, 136);
            this.tbxExpenditureDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxExpenditureDay.Name = "tbxExpenditureDay";
            this.tbxExpenditureDay.Size = new System.Drawing.Size(39, 27);
            this.tbxExpenditureDay.TabIndex = 2;
            this.tbxExpenditureDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxIncomeDay
            // 
            this.tbxIncomeDay.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxIncomeDay.Location = new System.Drawing.Point(187, 136);
            this.tbxIncomeDay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIncomeDay.Name = "tbxIncomeDay";
            this.tbxIncomeDay.Size = new System.Drawing.Size(39, 27);
            this.tbxIncomeDay.TabIndex = 2;
            this.tbxIncomeDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxExpenditureMonth
            // 
            this.tbxExpenditureMonth.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxExpenditureMonth.Location = new System.Drawing.Point(454, 136);
            this.tbxExpenditureMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxExpenditureMonth.Name = "tbxExpenditureMonth";
            this.tbxExpenditureMonth.Size = new System.Drawing.Size(39, 27);
            this.tbxExpenditureMonth.TabIndex = 2;
            this.tbxExpenditureMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxIncomeMonth
            // 
            this.tbxIncomeMonth.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxIncomeMonth.Location = new System.Drawing.Point(114, 136);
            this.tbxIncomeMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIncomeMonth.Name = "tbxIncomeMonth";
            this.tbxIncomeMonth.Size = new System.Drawing.Size(39, 27);
            this.tbxIncomeMonth.TabIndex = 2;
            this.tbxIncomeMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxExpenditureYear
            // 
            this.tbxExpenditureYear.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxExpenditureYear.Location = new System.Drawing.Point(352, 136);
            this.tbxExpenditureYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxExpenditureYear.Name = "tbxExpenditureYear";
            this.tbxExpenditureYear.Size = new System.Drawing.Size(72, 27);
            this.tbxExpenditureYear.TabIndex = 2;
            this.tbxExpenditureYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxIncomeYear
            // 
            this.tbxIncomeYear.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxIncomeYear.Location = new System.Drawing.Point(12, 136);
            this.tbxIncomeYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxIncomeYear.Name = "tbxIncomeYear";
            this.tbxIncomeYear.Size = new System.Drawing.Size(72, 27);
            this.tbxIncomeYear.TabIndex = 2;
            this.tbxIncomeYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWon
            // 
            this.lblWon.Font = new System.Drawing.Font("굴림", 10F);
            this.lblWon.Location = new System.Drawing.Point(232, 205);
            this.lblWon.Name = "lblWon";
            this.lblWon.Size = new System.Drawing.Size(30, 30);
            this.lblWon.TabIndex = 0;
            this.lblWon.Text = "원";
            this.lblWon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWon2
            // 
            this.lblWon2.Font = new System.Drawing.Font("굴림", 10F);
            this.lblWon2.Location = new System.Drawing.Point(572, 206);
            this.lblWon2.Name = "lblWon2";
            this.lblWon2.Size = new System.Drawing.Size(30, 30);
            this.lblWon2.TabIndex = 0;
            this.lblWon2.Text = "원";
            this.lblWon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpenditureMoney
            // 
            this.lblExpenditureMoney.Font = new System.Drawing.Font("굴림", 10F);
            this.lblExpenditureMoney.Location = new System.Drawing.Point(354, 209);
            this.lblExpenditureMoney.Name = "lblExpenditureMoney";
            this.lblExpenditureMoney.Size = new System.Drawing.Size(50, 30);
            this.lblExpenditureMoney.TabIndex = 0;
            this.lblExpenditureMoney.Text = "금액";
            this.lblExpenditureMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpenditureContent
            // 
            this.lblExpenditureContent.Font = new System.Drawing.Font("굴림", 10F);
            this.lblExpenditureContent.Location = new System.Drawing.Point(354, 171);
            this.lblExpenditureContent.Name = "lblExpenditureContent";
            this.lblExpenditureContent.Size = new System.Drawing.Size(50, 30);
            this.lblExpenditureContent.TabIndex = 0;
            this.lblExpenditureContent.Text = "내역";
            this.lblExpenditureContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIncomeMoney
            // 
            this.lblIncomeMoney.Font = new System.Drawing.Font("굴림", 10F);
            this.lblIncomeMoney.Location = new System.Drawing.Point(14, 205);
            this.lblIncomeMoney.Name = "lblIncomeMoney";
            this.lblIncomeMoney.Size = new System.Drawing.Size(50, 30);
            this.lblIncomeMoney.TabIndex = 0;
            this.lblIncomeMoney.Text = "금액";
            this.lblIncomeMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIncomeContent
            // 
            this.lblIncomeContent.Font = new System.Drawing.Font("굴림", 10F);
            this.lblIncomeContent.Location = new System.Drawing.Point(14, 167);
            this.lblIncomeContent.Name = "lblIncomeContent";
            this.lblIncomeContent.Size = new System.Drawing.Size(50, 30);
            this.lblIncomeContent.TabIndex = 0;
            this.lblIncomeContent.Text = "내역";
            this.lblIncomeContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxQuickContent
            // 
            this.tbxQuickContent.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxQuickContent.Location = new System.Drawing.Point(749, 133);
            this.tbxQuickContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxQuickContent.Name = "tbxQuickContent";
            this.tbxQuickContent.Size = new System.Drawing.Size(192, 27);
            this.tbxQuickContent.TabIndex = 2;
            this.tbxQuickContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnQuickIncome
            // 
            this.btnQuickIncome.Font = new System.Drawing.Font("굴림", 12F);
            this.btnQuickIncome.Location = new System.Drawing.Point(948, 133);
            this.btnQuickIncome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuickIncome.Name = "btnQuickIncome";
            this.btnQuickIncome.Size = new System.Drawing.Size(66, 33);
            this.btnQuickIncome.TabIndex = 1;
            this.btnQuickIncome.Text = "수입";
            this.btnQuickIncome.UseVisualStyleBackColor = true;
            this.btnQuickIncome.Click += new System.EventHandler(this.btnQuickIncome_Click);
            // 
            // tbxQuickMoney
            // 
            this.tbxQuickMoney.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxQuickMoney.Location = new System.Drawing.Point(749, 171);
            this.tbxQuickMoney.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxQuickMoney.Name = "tbxQuickMoney";
            this.tbxQuickMoney.Size = new System.Drawing.Size(156, 27);
            this.tbxQuickMoney.TabIndex = 2;
            this.tbxQuickMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQuickInput
            // 
            this.lblQuickInput.Font = new System.Drawing.Font("굴림", 12F);
            this.lblQuickInput.Location = new System.Drawing.Point(692, 92);
            this.lblQuickInput.Name = "lblQuickInput";
            this.lblQuickInput.Size = new System.Drawing.Size(239, 24);
            this.lblQuickInput.TabIndex = 0;
            this.lblQuickInput.Text = "빠른 입력 (오늘 날짜)";
            this.lblQuickInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 10F);
            this.label8.Location = new System.Drawing.Point(911, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "원";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNowMoneyInput
            // 
            this.lblNowMoneyInput.Font = new System.Drawing.Font("굴림", 10F);
            this.lblNowMoneyInput.Location = new System.Drawing.Point(693, 171);
            this.lblNowMoneyInput.Name = "lblNowMoneyInput";
            this.lblNowMoneyInput.Size = new System.Drawing.Size(50, 30);
            this.lblNowMoneyInput.TabIndex = 0;
            this.lblNowMoneyInput.Text = "금액";
            this.lblNowMoneyInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNowContent
            // 
            this.lblNowContent.Font = new System.Drawing.Font("굴림", 10F);
            this.lblNowContent.Location = new System.Drawing.Point(693, 133);
            this.lblNowContent.Name = "lblNowContent";
            this.lblNowContent.Size = new System.Drawing.Size(50, 30);
            this.lblNowContent.TabIndex = 0;
            this.lblNowContent.Text = "내역";
            this.lblNowContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNowMoney
            // 
            this.lblNowMoney.Font = new System.Drawing.Font("굴림", 11F);
            this.lblNowMoney.Location = new System.Drawing.Point(968, 11);
            this.lblNowMoney.Name = "lblNowMoney";
            this.lblNowMoney.Size = new System.Drawing.Size(100, 32);
            this.lblNowMoney.TabIndex = 0;
            this.lblNowMoney.Text = "잔액";
            this.lblNowMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrintNowMoney
            // 
            this.lblPrintNowMoney.Font = new System.Drawing.Font("굴림", 11F);
            this.lblPrintNowMoney.Location = new System.Drawing.Point(1074, 17);
            this.lblPrintNowMoney.Name = "lblPrintNowMoney";
            this.lblPrintNowMoney.Size = new System.Drawing.Size(111, 26);
            this.lblPrintNowMoney.TabIndex = 0;
            this.lblPrintNowMoney.Text = "-";
            this.lblPrintNowMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuickExpenditure
            // 
            this.btnQuickExpenditure.Font = new System.Drawing.Font("굴림", 12F);
            this.btnQuickExpenditure.Location = new System.Drawing.Point(947, 164);
            this.btnQuickExpenditure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuickExpenditure.Name = "btnQuickExpenditure";
            this.btnQuickExpenditure.Size = new System.Drawing.Size(66, 33);
            this.btnQuickExpenditure.TabIndex = 1;
            this.btnQuickExpenditure.Text = "지출";
            this.btnQuickExpenditure.UseVisualStyleBackColor = true;
            this.btnQuickExpenditure.Click += new System.EventHandler(this.btnQuickExpenditure_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 548);
            this.Controls.Add(this.lblTargetAmount);
            this.Controls.Add(this.tctrlFinacialedger);
            this.Controls.Add(this.lblPrintTotalIncome);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblIncomeContent);
            this.Controls.Add(this.lblIncomeMoney);
            this.Controls.Add(this.lblNowContent);
            this.Controls.Add(this.lblExpenditureContent);
            this.Controls.Add(this.lblNowMoneyInput);
            this.Controls.Add(this.lblExpenditureMoney);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblWon2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTargetAmount);
            this.Controls.Add(this.lblWon);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.tbxYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblQuickInput);
            this.Controls.Add(this.lblExpenditure);
            this.Controls.Add(this.tbxIncomeMoney);
            this.Controls.Add(this.tbxQuickMoney);
            this.Controls.Add(this.lblPrintNowMoney);
            this.Controls.Add(this.lblPrintBlack);
            this.Controls.Add(this.tbxExpenditureMoney);
            this.Controls.Add(this.lblPrintTotalExpenditure);
            this.Controls.Add(this.tbxIncomeContent);
            this.Controls.Add(this.tbxIncomeYear);
            this.Controls.Add(this.lblNowMoney);
            this.Controls.Add(this.lblBlack);
            this.Controls.Add(this.tbxExpenditureYear);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.tbxIncomeMonth);
            this.Controls.Add(this.lblTotalExpenditure);
            this.Controls.Add(this.tbxExpenditureMonth);
            this.Controls.Add(this.tbxIncomeDay);
            this.Controls.Add(this.tbxExpenditureDay);
            this.Controls.Add(this.btnQuickExpenditure);
            this.Controls.Add(this.btnQuickIncome);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.btnExoenditure);
            this.Controls.Add(this.tbxQuickContent);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.tbxExpenditureContent);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tctrlFinacialedger.ResumeLayout(false);
            this.tpgIncome.ResumeLayout(false);
            this.tpgExpenditure.ResumeLayout(false);
            this.tpgAll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.TextBox tbxIncomeContent;
        private System.Windows.Forms.Label lblExpenditure;
        private System.Windows.Forms.Button btnExoenditure;
        private System.Windows.Forms.TextBox tbxExpenditureMoney;
        private System.Windows.Forms.TextBox tbxExpenditureContent;
        private System.Windows.Forms.TextBox tbxIncomeMoney;
        private System.Windows.Forms.TabControl tctrlFinacialedger;
        private System.Windows.Forms.TabPage tpgIncome;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbxYear;
        private System.Windows.Forms.TabPage tpgExpenditure;
        private System.Windows.Forms.Label lblTargetAmount;
        private System.Windows.Forms.TextBox tbxTargetAmount;
        private System.Windows.Forms.Label lblPrintTotalIncome;
        private System.Windows.Forms.Label lblPrintTotalExpenditure;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpenditure;
        private System.Windows.Forms.Label lblPrintBlack;
        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox tbxExpenditureDay;
        private System.Windows.Forms.TextBox tbxIncomeDay;
        private System.Windows.Forms.TextBox tbxExpenditureMonth;
        private System.Windows.Forms.TextBox tbxIncomeMonth;
        private System.Windows.Forms.TextBox tbxExpenditureYear;
        private System.Windows.Forms.TextBox tbxIncomeYear;
        private System.Windows.Forms.ListBox lbxExpenditures;
        private System.Windows.Forms.ListBox lbxIncomes;
        private System.Windows.Forms.TabPage tpgAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblWon;
        private System.Windows.Forms.Label lblWon2;
        private System.Windows.Forms.Label lblExpenditureMoney;
        private System.Windows.Forms.Label lblExpenditureContent;
        private System.Windows.Forms.Label lblIncomeMoney;
        private System.Windows.Forms.Label lblIncomeContent;
        private System.Windows.Forms.TextBox tbxQuickContent;
        private System.Windows.Forms.Button btnQuickIncome;
        private System.Windows.Forms.TextBox tbxQuickMoney;
        private System.Windows.Forms.Label lblQuickInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNowMoneyInput;
        private System.Windows.Forms.Label lblNowContent;
        private System.Windows.Forms.ListBox lbxAll;
        private System.Windows.Forms.Label lblNowMoney;
        private System.Windows.Forms.Label lblPrintNowMoney;
        private System.Windows.Forms.Button btnQuickExpenditure;
    }
}

