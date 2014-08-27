<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtStandardRunTime = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtWieghtTool = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtTool = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtProgram = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtWorkInstruction = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.cmbTubeLength = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.cmbBoreDiameter = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmbOpNo = New System.Windows.Forms.ComboBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtOperation = New System.Windows.Forms.TextBox()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.txtWorkCenter = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(66, 324)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.Size = New System.Drawing.Size(830, 262)
        Me.dataGridView1.TabIndex = 32
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(24, 170)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(217, 13)
        Me.label9.TabIndex = 19
        Me.label9.Text = "(**Rule: only called if the tube is over 40lbs) :"
        '
        'txtStandardRunTime
        '
        Me.txtStandardRunTime.Enabled = False
        Me.txtStandardRunTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStandardRunTime.Location = New System.Drawing.Point(115, 37)
        Me.txtStandardRunTime.Name = "txtStandardRunTime"
        Me.txtStandardRunTime.Size = New System.Drawing.Size(85, 21)
        Me.txtStandardRunTime.TabIndex = 15
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(0, 38)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(111, 15)
        Me.label5.TabIndex = 16
        Me.label5.Text = "Standard RunTime"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Controls.Add(Me.txtStandardRunTime)
        Me.groupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox3.Location = New System.Drawing.Point(633, 108)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(220, 100)
        Me.groupBox3.TabIndex = 29
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Standard Run Time"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.Location = New System.Drawing.Point(21, 139)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(34, 15)
        Me.label8.TabIndex = 18
        Me.label8.Text = "Tool "
        '
        'txtWieghtTool
        '
        Me.txtWieghtTool.Enabled = False
        Me.txtWieghtTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWieghtTool.Location = New System.Drawing.Point(127, 136)
        Me.txtWieghtTool.Name = "txtWieghtTool"
        Me.txtWieghtTool.Size = New System.Drawing.Size(96, 21)
        Me.txtWieghtTool.TabIndex = 17
        Me.txtWieghtTool.Text = "Caution Weight"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.txtWieghtTool)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.txtTool)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.txtProgram)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.txtWorkInstruction)
        Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(66, 109)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(289, 201)
        Me.groupBox1.TabIndex = 27
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "TOOLING"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(20, 101)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(37, 15)
        Me.label7.TabIndex = 16
        Me.label7.Text = "Tool :"
        '
        'txtTool
        '
        Me.txtTool.Enabled = False
        Me.txtTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTool.Location = New System.Drawing.Point(128, 98)
        Me.txtTool.Name = "txtTool"
        Me.txtTool.Size = New System.Drawing.Size(95, 21)
        Me.txtTool.TabIndex = 15
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(21, 66)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(61, 15)
        Me.label6.TabIndex = 14
        Me.label6.Text = "Program :"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProgram
        '
        Me.txtProgram.Enabled = False
        Me.txtProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgram.Location = New System.Drawing.Point(129, 63)
        Me.txtProgram.Name = "txtProgram"
        Me.txtProgram.Size = New System.Drawing.Size(94, 21)
        Me.txtProgram.TabIndex = 13
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(21, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(100, 15)
        Me.label4.TabIndex = 12
        Me.label4.Text = "Work Instruction :"
        '
        'txtWorkInstruction
        '
        Me.txtWorkInstruction.Enabled = False
        Me.txtWorkInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkInstruction.Location = New System.Drawing.Point(129, 33)
        Me.txtWorkInstruction.Name = "txtWorkInstruction"
        Me.txtWorkInstruction.Size = New System.Drawing.Size(94, 21)
        Me.txtWorkInstruction.TabIndex = 11
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(790, 59)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(106, 23)
        Me.btnSubmit.TabIndex = 26
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'cmbTubeLength
        '
        Me.cmbTubeLength.FormattingEnabled = True
        Me.cmbTubeLength.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", ""})
        Me.cmbTubeLength.Location = New System.Drawing.Point(622, 63)
        Me.cmbTubeLength.Name = "cmbTubeLength"
        Me.cmbTubeLength.Size = New System.Drawing.Size(107, 21)
        Me.cmbTubeLength.TabIndex = 25
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(551, 66)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(65, 13)
        Me.label3.TabIndex = 24
        Me.label3.Text = "TubeLength"
        '
        'cmbBoreDiameter
        '
        Me.cmbBoreDiameter.FormattingEnabled = True
        Me.cmbBoreDiameter.Items.AddRange(New Object() {"1.50", "1.75", "2.00", "2.25", "2.50", "2.75", "3.00", "3.25", "3.50", "4.00", "4.50", "5.00"})
        Me.cmbBoreDiameter.Location = New System.Drawing.Point(401, 62)
        Me.cmbBoreDiameter.Name = "cmbBoreDiameter"
        Me.cmbBoreDiameter.Size = New System.Drawing.Size(100, 21)
        Me.cmbBoreDiameter.TabIndex = 23
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(324, 69)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(71, 13)
        Me.label2.TabIndex = 21
        Me.label2.Text = "BoreDiameter"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(77, 64)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(62, 13)
        Me.label1.TabIndex = 34
        Me.label1.Text = "OP-Number"
        '
        'cmbOpNo
        '
        Me.cmbOpNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbOpNo.FormattingEnabled = True
        Me.cmbOpNo.Location = New System.Drawing.Point(145, 61)
        Me.cmbOpNo.Name = "cmbOpNo"
        Me.cmbOpNo.Size = New System.Drawing.Size(121, 21)
        Me.cmbOpNo.TabIndex = 33
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.txtOperation)
        Me.groupBox2.Controls.Add(Me.txtDepartment)
        Me.groupBox2.Controls.Add(Me.txtWorkCenter)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(361, 108)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(265, 144)
        Me.groupBox2.TabIndex = 35
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Work Center"
        '
        'txtOperation
        '
        Me.txtOperation.Enabled = False
        Me.txtOperation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperation.Location = New System.Drawing.Point(124, 103)
        Me.txtOperation.Name = "txtOperation"
        Me.txtOperation.Size = New System.Drawing.Size(85, 21)
        Me.txtOperation.TabIndex = 16
        '
        'txtDepartment
        '
        Me.txtDepartment.Enabled = False
        Me.txtDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(123, 70)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(85, 21)
        Me.txtDepartment.TabIndex = 15
        '
        'txtWorkCenter
        '
        Me.txtWorkCenter.Enabled = False
        Me.txtWorkCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkCenter.Location = New System.Drawing.Point(122, 37)
        Me.txtWorkCenter.Name = "txtWorkCenter"
        Me.txtWorkCenter.Size = New System.Drawing.Size(85, 21)
        Me.txtWorkCenter.TabIndex = 14
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label12.Location = New System.Drawing.Point(26, 105)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(61, 15)
        Me.label12.TabIndex = 2
        Me.label12.Text = "Operation"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(24, 70)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(72, 15)
        Me.label11.TabIndex = 1
        Me.label11.Text = "Department"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(23, 40)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(82, 16)
        Me.label10.TabIndex = 0
        Me.label10.Text = "Work Center"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 639)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmbOpNo)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cmbTubeLength)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cmbBoreDiameter)
        Me.Controls.Add(Me.label2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents txtStandardRunTime As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtWieghtTool As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents txtTool As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents txtProgram As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtWorkInstruction As System.Windows.Forms.TextBox
    Private WithEvents btnSubmit As System.Windows.Forms.Button
    Private WithEvents cmbTubeLength As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cmbBoreDiameter As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmbOpNo As System.Windows.Forms.ComboBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents txtOperation As System.Windows.Forms.TextBox
    Private WithEvents txtDepartment As System.Windows.Forms.TextBox
    Private WithEvents txtWorkCenter As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label

End Class
